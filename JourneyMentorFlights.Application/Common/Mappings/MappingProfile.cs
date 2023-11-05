using AutoMapper;
using JourneyMentorFlights.Application.Flights.Dtos;
using JourneyMentorFlights.Domain.Entities;
using JourneyMentorFlights.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyMentorFlights.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Flight, FlightDto>();
            CreateMap<ArrivalInfo, ArrivalInfoDto>();
            CreateMap<DepartureInfo, DepartureInfoDto>();
            CreateMap<Airline, AirlineDto>();
            CreateMap<FlightDetails, FlightDetailsDto>();
            CreateMap<FlightLiveDetails, FlightLiveDetailsDto>();
        }
    }
}
