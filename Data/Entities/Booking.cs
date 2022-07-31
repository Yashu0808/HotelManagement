using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Booking
    {
        public int Id { get; set; }

        [ForeignKey(nameof(Hotel))]
        public int HotelId { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }

        public User User{ get; set; }

        public Hotel Hotel { get; set; }
        public DateTime StartTime{ get; set; }
        public DateTime EndTime { get; set; }

        [ForeignKey(nameof(Rooms))]
        public int RoomId { get; set; }
       public int RoomsAllotted { get; set; }

        public Booking()
        {

        }
    }
}
