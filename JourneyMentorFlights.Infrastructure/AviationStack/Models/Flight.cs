using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyMentorFlights.Infrastructure.AviationStack.Models
{
    public class Flight
    {
        public string flight_date { get; set; }
        public string flight_status { get; set; }
        public Departure departure { get; set; }
        public Arrival arrival { get; set; }
        public AirlineSummary airline { get; set; }
        public FlightDetails flight { get; set; }
        public Aircraft aircraft { get; set; }
        public LiveInfo live { get; set; }
    }
    public class Aircraft
    {
        public string registration { get; set; }
        public string iata { get; set; }
        public string icao { get; set; }
        public string icao24 { get; set; }
    }

    public class AirlineSummary
    {
        public string name { get; set; }
        public string iata { get; set; }
        public string icao { get; set; }
    }

    public class Arrival
    {
        public string airport { get; set; }
        public string timezone { get; set; }
        public string iata { get; set; }
        public string icao { get; set; }
        public string terminal { get; set; }
        public string gate { get; set; }
        public string baggage { get; set; }
        public int delay { get; set; }
        public DateTime scheduled { get; set; }
        public DateTime estimated { get; set; }
        public object actual { get; set; }
        public object estimated_runway { get; set; }
        public object actual_runway { get; set; }
    }

    public class Departure
    {
        public string airport { get; set; }
        public string timezone { get; set; }
        public string iata { get; set; }
        public string icao { get; set; }
        public string terminal { get; set; }
        public string gate { get; set; }
        public int delay { get; set; }
        public DateTime scheduled { get; set; }
        public DateTime estimated { get; set; }
        public DateTime actual { get; set; }
        public DateTime estimated_runway { get; set; }
        public DateTime actual_runway { get; set; }
    }

    public class FlightDetails
    {
        public string number { get; set; }
        public string iata { get; set; }
        public string icao { get; set; }
        public object codeshared { get; set; }
    }

    public class LiveInfo
    {
        public DateTime updated { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public double altitude { get; set; }
        public double direction { get; set; }
        public double speed_horizontal { get; set; }
        public double speed_vertical { get; set; }
        public bool is_ground { get; set; }
    }



}
