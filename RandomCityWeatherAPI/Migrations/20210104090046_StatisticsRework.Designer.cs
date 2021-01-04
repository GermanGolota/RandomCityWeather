﻿// <auto-generated />
using DataAccessLibrary.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace RandomCityWeatherAPI.Migrations
{
    [DbContext(typeof(CityContext))]
    [Migration("20210104090046_StatisticsRework")]
    partial class StatisticsRework
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("DataAccessLibrary.DB.Entities.CityStatistics", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ChatId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CityId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Statistics");
                });

            modelBuilder.Entity("DataAccessLibrary.DB.Entity.City", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Latitude")
                        .HasPrecision(12, 8)
                        .HasColumnType("decimal(12,8)");

                    b.Property<decimal>("Longitude")
                        .HasPrecision(12, 8)
                        .HasColumnType("decimal(12,8)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("DataAccessLibrary.DB.Entities.CityStatistics", b =>
                {
                    b.HasOne("DataAccessLibrary.DB.Entity.City", null)
                        .WithMany("Statistics")
                        .HasForeignKey("CityId");
                });

            modelBuilder.Entity("DataAccessLibrary.DB.Entity.City", b =>
                {
                    b.Navigation("Statistics");
                });
#pragma warning restore 612, 618
        }
    }
}
