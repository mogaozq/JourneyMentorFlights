using JourneyMentorFlights.Application.Common.Interfaces;
using JourneyMentorFlights.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace JourneyMentorFlights.Api
{
    public static class AppInitilizer
    {
        public static void MigrateDatabase(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            try
            {
                var services = scope.ServiceProvider;

                var context = services.GetRequiredService<ApplicationDbContext>();
                if (context.Database.IsRelational())
                {
                    context.Database.Migrate();
                }

            }
            catch (Exception ex)
            {
                var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

                logger.LogError(ex, "An error occured while migrating or seeding the database");

                throw;
            }
        }
    }
}
