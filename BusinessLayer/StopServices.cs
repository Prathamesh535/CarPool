using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DataAccessLayer;
using Models;

namespace BusinessLayer
{
    public class StopServices
    {
        public Stops AddStopDetailsFromOfferRide(OfferingRides offerRide)
        {
            Stops stop = new Stops();
            stop.StopId = offerRide.From+offerRide.OfferingId;
            stop.StopNumber = 0;
            stop.StopOfferId = offerRide.OfferingId;
            stop.LocationId = offerRide.From.Substring(0, 3);
            return stop;
        }
        public Stops AddStopDetailsToOfferRide(OfferingRides offerRide,int StopNumber)
        {
            Stops stop = new Stops();
            stop.StopId = offerRide.To + offerRide.OfferingId;
            stop.StopNumber = StopNumber;
            stop.StopOfferId = offerRide.OfferingId;
            stop.LocationId = offerRide.To.Substring(0,3);
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
                stops.StopId = stop.StopName+offerRide.OfferingId;
                stops.StopNumber = StopNumber;
                stops.LocationId = stop.StopName.Substring(0, 3);
                stopList.Add(stops);
                StopNumber++;
            }
            Stops offerRideStopNumber = AddStopDetailsToOfferRide(offerRide,StopNumber);
            stopList.Add(offerRideStopNumber);
            return stopList;
        }
    }
}
