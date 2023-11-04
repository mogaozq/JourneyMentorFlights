using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyMentorFlights.Domain.Entities
{
    public class Airline
    {
        public string Name { get; set; }
        public string IataCode { get; set; }
        public string IcaoCode { get; set; }
    }
}
