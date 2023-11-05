using JourneyMentorFlights.Application.Flights.Commands;
using JourneyMentorFlights.Application.Flights.Dtos;
using JourneyMentorFlights.Application.Flights.Queries;
using JourneyMentorFlights.Infrastructure.Common.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace JourneyMentorFlights.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FlightsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FlightsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// get flights in pagination
        /// </summary>
        /// <param name="airportIata"></param>
        /// <param name="flightNumber"></param>
        /// <returns></returns>
        [HttpGet(Name = "GetFlights")]
        public async Task<ActionResult<PaginatedList<FlightDto>>> GetAsync([FromQuery] PageParameters pageParameters, string? airportIata, string? flightNumber)
        {
            return await _mediator.Send(new GetPaginatedFlightsQuery()
            {
                PageNumber = pageParameters.PageNumber,
                PageSize = pageParameters.PageSize,
                AirportIata = airportIata,
                FlightNumber = flightNumber
            });
        }

        /// <summary>
        /// sync flights data
        /// </summary>
        /// <param name="dataDownloaderService"></param>
        /// <returns></returns>
        [HttpPost("SyncFlights", Name = "SyncFlights")]
        public async Task<IActionResult?> SyncFlights([Required, Range(1, 100)] int limit,[Range(1, int.MaxValue)] int offset)
        {
            await _mediator.Send(new SyncFlightsCommand()
            {
                Offset = offset,
                Limit = limit
            });

            return NoContent();
        }
    }
}