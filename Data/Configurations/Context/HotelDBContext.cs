using HotelManagementSystem.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class HotelDBContext : DbContext
    {
        public HotelDBContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Rooms> Rooms { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Booking> Bookings { get; set; }


        public DbSet<RoomTypeVariant> RoomTypeVariants { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Rooms>()
 .HasCheckConstraint("CheckGreaterThanZero", "[NumberOfRoomsAvailable] >= 0");


            builder.Entity<Rooms>()
            .Property(s => s.NumberOfRoomsAvailable)
            .IsConcurrencyToken();

            builder
               .Entity<Rooms>()
               .Property(e => e.RoomTypeVariantId)
               .HasConversion<int>();


            builder
                .Entity<RoomTypeVariant>()
                .Property(e => e.RoomTypeVariantId)
                .HasConversion<int>();

            builder
                .Entity<RoomTypeVariant>().HasData(
                    Enum.GetValues(typeof(RoomTypeVariantId))
                        .Cast<RoomTypeVariantId>()
                        .Select(e => new RoomTypeVariant()
                        {
                            RoomTypeVariantId = e,
                            Name = e.ToString()
                        })
                );

            builder.ApplyConfiguration(new HotelConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new RoomsConfiguration());
            builder.ApplyConfiguration(new BookingConfiguration());
        }
    

       
    }

}