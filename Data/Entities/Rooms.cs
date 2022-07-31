using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    public class Rooms
    {
        public int Id { get; set; }

        public RoomTypeVariantId RoomTypeVariantId { get; set; }
        public RoomTypeVariant RoomTypeVariant { get; set; }

        [Range(0, Int32.MaxValue)]
        public int NumberOfRoomsAvailable { get; set; }

        [ForeignKey(nameof(Hotel))]
        public int HotelId { get; set; }

        public Hotel Hotel{ get; set; }

        public double Price { get; set; }

    }
}
