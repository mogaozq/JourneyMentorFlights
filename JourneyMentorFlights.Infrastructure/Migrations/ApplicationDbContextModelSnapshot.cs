﻿// <auto-generated />
using System;
using JourneyMentorFlights.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JourneyMentorFlights.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("JourneyMentorFlights.Domain.Entities.Airport", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("AirportName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CityIataCode")
                        .HasColumnType("longtext");

                    b.Property<string>("CountryIso2")
                        .HasColumnType("longtext");

                    b.Property<string>("CountryName")
                        .HasColumnType("longtext");

                    b.Property<string>("GeonameId")
                        .HasColumnType("longtext");

                    b.Property<string>("Gmt")
                        .HasColumnType("longtext");

                    b.Property<string>("IataCode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("IcaoCode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal?>("Latitude")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal?>("Longitude")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<string>("Timezone")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Airports");
                });

            modelBuilder.Entity("JourneyMentorFlights.Domain.Entities.Flight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("FlightDate")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("JourneyMentorFlights.Domain.Entities.Flight", b =>
                {
                    b.OwnsOne("JourneyMentorFlights.Domain.ValueObjects.Airline", "Airline", b1 =>
                        {
                            b1.Property<int>("FlightId")
                                .HasColumnType("int");

                            b1.Property<string>("Iata")
                                .HasColumnType("longtext");

                            b1.Property<string>("Icao")
                                .HasColumnType("longtext");

                            b1.Property<string>("Name")
                                .HasColumnType("longtext");

                            b1.HasKey("FlightId");

                            b1.ToTable("Flights");

                            b1.WithOwner()
                                .HasForeignKey("FlightId");
                        });

                    b.OwnsOne("JourneyMentorFlights.Domain.ValueObjects.ArrivalInfo", "Arrival", b1 =>
                        {
                            b1.Property<int>("FlightId")
                                .HasColumnType("int");

                            b1.Property<DateTime?>("Actual")
                                .HasColumnType("datetime(6)");

                            b1.Property<DateTime?>("ActualRunway")
                                .HasColumnType("datetime(6)");

                            b1.Property<string>("Airport")
                                .HasColumnType("longtext");

                            b1.Property<string>("Baggage")
                                .HasColumnType("longtext");

                            b1.Property<int?>("Delay")
                                .HasColumnType("int");

                            b1.Property<DateTime?>("Estimated")
                                .HasColumnType("datetime(6)");

                            b1.Property<DateTime?>("EstimatedRunway")
                                .HasColumnType("datetime(6)");

                            b1.Property<string>("Gate")
                                .HasColumnType("longtext");

                            b1.Property<string>("IATA")
                                .HasColumnType("longtext");

                            b1.Property<string>("ICAO")
                                .HasColumnType("longtext");

                            b1.Property<DateTime?>("Scheduled")
                                .HasColumnType("datetime(6)");

                            b1.Property<string>("Terminal")
                                .HasColumnType("longtext");

                            b1.Property<string>("Timezone")
                                .HasColumnType("longtext");

                            b1.HasKey("FlightId");

                            b1.ToTable("Flights");

                            b1.WithOwner()
                                .HasForeignKey("FlightId");
                        });

                    b.OwnsOne("JourneyMentorFlights.Domain.ValueObjects.DepartureInfo", "Departure", b1 =>
                        {
                            b1.Property<int>("FlightId")
                                .HasColumnType("int");

                            b1.Property<DateTime?>("Actual")
                                .HasColumnType("datetime(6)");

                            b1.Property<DateTime?>("ActualRunway")
                                .HasColumnType("datetime(6)");

                            b1.Property<string>("Airport")
                                .HasColumnType("longtext");

                            b1.Property<int?>("Delay")
                                .HasColumnType("int");

                            b1.Property<DateTime?>("Estimated")
                                .HasColumnType("datetime(6)");

                            b1.Property<DateTime?>("EstimatedRunway")
                                .HasColumnType("datetime(6)");

                            b1.Property<string>("Gate")
                                .HasColumnType("longtext");

                            b1.Property<string>("IATA")
                                .HasColumnType("longtext");

                            b1.Property<string>("ICAO")
                                .HasColumnType("longtext");

                            b1.Property<DateTime?>("Scheduled")
                                .HasColumnType("datetime(6)");

                            b1.Property<string>("Terminal")
                                .HasColumnType("longtext");

                            b1.Property<string>("Timezone")
                                .HasColumnType("longtext");

                            b1.HasKey("FlightId");

                            b1.ToTable("Flights");

                            b1.WithOwner()
                                .HasForeignKey("FlightId");
                        });

                    b.OwnsOne("JourneyMentorFlights.Domain.ValueObjects.FlightDetails", "FlightDetails", b1 =>
                        {
                            b1.Property<int>("FlightId")
                                .HasColumnType("int");

                            b1.Property<string>("Iata")
                                .HasColumnType("longtext");

                            b1.Property<string>("Icao")
                                .HasColumnType("longtext");

                            b1.Property<string>("Number")
                                .HasColumnType("longtext");

                            b1.HasKey("FlightId");

                            b1.ToTable("Flights");

                            b1.WithOwner()
                                .HasForeignKey("FlightId");

                            b1.OwnsOne("JourneyMentorFlights.Domain.ValueObjects.Codeshared", "Codeshared", b2 =>
                                {
                                    b2.Property<int>("FlightDetailsFlightId")
                                        .HasColumnType("int");

                                    b2.Property<string>("AirlineIata")
                                        .HasColumnType("longtext");

                                    b2.Property<string>("AirlineIcao")
                                        .HasColumnType("longtext");

                                    b2.Property<string>("AirlineName")
                                        .HasColumnType("longtext");

                                    b2.Property<string>("FlightIata")
                                        .HasColumnType("longtext");

                                    b2.Property<string>("FlightIcao")
                                        .HasColumnType("longtext");

                                    b2.Property<string>("FlightNumber")
                                        .HasColumnType("longtext");

                                    b2.HasKey("FlightDetailsFlightId");

                                    b2.ToTable("Flights");

                                    b2.WithOwner()
                                        .HasForeignKey("FlightDetailsFlightId");
                                });

                            b1.Navigation("Codeshared")
                                .IsRequired();
                        });

                    b.OwnsOne("JourneyMentorFlights.Domain.ValueObjects.FlightLiveDetails", "LiveDetails", b1 =>
                        {
                            b1.Property<int>("FlightId")
                                .HasColumnType("int");

                            b1.Property<decimal?>("Altitude")
                                .HasColumnType("decimal(65,30)");

                            b1.Property<decimal?>("Direction")
                                .HasColumnType("decimal(65,30)");

                            b1.Property<bool?>("IsGround")
                                .HasColumnType("tinyint(1)");

                            b1.Property<decimal?>("Latitude")
                                .HasColumnType("decimal(65,30)");

                            b1.Property<decimal?>("Longitude")
                                .HasColumnType("decimal(65,30)");

                            b1.Property<decimal?>("SpeedHorizontal")
                                .HasColumnType("decimal(65,30)");

                            b1.Property<decimal?>("SpeedVertical")
                                .HasColumnType("decimal(65,30)");

                            b1.Property<DateTime?>("Updated")
                                .HasColumnType("datetime(6)");

                            b1.HasKey("FlightId");

                            b1.ToTable("Flights");

                            b1.WithOwner()
                                .HasForeignKey("FlightId");
                        });

                    b.Navigation("Airline")
                        .IsRequired();

                    b.Navigation("Arrival")
                        .IsRequired();

                    b.Navigation("Departure")
                        .IsRequired();

                    b.Navigation("FlightDetails")
                        .IsRequired();

                    b.Navigation("LiveDetails")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}