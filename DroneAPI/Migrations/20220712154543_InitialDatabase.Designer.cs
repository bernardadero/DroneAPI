﻿// <auto-generated />
using DroneAPI.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DroneAPI.Migrations
{
    [DbContext(typeof(DroneAPIContext))]
    [Migration("20220712154543_InitialDatabase")]
    partial class InitialDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DroneAPI.Models.Drone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("BatteryCapacity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("SerialNumber")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("SerialNumber");

                    b.Property<decimal>("WeightLimit")
                        .HasColumnType("decimal")
                        .HasColumnName("WeightLimit");

                    b.Property<int>("model")
                        .HasColumnType("int");

                    b.Property<int>("state")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Drone");
                });
#pragma warning restore 612, 618
        }
    }
}
