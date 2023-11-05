using JourneyMentorFlights.Application.Airports.Commands;
using JourneyMentorFlights.Application.Airports.Dtos;
using JourneyMentorFlights.Application.Airports.Queries;
using JourneyMentorFlights.Infrastructure.Common.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JourneyMentorFlights.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AirportsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AirportsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// get airports in pagination
        /// </summary>
        /// <param name="pageParameters"></param>
        /// <returns></returns>
        [HttpGet(Name = "GetAirports")]
        public async Task<ActionResult<PaginatedList<AirportDto>>> GetAsync([FromQuery] PageParameters pageParameters)
        {
            return await _mediator.Send(new GetPaginatedAirportsQuery()
            {
                PageNumber = pageParameters.PageNumber,
                PageSize = pageParameters.PageSize
            });
        }

        /// <summary>
        /// sync airports data
        /// </summary>
        /// <returns></returns>
        [HttpPost("SyncAirports", Name = "SyncAirports")]
        public async Task<IActionResult?> SyncAirports()
        {
            await _mediator.Send(new SyncAirportsCommand());

            return NoContent();
        }
    }
}