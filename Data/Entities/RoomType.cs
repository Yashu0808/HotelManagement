namespace Data
{


    public enum RoomTypeVariantId : int
    {
        Deluxe = 1,
        Standard = 2,
        Suite = 3
    }

    public class RoomTypeVariant
    {
        public RoomTypeVariantId RoomTypeVariantId { get; set; }
        public string Name { get; set; }
    }
}
