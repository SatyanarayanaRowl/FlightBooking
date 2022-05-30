using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AirlineManagement.Migrations
{
    public partial class ailinemigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Airlines",
                columns: table => new
                {
                    AirlineNo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UploadLogo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactAddress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airlines", x => x.AirlineNo);
                });

            migrationBuilder.CreateTable(
                name: "inventoryTbls",
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
                    table.PrimaryKey("PK_inventoryTbls", x => x.FlightNumber);
                    table.ForeignKey(
                        name: "FK_inventoryTbls_Airlines_AirlineNo",
                        column: x => x.AirlineNo,
                        principalTable: "Airlines",
                        principalColumn: "AirlineNo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_inventoryTbls_AirlineNo",
                table: "inventoryTbls",
                column: "AirlineNo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "inventoryTbls");

            migrationBuilder.DropTable(
                name: "Airlines");
        }
    }
}
