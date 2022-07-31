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
    public class BookingController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<BookingController> _logger;
        private readonly IMapper _mapper;

        public BookingController(IUnitOfWork unitOfWork, ILogger<BookingController> logger,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Book([FromBody] BookingRequestParams requestParams)
        {
            var booking = await _unitOfWork.Bookings.ReserveRoom(requestParams);
            if(booking == null)
            {
                 _logger.LogError($"Invalid attempt in {nameof(Book)}");
                   return BadRequest("Submitted data is invalid");
            }
            var result = _mapper.Map<BookingDTO>(booking);
            return Ok(result);

        }

       
      
    }
}
