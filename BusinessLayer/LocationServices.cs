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
        private IRepoWrapper _RepoWrapper;
        public LocationServices(IRepoWrapper repoWrapper)
        { 
            _RepoWrapper = repoWrapper;
        }
        public async Task AddLocation(OfferingRides offerRideLocation)
        {
            List<Location> locationList = new List<Location>();
            foreach (var location in offerRideLocation.Destinations)
            {
                Location locations = new Location();
                locations.LocationName = location.StopName;
                locationList.Add(locations);
            }
            locationList.Add(new Location() {  LocationName = offerRideLocation.From });
            locationList.Add(new Location() {  LocationName = offerRideLocation.To });
            foreach (var location in locationList)
            {
                if (_RepoWrapper._LocationRepository.GetOne(x => x.LocationName == location.LocationName) == null)
                {
                    await _RepoWrapper._LocationRepository.Add(location);
                }
            }
        }
    }
}
