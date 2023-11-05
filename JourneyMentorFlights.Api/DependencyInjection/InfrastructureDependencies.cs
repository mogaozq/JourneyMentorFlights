
using JourneyMentorFlights.Application.Common.Interfaces;
using JourneyMentorFlights.Infrastructure.AviationStack;
using JourneyMentorFlights.Infrastructure.Persistance;
using JourneyMentorFlights.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace JourneyMentorFlights.Api.DependencyInjection
{
    public static class InfrastructureDependencies
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]);
            });

            services.AddTransient<IDataDownloaderService, DataDownloaderService>();
            services.AddTransient<AviationStackApiV1>();
        }
    }
}
