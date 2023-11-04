using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyMentorFlights.Domain.ValueObjects
{
    public class FlightLiveDetails
    {
        public DateTimeOffset Updated { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public decimal Altitude { get; set; }
        public decimal Direction { get; set; }
        public decimal SpeedHorizontal { get; set; }
        public decimal SpeedVertical { get; set; }
        public bool IsGround { get; set; }
    }
}
