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
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            builder.HasKey(e => e.FlightNumber);

            builder.HasOne(e => e.ArrivalAirport)
                .WithMany(a => a.ArivalFlights)
                .HasForeignKey(f => f.ArrivalAirportId);

            builder.HasOne(e => e.DepartureAirport)
                .WithMany(a => a.DepartureFlights)
                .HasForeignKey(f => f.DepartureAirportId);

            builder.OwnsOne(f => f.Airline);
            builder.OwnsOne(f => f.Live);
        }
    }
}
