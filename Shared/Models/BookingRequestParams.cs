using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Shared.Models
{
    public class BookingRequestParams
    {
        int _hotelId;
        DateTime _startDate;
        DateTime _endDate;
        int _roomCount;
        int _userId;

        RoomTypeVariantId _variant;

        public int HotelId { get => _hotelId; set => _hotelId = value; }
        public DateTime StartDate { get => _startDate; set => _startDate = value; }
        public DateTime EndDate { get => _endDate; set => _endDate = value; }
        public int RoomCount { get => _roomCount; set => _roomCount = value; }
        public int UserId { get => _userId; set => _userId = value; }
        public RoomTypeVariantId Variant { get => _variant; set => _variant = value; }
    }
}
