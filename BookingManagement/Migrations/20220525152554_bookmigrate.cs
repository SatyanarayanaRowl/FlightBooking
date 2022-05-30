using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingManagement.Migrations
{
    public partial class bookmigrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AirlineTbl",
                columns: table => new
                {
                    AirlineNo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UploadLogo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactAddress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirlineTbl", x => x.AirlineNo);
                });

            migrationBuilder.CreateTable(
                name: "BookflightTbls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Meal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FlightNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pnr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    peopleid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookflightTbls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserDetailTbls",
                columns: table => new
                {
                    PeopleId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Class = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDetailTbls", x => x.PeopleId);
                });

            migrationBuilder.CreateTable(
                name: "InventoryTbls",
                columns: table => new
                {
                    FlightNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AirlineNo = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FromPlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToPlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ScheduleDays = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstrumentUsed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessClassSeat = table.Column<int>(type: "int", nullable: true),
                    NonBusinessClassSeat = table.Column<int>(type: "int", nullable: true),
                    TicketCost = table.Column<decimal>(type: "decimal(8,2)", nullable: true),
                    NoOfRows = table.Column<int>(type: "int", nullable: true),
                    Meal = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryTbls", x => x.FlightNumber);
                    table.ForeignKey(
                        name: "FK_InventoryTbls_AirlineTbl_AirlineNo",
                        column: x => x.AirlineNo,
                        principalTable: "AirlineTbl",
                        principalColumn: "AirlineNo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryTbls_AirlineNo",
                table: "InventoryTbls",
                column: "AirlineNo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookflightTbls");

            migrationBuilder.DropTable(
                name: "InventoryTbls");

            migrationBuilder.DropTable(
                name: "UserDetailTbls");

            migrationBuilder.DropTable(
                name: "AirlineTbl");
        }
    }
}
