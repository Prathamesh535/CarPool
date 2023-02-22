using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Models;
namespace DataAccessLayer
{
    public class CarPoolContext:DbContext
    {
        public CarPoolContext(DbContextOptions<CarPoolContext> options) : base(options)
        {

        }
        public CarPoolContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=CarPool");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .HasKey(key => key.AccountId);
            modelBuilder.Entity<Account>()
                .Property(key => key.AccountId)
                .HasColumnOrder(0)
                .ValueGeneratedNever();
            modelBuilder.Entity<OfferRide>()
                .HasKey(key => key.OfferingId);
            modelBuilder.Entity<OfferRide>()
                .Property(key => key.OfferingId)
                .HasColumnOrder(1)
                .ValueGeneratedNever();
            modelBuilder.Entity<OfferRide>()
                .HasOne(x => x.Account)
                .WithMany(y => y.OfferRide)
                .HasForeignKey(x => x.AccountId)
                .HasPrincipalKey(y => y.AccountId);
            modelBuilder.Entity<OfferRide>()
                .Property(key => key.AccountId)
                .HasColumnOrder(0);
            modelBuilder.Entity<Stops>()
                .HasKey(key => key.StopId);
            modelBuilder.Entity<Stops>()
                .Property(x => x.StopId)
                .HasColumnOrder(1)
                .ValueGeneratedNever();
            modelBuilder.Entity<Stops>()
                .Property(x => x.StopOfferId)
                .HasColumnOrder(0);
            modelBuilder.Entity<Stops>()
                .HasOne(x => x.OfferRide)
                .WithMany(y => y.Stops)
                .HasForeignKey(x => x.StopOfferId)
                .HasPrincipalKey(y => y.OfferingId);
            modelBuilder.Entity<Stops>()
                .HasOne(x => x.Location)
                .WithMany(y => y.Stops)
                .HasForeignKey(y=>y.LocationId)
                .HasPrincipalKey(x=>x.LocationId);
            modelBuilder.Entity<BookRide>()
                .HasKey(x => x.BookingId);
            modelBuilder.Entity<BookRide>()
                .HasOne(x => x.Account)
                .WithMany(y => y.BookRide)
                .HasForeignKey(x => x.AccountId)
                .HasPrincipalKey(y => y.AccountId);
            modelBuilder.Entity<BookRide>()
                .HasOne(x => x.OfferRide)
                .WithMany(y => y.BookRide)
                .HasForeignKey(x => x.OfferBookingId)
                .HasPrincipalKey(x => x.OfferingId);
            modelBuilder.Entity<BookRide>()
                .Property(x => x.AccountId)
                .HasColumnOrder(0);
            modelBuilder.Entity<BookRide>()
                .Property(x => x.BookingId)
                .HasColumnOrder(1)
                .ValueGeneratedNever();
            modelBuilder.Entity<Location>()
                .HasKey(x => x.LocationId);
            modelBuilder.Entity<Location>()
                .Property(x => x.LocationId)
                .ValueGeneratedNever();
            modelBuilder.Entity<OfferingRideDetails>()
                .HasKey(x => x.StopId);
            modelBuilder.Entity<OfferingRideDetails>()
                .Property(x => x.StopId)
                .ValueGeneratedNever();
            modelBuilder.Entity<OfferingRides>()
                .HasKey(x => x.OfferingId);
            modelBuilder.Entity<Destination>()
                .HasKey(x => x.StopId);

        }
        public DbSet<Account> Account { get; set; }
        public DbSet<OfferRide> OfferRide { get; set; }
        public DbSet<BookRide> BookRide { get; set; }
        public DbSet<Stops> Stops { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<OfferingRideDetails> OfferingRideDetails { get; set; }
        public DbSet<OfferingRides> OfferingRides { get; set; }
        public DbSet<Destination> Destinations { get; set; }
    }
}
