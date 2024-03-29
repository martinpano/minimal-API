﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MinimalAPI.Demo.EF.DataAccess;

#nullable disable

namespace MinimalAPI.Demo.EF.Migrations
{
    [DbContext(typeof(WorldCupDbContext))]
    [Migration("20221123233039_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MinimalAPI.Demo.EF.DataAccess.Models.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Group")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Teams");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Group = "A",
                            Name = "Qatar"
                        },
                        new
                        {
                            Id = 2,
                            Group = "A",
                            Name = "Ecuador"
                        },
                        new
                        {
                            Id = 3,
                            Group = "A",
                            Name = "Netherlands"
                        },
                        new
                        {
                            Id = 4,
                            Group = "A",
                            Name = "Senegal"
                        },
                        new
                        {
                            Id = 5,
                            Group = "B",
                            Name = "England"
                        },
                        new
                        {
                            Id = 6,
                            Group = "B",
                            Name = "USA"
                        },
                        new
                        {
                            Id = 7,
                            Group = "B",
                            Name = "Wales"
                        },
                        new
                        {
                            Id = 8,
                            Group = "B",
                            Name = "Iran"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
