using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JourneyMentorFlights.Infrastructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Airports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Gmt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IataCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityIataCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IcaoCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryIso2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GeonameId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Longitude = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AirportName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Timezone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Arrival_Airport = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Arrival_Timezone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Arrival_IATA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Arrival_ICAO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Arrival_Terminal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Arrival_Gate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Arrival_Baggage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Arrival_Delay = table.Column<int>(type: "int", nullable: true),
                    Arrival_Scheduled = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Arrival_Estimated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Arrival_Actual = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Arrival_EstimatedRunway = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Arrival_ActualRunway = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Departure_Airport = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Departure_Timezone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Departure_IATA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Departure_ICAO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Departure_Terminal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Departure_Gate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Departure_Delay = table.Column<int>(type: "int", nullable: true),
                    Departure_Scheduled = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Departure_Estimated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Departure_Actual = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Departure_EstimatedRunway = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Departure_ActualRunway = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Airline_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Airline_IataCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Airline_IcaoCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlightDetails_Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlightDetails_Iata = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlightDetails_Icao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlightDetails_Codeshared_AirlineName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlightDetails_Codeshared_AirlineIata = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlightDetails_Codeshared_AirlineIcao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlightDetails_Codeshared_FlightNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlightDetails_Codeshared_FlightIata = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlightDetails_Codeshared_FlightIcao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LiveDetails_Updated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LiveDetails_Latitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LiveDetails_Longitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LiveDetails_Altitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LiveDetails_Direction = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LiveDetails_SpeedHorizontal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LiveDetails_SpeedVertical = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LiveDetails_IsGround = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Airports");

            migrationBuilder.DropTable(
                name: "Flights");
        }
    }
}
