using JourneyMentorFlights.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyMentorFlights.Application.Flights.Dtos
{
    public class FlightDto
    {
        public int Id { get; set; }
        public string FlightDate { get; set; }
        public string Status { get; set; }
        public ArrivalInfoDto Arrival { get; set; }
        public DepartureInfoDto Departure { get; set; }
        public AirlineDto Airline { get; set; }
        public FlightDetailsDto FlightDetails { get; set; }
        public FlightLiveDetailsDto LiveDetails { get; set; }
    }

    public class ArrivalInfoDto
    {
        public string? Airport { get; set; }
        public string? Timezone { get; set; }
        public string? IATA { get; set; }
        public string? ICAO { get; set; }
        public string? Terminal { get; set; }
        public string? Gate { get; set; }
        public string? Baggage { get; set; }
        public int? Delay { get; set; }
        public DateTime? Scheduled { get; set; }
        public DateTime? Estimated { get; set; }
        public DateTime? Actual { get; set; }
        public DateTime? EstimatedRunway { get; set; }
        public DateTime? ActualRunway { get; set; }
    }

    public class DepartureInfoDto
    {
        public string? Airport { get; set; }
        public string? Timezone { get; set; }
        public string? IATA { get; set; }
        public string? ICAO { get; set; }
        public string? Terminal { get; set; }
        public string? Gate { get; set; }
        public int? Delay { get; set; }
        public DateTime? Scheduled { get; set; }
        public DateTime? Estimated { get; set; }
        public DateTime? Actual { get; set; }
        public DateTime? EstimatedRunway { get; set; }
        public DateTime? ActualRunway { get; set; }
    }

    public class AirlineDto
    {
        public string? Name { get; set; }
        public string? Iata { get; set; }
        public string? Icao { get; set; }
    }

    public class FlightDetailsDto
    {
        public string? Number { get; set; }
        public string? Iata { get; set; }
        public string? Icao { get; set; }
        public Codeshared Codeshared { get; set; }
    }

    public class FlightLiveDetailsDto
    {
        public DateTime? Updated { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public decimal? Altitude { get; set; }
        public decimal? Direction { get; set; }
        public decimal? SpeedHorizontal { get; set; }
        public decimal? SpeedVertical { get; set; }
        public bool? IsGround { get; set; }
    }
}
