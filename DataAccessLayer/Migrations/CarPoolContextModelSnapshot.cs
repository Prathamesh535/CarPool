﻿// <auto-generated />
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(CarPoolContext))]
    partial class CarPoolContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entities.Account", b =>
                {
                    b.Property<string>("AccountId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnOrder(0);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AccountId");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("Entities.BookRide", b =>
                {
                    b.Property<string>("BookingId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnOrder(1);

                    b.Property<string>("AccountId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnOrder(0);

                    b.Property<string>("BookTiming")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BookingDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Charges")
                        .HasColumnType("float");

                    b.Property<string>("From")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfSeatsBooked")
                        .HasColumnType("int");

                    b.Property<string>("OfferBookingId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("To")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookingId");

                    b.HasIndex("AccountId");

                    b.HasIndex("OfferBookingId");

                    b.ToTable("BookRide");
                });

            modelBuilder.Entity("Entities.Location", b =>
                {
                    b.Property<string>("LocationId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LocationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LocationId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Entities.OfferRide", b =>
                {
                    b.Property<string>("OfferingId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnOrder(1);

                    b.Property<string>("AccountId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnOrder(0);

                    b.Property<string>("From")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OfferDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OfferTiming")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("SeatsAvailable")
                        .HasColumnType("int");

                    b.Property<string>("To")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalSeatsAvailable")
                        .HasColumnType("int");

                    b.HasKey("OfferingId");

                    b.HasIndex("AccountId");

                    b.ToTable("OfferRide");
                });

            modelBuilder.Entity("Entities.Stops", b =>
                {
                    b.Property<string>("StopId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnOrder(1);

                    b.Property<string>("LocationId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("StopNumber")
                        .HasColumnType("int");

                    b.Property<string>("StopOfferId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnOrder(0);

                    b.HasKey("StopId");

                    b.HasIndex("LocationId");

                    b.HasIndex("StopOfferId");

                    b.ToTable("Stops");
                });

            modelBuilder.Entity("Entities.BookRide", b =>
                {
                    b.HasOne("Entities.Account", "Account")
                        .WithMany("BookRide")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.OfferRide", "OfferRide")
                        .WithMany("BookRide")
                        .HasForeignKey("OfferBookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("OfferRide");
                });

            modelBuilder.Entity("Entities.OfferRide", b =>
                {
                    b.HasOne("Entities.Account", "Account")
                        .WithMany("OfferRide")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("Entities.Stops", b =>
                {
                    b.HasOne("Entities.Location", "Location")
                        .WithMany("Stops")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.OfferRide", "OfferRide")
                        .WithMany("Stops")
                        .HasForeignKey("StopOfferId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");

                    b.Navigation("OfferRide");
                });

            modelBuilder.Entity("Entities.Account", b =>
                {
                    b.Navigation("BookRide");

                    b.Navigation("OfferRide");
                });

            modelBuilder.Entity("Entities.Location", b =>
                {
                    b.Navigation("Stops");
                });

            modelBuilder.Entity("Entities.OfferRide", b =>
                {
                    b.Navigation("BookRide");

                    b.Navigation("Stops");
                });
#pragma warning restore 612, 618
        }
    }
}
