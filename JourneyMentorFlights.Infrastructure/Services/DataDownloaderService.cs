using JourneyMentorFlights.Application.Common.Interfaces;
using JourneyMentorFlights.Application.Flights.Dtos;
using JourneyMentorFlights.Infrastructure.AviationStack;
using JourneyMentorFlights.Infrastructure.AviationStack.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyMentorFlights.Infrastructure.Services
{
    public class DataDownloaderService : IDataDownloaderService
    {
        private readonly AviationStackApiV1 _aviationStackApiV1;
        private readonly IApplicationDbContext _dbContext;

        public DataDownloaderService(AviationStackApiV1 aviationStackApiV1, IApplicationDbContext dbContext)
        {
            _aviationStackApiV1 = aviationStackApiV1;
            _dbContext = dbContext;
        }

        public async Task DownloadAndSaveAirports()
        {
            var currentAirportCounts = await _dbContext.Airports.CountAsync();

            var toBeAddedAirports = new List<Domain.Entities.Airport>();
            var cycleFetchedCount = 0;
            do
            {

                var airportPaginatedList = await _aviationStackApiV1.GetAirportsAsync(new PaginationParameters
                {
                    limit = 3000,
                    offset = currentAirportCounts + toBeAddedAirports.Count
                });

                cycleFetchedCount = airportPaginatedList.pagination.Count;

                var airports = airportPaginatedList.data.Select(a => new Domain.Entities.Airport
                {
                    Id = int.Parse(a.id),
                    AirportName = a.airport_name,
                    IataCode = a.iata_code,
                    IcaoCode = a.icao_code,
                    CityIataCode = a.city_iata_code,
                    CountryIso2 = a.country_iso2,
                    CountryName = a.country_name,
                    GeonameId = a.geoname_id,
                    Gmt = a.gmt,
                    Latitude = a.latitude == null ? null : decimal.Parse(a.latitude),
                    Longitude = a.longitude == null ? null : decimal.Parse(a.longitude),
                    PhoneNumber = a.phone_number,
                    Timezone = a.timezone
                });

                toBeAddedAirports.AddRange(airports);
            }
            while (cycleFetchedCount != 0);

            _dbContext.Airports.AddRange(toBeAddedAirports);
            await _dbContext.SaveChangesAsync(new CancellationToken());
        }

        public async Task DownloadAndSaveFlights(int limit, int offset)
        {
            var toBeAddedFlights = new List<Domain.Entities.Flight>();

            var flightPaginatedList = await _aviationStackApiV1.GetFlightsAsync(new PaginationParameters
            {
                limit = limit,
                offset = offset
            });

            foreach (var flight in flightPaginatedList.data)
            {
                if (FlightExists(flight))
                    continue;

                toBeAddedFlights.Add(MapToFlightEntity(flight));
            }

            _dbContext.Flights.AddRange(toBeAddedFlights);
            await _dbContext.SaveChangesAsync(new CancellationToken());
        }

        private Domain.Entities.Flight MapToFlightEntity(Flight flight)
        {
            return new Domain.Entities.Flight
            {
                FlightDate = flight.flight_date,
                Status = flight.flight_status,
                Arrival = new Domain.ValueObjects.ArrivalInfo
                {
                    Scheduled = flight.arrival.scheduled,
                    Actual = flight.arrival.actual,
                    ActualRunway = flight.arrival.actual_runway,
                    Estimated = flight.arrival.estimated,
                    EstimatedRunway = flight.arrival.estimated_runway,
                    Airport = flight.arrival.airport,
                    Baggage = flight.arrival.baggage,
                    Delay = flight.arrival.delay,
                    Gate = flight.arrival.gate,
                    IATA = flight.arrival.iata,
                    ICAO = flight.arrival.icao,
                    Terminal = flight.arrival.terminal,
                    Timezone = flight.arrival.timezone,
                },
                Departure = new Domain.ValueObjects.DepartureInfo
                {
                    Scheduled = flight.departure.scheduled,
                    Actual = flight.departure.actual,
                    ActualRunway = flight.departure.actual_runway,
                    Estimated = flight.departure.estimated,
                    EstimatedRunway = flight.departure.estimated_runway,
                    Airport = flight.departure.airport,
                    Delay = flight.departure.delay,
                    Gate = flight.departure.gate,
                    IATA = flight.departure.iata,
                    ICAO = flight.departure.icao,
                    Terminal = flight.departure.terminal,
                    Timezone = flight.departure.timezone,

                },
                Airline = new Domain.ValueObjects.Airline
                {
                    Iata = flight.airline.iata,
                    Icao = flight.airline.icao,
                    Name = flight.airline.name,
                },
                FlightDetails = new Domain.ValueObjects.FlightDetails
                {
                    Number = flight.flight.number,
                    Iata = flight.flight.iata,
                    Icao = flight.flight.icao,
                    Codeshared = new Domain.ValueObjects.Codeshared
                    {
                        AirlineIata = flight.flight.codeshared?.airline_iata,
                        AirlineIcao = flight.flight.codeshared?.airline_icao,
                        AirlineName = flight.flight.codeshared?.airline_name,
                        FlightIata = flight.flight.codeshared?.flight_iata,
                        FlightIcao = flight.flight.codeshared?.flight_icao,
                        FlightNumber = flight.flight.codeshared?.flight_number,
                    },
                },
                LiveDetails = new Domain.ValueObjects.FlightLiveDetails
                {
                    Altitude = flight.live?.altitude,
                    Direction = flight.live?.direction,
                    IsGround = flight.live?.is_ground,
                    Latitude = flight.live?.latitude,
                    Longitude = flight.live?.longitude,
                    SpeedHorizontal = flight.live?.speed_horizontal,
                    SpeedVertical = flight.live?.speed_vertical,
                    Updated = flight.live?.updated,
                }
            };
        }

        private bool FlightExists(Flight flight)
        {
            return _dbContext.Flights.Any(f => f.FlightDetails.Number == flight.flight.number);
        }
    }
}
