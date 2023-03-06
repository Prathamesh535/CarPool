using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Models;
using AutoMapper;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;

namespace BusinessLayer
{
    public class OfferRideServices
    {
        public IRepoWrapper _RepoWrapper { get; set; }
        public StopServices stopServices { get; set; }
        public LocationServices locationServices { get; set; }
        public OfferRideServices(IRepoWrapper repoWrapper)
        { 
            _RepoWrapper = repoWrapper;
            stopServices = new StopServices(_RepoWrapper);
            locationServices = new LocationServices(_RepoWrapper);
        }
        public async Task AddOfferRides(OfferingRides offerRide)
        {
            await locationServices.AddLocation(offerRide);
            OfferRide offerRide1offer = new OfferRide();
            offerRide1offer.From = offerRide.From;
            offerRide1offer.To = offerRide.To;
            offerRide1offer.AccountId = offerRide.AccountId;
            offerRide1offer.OfferingId = offerRide.OfferingId;
            offerRide1offer.OfferDate = offerRide.OfferDate;
            offerRide1offer.OfferTiming = offerRide.OfferTiming;
            offerRide1offer.Stops = stopServices.AddStops(offerRide);
            offerRide1offer.TotalSeats = offerRide.TotalSeats;
            offerRide1offer.AvailableSeats = offerRide.AvailableSeats;
            offerRide1offer.Price = offerRide.Price;
            await _RepoWrapper._OfferRideRepository.Add(offerRide1offer);
        }
        public Task<ActionResult<IEnumerable<OfferRide>>> GetOfferRide()
        {
            return _RepoWrapper._OfferRideRepository.GetAll();
        }
    }
}
