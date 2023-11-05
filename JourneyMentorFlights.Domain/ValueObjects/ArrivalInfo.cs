using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyMentorFlights.Domain.ValueObjects
{
    public class ArrivalInfo
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
}
