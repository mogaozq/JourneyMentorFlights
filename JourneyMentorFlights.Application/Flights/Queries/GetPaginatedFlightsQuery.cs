using AutoMapper;
using JourneyMentorFlights.Application.Common.Interfaces;
using JourneyMentorFlights.Application.Flights.Dtos;
using JourneyMentorFlights.Domain.Entities;
using JourneyMentorFlights.Infrastructure.Common.Pagination;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyMentorFlights.Application.Flights.Queries
{
    public class GetPaginatedFlightsQuery : PageParameters, IRequest<PaginatedList<FlightDto>>
    {
        public string? AirportIata { get; set; }
        public string? FlightNumber { get; set; }
    }

    public class GetPaginatedFlightsQueryHandler : IRequestHandler<GetPaginatedFlightsQuery, PaginatedList<FlightDto>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetPaginatedFlightsQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<PaginatedList<FlightDto>> Handle(GetPaginatedFlightsQuery request, CancellationToken cancellationToken)
        {
            var flightsQuery = _dbContext.Flights.AsNoTracking();

            if (request.AirportIata != null)
            {
                flightsQuery = flightsQuery.Where(f => f.Departure.IATA == request.AirportIata || f.Arrival.IATA == request.AirportIata);
            }

            if (request.FlightNumber != null)
            {
                flightsQuery = flightsQuery.Where(f => f.FlightDetails.Number == request.FlightNumber);
            }

            var paginatedFlights = await PaginatedList<Flight>.CreateAsync(flightsQuery, request.PageNumber, request.PageSize, cancellationToken);
            var paginatedFlightDtos = paginatedFlights.MapTo<FlightDto>(_mapper);

            return paginatedFlightDtos;
        }
    }
}
