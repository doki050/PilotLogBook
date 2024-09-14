﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240914071837_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("Domain.Model.LogBook", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AirplaneType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Arrival")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<TimeOnly>("ArrivalTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("CallSign")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Departure")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<TimeOnly>("DepartureTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<TimeOnly>("DualTime")
                        .HasColumnType("TEXT");

                    b.Property<TimeOnly>("InstructorTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("NightLanding")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NightTakeoff")
                        .HasColumnType("INTEGER");

                    b.Property<TimeOnly>("PicTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("PilotName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<TimeOnly>("TotalFlightTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("VfrLanding")
                        .HasColumnType("INTEGER");

                    b.Property<int>("VfrTakeoff")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("LogBooks");
                });
#pragma warning restore 612, 618
        }
    }
}
