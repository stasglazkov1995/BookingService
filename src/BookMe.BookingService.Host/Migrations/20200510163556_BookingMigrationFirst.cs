using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookMe.BookingService.Host.Migrations
{
    public partial class BookingMigrationFirst : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BookingDate",
                schema: "BookingService",
                table: "Bookings",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "BookingStatus",
                schema: "BookingService",
                table: "Bookings",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookingDate",
                schema: "BookingService",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "BookingStatus",
                schema: "BookingService",
                table: "Bookings");
        }
    }
}
