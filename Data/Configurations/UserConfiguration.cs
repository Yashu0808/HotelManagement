using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelManagementSystem.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User
                {
                    Id = 1,
                    Name = "A"
                },
                new User
                {
                    Id = 2,
                    Name = "B"
                }, new User
                {
                    Id = 3,
                    Name = "C"
                }, new User
                {
                    Id = 4,
                    Name = "D"
                }, new User
                {
                    Id = 5,
                    Name = "E"
                });
        }
    }
}
