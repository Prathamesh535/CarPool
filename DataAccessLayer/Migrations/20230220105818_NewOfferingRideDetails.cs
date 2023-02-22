using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class NewOfferingRideDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"create view OfferingRideDetails as SELECT dbo.Stops.StopId, dbo.Stops.StopOfferId ,dbo.Account.UserName, dbo.OfferRide.TotalSeatsAvailable, dbo.OfferRide.OfferTiming, dbo.OfferRide.OfferDate, dbo.OfferRide.[From], dbo.OfferRide.[To], dbo.OfferRide.Price, dbo.Stops.StopNumber, 
             dbo.Locations.LocationName
                FROM   dbo.Account INNER JOIN
             dbo.OfferRide ON dbo.Account.AccountId = dbo.OfferRide.AccountId INNER JOIN
             dbo.Stops ON dbo.OfferRide.OfferingId = dbo.Stops.StopOfferId INNER JOIN
             dbo.Locations ON dbo.Stops.LocationId = dbo.Locations.LocationId;");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"drop view OfferingRideDetails");
        }
    }
}
