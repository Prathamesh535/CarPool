using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entities;
using BusinessLayer;
using Models;
using Microsoft.AspNetCore.Authorization;
using DataAccessLayer;

namespace CarPool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OfferRidesController : ControllerBase
    {
        public IRepoWrapper _RepoWrapper;
        public OfferRideServices offerRideServices ;
        public OfferRidesController(IRepoWrapper repoWrapper)
        {
            _RepoWrapper = repoWrapper;
            offerRideServices = new OfferRideServices(_RepoWrapper);
        }
        [HttpGet]
        public Task<ActionResult<IEnumerable<OfferRide>>> GetOfferRide()
        {
            return offerRideServices.GetOfferRide();
        }
        [HttpPost]
        public async Task<ActionResult<OfferingRides>> PostOfferRide(OfferingRides offerRide)
        {
            offerRideServices.AddOfferRides(offerRide);
            return CreatedAtAction("GetOfferRide", new { id = offerRide.OfferingId }, offerRide);
        }
    }
}
