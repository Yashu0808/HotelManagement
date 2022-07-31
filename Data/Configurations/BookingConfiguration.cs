using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelManagementSystem.Data.Configurations
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasData(
                new Booking
                {
                    Id = 1,
                    EndTime = DateTime.Now,
                    StartTime= DateTime.Now - TimeSpan.FromDays(1),
                    HotelId = 1,
                    RoomsAllotted = 2,
                    RoomId = 1,
                    UserId=1
                });
        }
    }
}
