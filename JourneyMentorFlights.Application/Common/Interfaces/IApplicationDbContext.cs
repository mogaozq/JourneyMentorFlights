using JourneyMentorFlights.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyMentorFlights.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Airport> Airports { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
