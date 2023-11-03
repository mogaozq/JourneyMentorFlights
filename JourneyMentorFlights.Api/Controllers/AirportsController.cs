using Microsoft.AspNetCore.Mvc;

namespace JourneyMentorFlights.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AirportsController : ControllerBase
    {

        private readonly ILogger<AirportsController> _logger;

        public AirportsController(ILogger<AirportsController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetAirports")]
        public IActionResult Get()
        {
            return null;
        }
    }
}