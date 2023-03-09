using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataAccessLayer;
using Entities;
using Models;

namespace BusinessLayer
{
    public class OfferRideResolver : IValueResolver<RequiredModel, OfferRide, List<Stops>>
    {
        List<Stops> IValueResolver<RequiredModel, OfferRide, List<Stops>>.Resolve(RequiredModel source, OfferRide destination, List<Stops> destMember, ResolutionContext context)
        {
            List<Stops> stopList = new List<Stops>();
            Stops stopFrom = new Stops();
            stopFrom.StopNumber = 0;
            stopFrom.StopOfferId = source.OfferingRide.OfferingId;
            stopFrom.LocationId = source.LocationId[0];
            stopList.Add(stopFrom);
            int StopNumber = 1;
            foreach(var stop in source.OfferingRide.Destinations)
            {
                Stops stops = new Stops();
                stops.StopNumber = StopNumber;
                stops.LocationId = source.LocationId[StopNumber];
                stops.StopOfferId = source.OfferingRide.OfferingId;
                StopNumber++;
                stopList.Add(stops);
            }
            Stops stopTo = new Stops();
            stopTo.StopNumber = StopNumber;
            stopTo.StopOfferId = source.OfferingRide.OfferingId;
            stopTo.LocationId = source.LocationId[StopNumber];
            stopList.Add(stopTo);
            return stopList;
        }
    }
}
