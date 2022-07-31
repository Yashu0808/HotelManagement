using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class InitialMigration_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2022, 7, 31, 16, 48, 34, 791, DateTimeKind.Local).AddTicks(9395), new DateTime(2022, 7, 30, 16, 48, 34, 791, DateTimeKind.Local).AddTicks(9408) });

            migrationBuilder.AddCheckConstraint(
                name: "CheckGreaterThanZero",
                table: "Rooms",
                sql: "[NumberOfRoomsAvailable] >= 0");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CheckGreaterThanZero",
                table: "Rooms");

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2022, 7, 31, 16, 22, 53, 589, DateTimeKind.Local).AddTicks(5478), new DateTime(2022, 7, 30, 16, 22, 53, 589, DateTimeKind.Local).AddTicks(5488) });
        }
    }
}
