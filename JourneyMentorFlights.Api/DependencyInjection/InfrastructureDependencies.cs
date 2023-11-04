
using JourneyMentorFlights.Application.Services;
using JourneyMentorFlights.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace JourneyMentorFlights.Api.DependencyInjection
{
    public static class InfrastructureDependencies
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options=>
            {
                options.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]);
            });


        }
    }
}
