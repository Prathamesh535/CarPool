using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Models;
using DataAccessLayer;

namespace BusinessLayer
{
    public class StopServices
    {
        private IRepoWrapper _RepoWrapper;
        public StopServices(IRepoWrapper repoWrapper) 
        {
            _RepoWrapper = repoWrapper;
        }         
        public Stops AddStopDetailsFromOfferRide(OfferingRides offerRide)
        {
            Stops stop = new Stops();
            stop.StopNumber = 0;
            stop.StopOfferId = offerRide.OfferingId;
            var location = _RepoWrapper._LocationRepository.GetOne(x => x.LocationName == offerRide.From);
            stop.LocationId = location.LocationId;
            return stop;
        }
        public Stops AddStopDetailsToOfferRide(OfferingRides offerRide,int StopNumber)
        {
            Stops stop = new Stops();
            stop.StopNumber = StopNumber;
            stop.StopOfferId = offerRide.OfferingId;
            var location = _RepoWrapper._LocationRepository.GetOne(x => x.LocationName == offerRide.To);
            stop.LocationId = location.LocationId;
            return stop;
        }
        public List<Stops> AddStops(OfferingRides offerRide)
        {
            List<Stops> stopList = new List<Stops>();
            Stops offerRideFromStop = AddStopDetailsFromOfferRide(offerRide);
            stopList.Add(offerRideFromStop);
            int StopNumber = 1;
            foreach(var stop in offerRide.Destinations)
            {
                Stops stops = new Stops();
                stops.StopNumber = StopNumber;
                stopList.Add(stops);
                var location = _RepoWrapper._LocationRepository.GetOne(x => x.LocationName == stop.StopName);
                stops.LocationId = location.LocationId;
                StopNumber++;
            }
            Stops offerRideStopNumber = AddStopDetailsToOfferRide(offerRide,StopNumber);
            stopList.Add(offerRideStopNumber);
            return stopList;
        }
    }
}
