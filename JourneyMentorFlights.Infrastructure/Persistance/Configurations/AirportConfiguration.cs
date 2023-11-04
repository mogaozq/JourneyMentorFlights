using JourneyMentorFlights.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyMentorFlights.Infrastructure.Persistance.Configurations
{
    public class AirportConfiguration : IEntityTypeConfiguration<Airport>
    {
        public void Configure(EntityTypeBuilder<Airport> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasAlternateKey(e => e.IataCode);

            builder.HasAlternateKey(e => e.IcaoCode);
        }
    }
}
