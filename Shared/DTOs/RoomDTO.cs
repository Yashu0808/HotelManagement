using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class RoomDTO
    {
        public int Id { get; set; }
        public int NumberOfRoomsAvailable { get; set; }
        public int HotelId { get; set; }

        public double Price { get; set; }
    }
}
