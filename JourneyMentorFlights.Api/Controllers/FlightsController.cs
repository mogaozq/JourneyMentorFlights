using Microsoft.AspNetCore.Mvc;

namespace JourneyMentorFlights.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FlightsController : ControllerBase
    {
        private readonly ILogger<FlightsController> _logger;

        public FlightsController(ILogger<FlightsController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetFlights")]
        public IActionResult Get()
        {
            return null;
        }
    }
}