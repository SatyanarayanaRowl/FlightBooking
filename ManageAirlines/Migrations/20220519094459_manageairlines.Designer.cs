﻿// <auto-generated />
using System;
using ManageAirlines.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ManageAirlines.Migrations
{
    [DbContext(typeof(AirlinesDbContext))]
    [Migration("20220519094459_manageairlines")]
    partial class manageairlines
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ManageAirlines.Models.Airlines", b =>
                {
                    b.Property<int>("FlightId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Airline");

                    b.Property<int>("BusinessSeats");

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("FromPlace");

                    b.Property<string>("Instrument");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Meals");

                    b.Property<int>("NoOfRows");

                    b.Property<int>("NonBusinessSeats");

                    b.Property<string>("ScehduledDates");

                    b.Property<DateTime>("StartDate");

                    b.Property<decimal>("TciketCost");

                    b.Property<string>("ToPlace");

                    b.HasKey("FlightId");

                    b.ToTable("ManageFlights");
                });
#pragma warning restore 612, 618
        }
    }
}
