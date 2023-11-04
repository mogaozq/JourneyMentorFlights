using JourneyMentorFlights.Application.Services;
using JourneyMentorFlights.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JourneyMentorFlights.Infrastructure.Persistance
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Flight> Flights { get; set; }
        public DbSet<Flight> Airports { get; set; }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken) => SaveChangesAsync(cancellationToken);
    }
}
