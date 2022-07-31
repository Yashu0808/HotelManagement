using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shared
{
    public class BookingDTO
    {
        public int Id { get; set; }

        [Required]
        public int HotelId { get; set; }

        [Required]
        public int UserId { get; set; }


        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }
        [Required]
        public int RoomId { get; set; }
        [Required]
        public int RoomsAllotted { get; set; }
    }



}
