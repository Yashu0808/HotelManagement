using AutoMapper;
using Data;

namespace Shared
{
    public class MapperInitilizer : Profile
    {
        public MapperInitilizer()
        {
          
            CreateMap<Hotel, HotelDTO>().ReverseMap();
            CreateMap<Rooms, RoomDTO>().ReverseMap();
            CreateMap<Booking, BookingDTO>().ReverseMap();
        }
    }
}
