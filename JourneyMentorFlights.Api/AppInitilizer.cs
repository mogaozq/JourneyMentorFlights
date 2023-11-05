using JourneyMentorFlights.Application.Common.Interfaces;

namespace JourneyMentorFlights.Api
{
    public static class AppInitilizer
    {
        public static async Task InitilizeAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var dataDownloaderService = scope.ServiceProvider.GetRequiredService<IDataSyncronizerService>();

            //await dataDownloaderService.DownloadAndSaveAirports();
            //dataDownloaderService.DownloadAndSaveAirports();
        }
    }
}
