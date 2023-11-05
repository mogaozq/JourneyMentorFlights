
using JourneyMentorFlights.Application.Common.Interfaces;
using JourneyMentorFlights.Infrastructure.AviationStack;
using JourneyMentorFlights.Infrastructure.AviationStack.Options;
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
                //options.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]);

                var connectionString = configuration["ConnectionStrings:DefaultConnection"];
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });

            services.AddTransient<IDataSyncronizerService, DataSyncronizerService>();
            services.AddTransient<AviationStackApiV1>();
            services.Configure<AviationStackApiOptions>(configuration.GetSection(nameof(AviationStackApiOptions)));
        }
    }
}
