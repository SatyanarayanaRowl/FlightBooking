using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlightBooking.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookingTickets",
                columns: table => new
                {
                    PnrID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmailID = table.Column<string>(nullable: true),
                    PassengerID = table.Column<int>(nullable: false),
                    PassengerName = table.Column<string>(nullable: true),
                    PassengerAge = table.Column<string>(nullable: true),
                    NumberOfSeats = table.Column<int>(nullable: false),
                    MealsOption = table.Column<string>(nullable: true),
                    SelectedSeatNumbers = table.Column<string>(nullable: true),
                    BookingTime = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingTickets", x => x.PnrID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingTickets");
        }
    }
}
