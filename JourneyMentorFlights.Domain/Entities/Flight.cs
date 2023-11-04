using JourneyMentorFlights.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyMentorFlights.Domain.Entities
{
    public class Flight
    {
        public string FlightNumber { get; set; }
        public string FlightStatus { get; set; }
        public DateTime FlightDate { get; set; }
        public string IataFlightNumber { get; set; }
        public string IcaoFlightNumber { get; set; }

        public int ArrivalAirportId { get; set; }
        public Airport ArrivalAirport { get; set; }
        public DateTimeOffset ScheduledArrival { get; set; }
        public DateTimeOffset EstimatedArrival { get; set; }
        public DateTimeOffset ActualArrival { get; set; }
        public DateTimeOffset EstimatedRunwayArrival { get; set; }
        public DateTimeOffset ActualRunwayArrival { get; set; }

        public int DepartureAirportId { get; set; }
        public Airport DepartureAirport { get; set; }
        public DateTimeOffset ScheduledDeparture { get; set; }
        public DateTimeOffset EstimatedDeparture { get; set; }
        public DateTimeOffset ActualDeparture { get; set; }
        public DateTimeOffset EstimatedRunwayDeparture { get; set; }
        public DateTimeOffset ActualRunwayDeparture { get; set; }

        public Airline Airline { get; set; }
        public FlightLiveDetails Live { get; set; }
    }
}
