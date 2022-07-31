using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Shared;
using Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<HotelController> _logger;
        private readonly IMapper _mapper;

        public HotelController(IUnitOfWork unitOfWork, ILogger<HotelController> logger,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetHotels([FromQuery] RequestParams requestParams)
        {
            var hotels = await _unitOfWork.Hotels.GetPagedList(requestParams, exp => exp.Rooms.Any(x => x.NumberOfRoomsAvailable > 0) &&
            exp.Name.Contains(requestParams.HotelName),
            include: q => q.Include(x => x.Rooms)); 
            var results = _mapper.Map<IList<HotelDTO>>(hotels);
            return Ok(results);
        }

        [HttpGet("{id:int}", Name = "GetHotel")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetHotel(int id)
        {
            var hotel = await _unitOfWork.Hotels.Get(q => q.Id == id, include: q => q.Include(x => x.Rooms));
            var result = _mapper.Map<HotelDTO>(hotel);
            return Ok(result);
        }
      
    }
}
