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
        public IMapper _Mapper { get; set; }
        public LocationServices locationServices { get; set; }
        public OfferRideServices(IRepoWrapper repoWrapper,IMapper mapper)
        { 
            _RepoWrapper = repoWrapper;
            _Mapper = mapper;
            locationServices = new LocationServices(_RepoWrapper);
        }
        public async Task AddOfferRides(OfferingRides offerRide)
        {
            await locationServices.AddLocation(offerRide);
            RequiredModel requiredModel = AssignProperties(offerRide);
            var offerRide1 = _Mapper.Map<OfferRide>(requiredModel);
            await _RepoWrapper._OfferRideRepository.Add(offerRide1);
        }
        public Task<ActionResult<IEnumerable<OfferRide>>> GetOfferRide()
        {
            return _RepoWrapper._OfferRideRepository.GetAll();
        }
        public RequiredModel AssignProperties(OfferingRides offeringRides)
        {
            List<int> locationId= new List<int>();
            RequiredModel requiredModel = new RequiredModel();
            requiredModel.OfferingRide = offeringRides;
            locationId.Add(_RepoWrapper._LocationRepository.GetOne(x => x.LocationName == offeringRides.From).LocationId);
            foreach(var location in offeringRides.Destinations)
            {
                locationId.Add(_RepoWrapper._LocationRepository.GetOne(x => x.LocationName == location.StopName).LocationId);
            }
            locationId.Add(_RepoWrapper._LocationRepository.GetOne(x => x.LocationName == offeringRides.To).LocationId);
            requiredModel.LocationId = locationId;
            return requiredModel;
        }
    }
}
