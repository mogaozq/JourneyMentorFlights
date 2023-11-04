using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyMentorFlights.Infrastructure.AviationStack.Models
{
    public class Airline
    {
        public string airline_name { get; set; }
        public string iata_code { get; set; }
        public string iata_prefix_accounting { get; set; }
        public string icao_code { get; set; }
        public string callsign { get; set; }
        public string type { get; set; }
        public string status { get; set; }
        public string fleet_size { get; set; }
        public string fleet_average_age { get; set; }
        public string date_founded { get; set; }
        public string hub_code { get; set; }
        public string country_name { get; set; }
        public string country_iso2 { get; set; }
    }

}
