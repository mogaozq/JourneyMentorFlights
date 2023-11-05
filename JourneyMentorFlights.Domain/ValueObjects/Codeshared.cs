using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyMentorFlights.Domain.ValueObjects
{
        public class Codeshared
        {
            public string? AirlineName { get; set; }
            public string? AirlineIata { get; set; }
            public string? AirlineIcao { get; set; }
            public string? FlightNumber { get; set; }
            public string? FlightIata { get; set; }
            public string? FlightIcao { get; set; }
        }
}
