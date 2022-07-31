using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelManagementSystem.Data.Configurations
{
    public class RoomsConfiguration : IEntityTypeConfiguration<Rooms>
    {
        public void Configure(EntityTypeBuilder<Rooms> builder)
        {

           builder.HasData(
                new Rooms {
                    Id= 1,
                    HotelId =1,
                    NumberOfRoomsAvailable = 4,
                    Price = 1000,
                    RoomTypeVariantId = RoomTypeVariantId.Suite},
                    new Rooms {
                    Id= 2,
                    HotelId =1,
                    NumberOfRoomsAvailable = 4,
                    Price = 1000,
                        RoomTypeVariantId = RoomTypeVariantId.Deluxe},
                new Rooms {
                    Id= 3,
                    HotelId =2,
                    NumberOfRoomsAvailable = 4,
                    Price = 1000,
                    RoomTypeVariantId = RoomTypeVariantId.Suite
                },
                    new Rooms {
                    Id= 4,
                    HotelId =2,
                    NumberOfRoomsAvailable = 4,
                    Price = 1000,
                        RoomTypeVariantId = RoomTypeVariantId.Deluxe
                    }
                     
            );
        }
    }
}
