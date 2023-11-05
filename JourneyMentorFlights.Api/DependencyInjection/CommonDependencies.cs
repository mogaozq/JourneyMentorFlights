using JourneyMentorFlights.Application;
using System.Reflection;

namespace JourneyMentorFlights.Api.DependencyInjection
{
    public static class CommonDependencies
    {
        public static void AddCommon(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient();
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssemblyContaining(typeof(ApplicationAssemblyClass));
            });
            services.AddAutoMapper(typeof(ApplicationAssemblyClass).Assembly);
        }
    }
}
