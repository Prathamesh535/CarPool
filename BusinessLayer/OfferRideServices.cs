using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using DataAccessLayer;
using Models;

namespace BusinessLayer
{
    public class OfferRideServices
    {
        StopServices stopServices = new StopServices();
        public OfferRide AddOfferRides(OfferingRides offerRide)
        {
            OfferRide offerRide1offer = new OfferRide();
            offerRide1offer.From = offerRide.From;
            offerRide1offer.To = offerRide.To;
            offerRide1offer.AccountId = offerRide.AccountId;
            offerRide1offer.OfferingId = offerRide.OfferingId;
            offerRide1offer.OfferDate = offerRide.OfferDate;
            offerRide1offer.OfferTiming = offerRide.OfferTiming;
            offerRide1offer.Stops = stopServices.AddStops(offerRide);
            offerRide1offer.TotalSeatsAvailable = offerRide.TotalSeatsAvailable;
            offerRide1offer.SeatsAvailable = offerRide.SeatsAvailable;
            offerRide1offer.Price = offerRide.Price;
            return offerRide1offer;

        }
    }
}
