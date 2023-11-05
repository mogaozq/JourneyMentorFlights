using JourneyMentorFlights.Domain.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyMentorFlights.Infrastructure.Persistance.Configurations
{
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            builder.HasKey(f => f.Id);
            builder.OwnsOne(f => f.Arrival);
            builder.OwnsOne(f => f.Departure);
            builder.OwnsOne(f => f.Airline);
            builder.OwnsOne(f => f.FlightDetails)
                .OwnsOne(fd => fd.Codeshared);
            builder.OwnsOne(f => f.LiveDetails);
        }
    }
}
