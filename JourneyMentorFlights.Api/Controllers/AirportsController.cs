using JourneyMentorFlights.Application.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JourneyMentorFlights.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AirportsController : ControllerBase
    {
        [HttpGet(Name = "GetAirports")]
        public async Task<IActionResult?> GetAsync()
        {
            throw new NotImplementedException();
        }

        [HttpPost("SyncAirports", Name = "SyncAirports")]
        public async Task<IActionResult?> SyncAirports([FromServices] IDataDownloaderService dataDownloaderService)
        {
            await dataDownloaderService.DownloadAndSaveAirports();
            return NoContent();
        }
    }
}