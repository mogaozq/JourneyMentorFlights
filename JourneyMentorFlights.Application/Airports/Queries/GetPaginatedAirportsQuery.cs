using AutoMapper;
using JourneyMentorFlights.Application.Airports.Dtos;
using JourneyMentorFlights.Application.Common.Interfaces;
using JourneyMentorFlights.Domain.Entities;
using JourneyMentorFlights.Infrastructure.Common.Pagination;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyMentorFlights.Application.Airports.Queries
{
    public class GetPaginatedAirportsQuery : PageParameters, IRequest<PaginatedList<AirportDto>>
    {
    }

    public class GetPaginatedAirportsQueryHandler : IRequestHandler<GetPaginatedAirportsQuery, PaginatedList<AirportDto>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetPaginatedAirportsQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<PaginatedList<AirportDto>> Handle(GetPaginatedAirportsQuery request, CancellationToken cancellationToken)
        {
            var airportsQuery = _dbContext.Airports.AsNoTracking();

            var paginatedAirports = await PaginatedList<Airport>.CreateAsync(airportsQuery, request.PageNumber, request.PageSize, cancellationToken);
            var paginatedAirportDtos = paginatedAirports.MapTo<AirportDto>(_mapper);

            return paginatedAirportDtos;
        }
    }
}
