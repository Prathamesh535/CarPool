using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer;
using Entities;
using BusinessLayer;
using Models;
using Microsoft.AspNetCore.Authorization;

namespace CarPool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OfferRidesController : ControllerBase
    {
        private readonly CarPoolContext _context;
        public IRepoWrapper _RepoWrapper;
        public OfferRidesController(IRepoWrapper repoWrapper)
        {
            _RepoWrapper = repoWrapper;
        }
        OfferRideServices offerRideServices = new OfferRideServices();
        LocationServices locationServices = new LocationServices();
        // GET: api/OfferRides
        [HttpGet]
        public Task<ActionResult<IEnumerable<OfferRide>>> GetOfferRide()
        {
            return _RepoWrapper._OfferRideRepository.GetAll();;
        }
        [HttpPost]
        public async Task<ActionResult<OfferingRides>> PostOfferRide(OfferingRides offerRide)
        {
            OfferRide newOfferRide = offerRideServices.AddOfferRides(offerRide);
            List<Location> locations = locationServices.AddLocation(offerRide);
            foreach (var location in locations)
            {
                if (_RepoWrapper._LocationRepository.GetOne(x=>x.LocationName==location.LocationName && x.LocationId==location.LocationId) == null)
                { 
                   await _RepoWrapper._LocationRepository.Add(location);
                }
            }
            await _RepoWrapper._OfferRideRepository.Add(newOfferRide);
            return CreatedAtAction("GetOfferRide", new { id = offerRide.OfferingId }, offerRide);
        }
    }
}
