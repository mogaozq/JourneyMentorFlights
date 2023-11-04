using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyMentorFlights.Domain.Entities
{
    public class Airport
    {
        public int Id { get; set; }
        public int Gmt { get; set; }
        public string IataCode { get; set; }
        public string CityIataCode { get; set; }
        public string IcaoCode { get; set; }
        public string CountryIso2 { get; set; }
        public string GeonameId { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string AirportName { get; set; }
        public string CountryName { get; set; }
        public string PhoneNumber { get; set; }
        public string Timezone { get; set; }

        public ICollection<Flight> ArivalFlights{ get; set; }
        public ICollection<Flight> DepartureFlights { get; set; }
    }

}
