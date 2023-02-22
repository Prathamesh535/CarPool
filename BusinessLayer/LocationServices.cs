using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Models;

namespace BusinessLayer
{
    public class LocationServices
    {

        public List<Location> AddLocation(OfferingRides offerRideLocation)
        {
            List<Location> locationList = new List<Location>();
            foreach (var location in offerRideLocation.Destinations)
            {
                Location locations = new Location();
                locations.LocationId = location.StopName.Substring(0, 3);
                locations.LocationName = location.StopName;
                locationList.Add(locations);
            }
            locationList.Add(new Location() { LocationId = offerRideLocation.From.Substring(0, 3), LocationName = offerRideLocation.From });
            locationList.Add(new Location() { LocationId = offerRideLocation.To.Substring(0, 3), LocationName = offerRideLocation.To });
            return locationList;
        }
    }
}
