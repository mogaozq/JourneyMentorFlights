using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyMentorFlights.Domain.ValueObjects
{
    public class FlightDetails
    {
        public string? Number { get; set; }
        public string? Iata { get; set; }
        public string? Icao { get; set; }
        public Codeshared Codeshared { get; set; }
    }
}
