﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class NewCarPool : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    AccountId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.AccountId);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationId);
                });

            migrationBuilder.CreateTable(
                name: "OfferRide",
                columns: table => new
                {
                    AccountId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OfferingId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    From = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    To = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalSeatsAvailable = table.Column<int>(type: "int", nullable: false),
                    SeatsAvailable = table.Column<int>(type: "int", nullable: false),
                    OfferTiming = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OfferDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferRide", x => x.OfferingId);
                    table.ForeignKey(
                        name: "FK_OfferRide_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookRide",
                columns: table => new
                {
                    AccountId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BookingId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OfferBookingId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    From = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    To = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Charges = table.Column<double>(type: "float", nullable: false),
                    BookingDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookTiming = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfSeatsBooked = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookRide", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_BookRide_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_BookRide_OfferRide_OfferBookingId",
                        column: x => x.OfferBookingId,
                        principalTable: "OfferRide",
                        principalColumn: "OfferingId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Stops",
                columns: table => new
                {
                    StopOfferId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StopId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LocationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StopNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stops", x => x.StopId);
                    table.ForeignKey(
                        name: "FK_Stops_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Stops_OfferRide_StopOfferId",
                        column: x => x.StopOfferId,
                        principalTable: "OfferRide",
                        principalColumn: "OfferingId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookRide_AccountId",
                table: "BookRide",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_BookRide_OfferBookingId",
                table: "BookRide",
                column: "OfferBookingId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferRide_AccountId",
                table: "OfferRide",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Stops_LocationId",
                table: "Stops",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Stops_StopOfferId",
                table: "Stops",
                column: "StopOfferId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookRide");

            migrationBuilder.DropTable(
                name: "Stops");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "OfferRide");

            migrationBuilder.DropTable(
                name: "Account");
        }
    }
}
