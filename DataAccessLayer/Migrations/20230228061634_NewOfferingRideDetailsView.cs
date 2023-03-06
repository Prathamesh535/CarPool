using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class NewOfferingRideDetailsView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql(@"create view OfferingRideDetails as SELECT dbo.Account.AccountId, dbo.Account.UserName, dbo.OfferRide.OfferingId, dbo.OfferRide.[From], dbo.OfferRide.[To], dbo.OfferRide.AvailableSeats, dbo.OfferRide.OfferTiming, dbo.OfferRide.OfferDate, dbo.OfferRide.Price,dbo.Stops.StopId, dbo.Locations.LocationId, dbo.Locations.LocationName, 
             dbo.Stops.StopNumber
             FROM   dbo.OfferRide INNER JOIN
             dbo.Stops ON dbo.OfferRide.OfferingId = dbo.Stops.StopOfferId INNER JOIN
             dbo.Locations ON dbo.Stops.LocationId = dbo.Locations.LocationId INNER JOIN
             dbo.Account ON dbo.OfferRide.AccountId = dbo.Account.AccountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"drop table OfferingRideDetails");
        }
    }
}
