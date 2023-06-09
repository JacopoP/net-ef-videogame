﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using net_ef_videogame;

#nullable disable

namespace net_ef_videogame.Migrations
{
    [DbContext(typeof(VideogameContext))]
    partial class VideogameContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("net_ef_videogame.Software_house", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tax_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("software_houses");
                });

            modelBuilder.Entity("net_ef_videogame.Videogame", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Overview")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Release_date")
                        .HasColumnType("datetime2");

                    b.Property<long>("Software_houseID")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("Software_houseID");

                    b.ToTable("videogames");
                });

            modelBuilder.Entity("net_ef_videogame.Videogame", b =>
                {
                    b.HasOne("net_ef_videogame.Software_house", "Software_house")
                        .WithMany("Videogames")
                        .HasForeignKey("Software_houseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Software_house");
                });

            modelBuilder.Entity("net_ef_videogame.Software_house", b =>
                {
                    b.Navigation("Videogames");
                });
#pragma warning restore 612, 618
        }
    }
}
