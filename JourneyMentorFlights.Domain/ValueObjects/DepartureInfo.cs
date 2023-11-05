using JourneyMentorFlights.Domain.Entities;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace JourneyMentorFlights.Domain.ValueObjects
{
    public class DepartureInfo
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
}
