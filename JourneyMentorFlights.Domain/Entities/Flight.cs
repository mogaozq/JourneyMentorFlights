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
        public int Id { get; set; }
        public string FlightDate { get; set; }
        public string Status { get; set; }
        public ArrivalInfo Arrival { get; set; }
        public DepartureInfo Departure { get; set; }
        public Airline Airline { get; set; }
        public FlightDetails FlightDetails { get; set; }
        public FlightLiveDetails LiveDetails { get; set; }
    }
}
