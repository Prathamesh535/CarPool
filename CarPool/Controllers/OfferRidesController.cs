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
using AutoMapper;
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
        public IMapper _Mapper;
        public OfferRideServices offerRideServices ;
        public OfferRidesController(IRepoWrapper repoWrapper, IMapper mapper)
        {
            _RepoWrapper = repoWrapper;
            _Mapper = mapper;
            offerRideServices = new OfferRideServices(_RepoWrapper,_Mapper);
        }
        [HttpGet]
        public Task<ActionResult<IEnumerable<OfferRide>>> GetOfferRide()
        {
            return offerRideServices.GetOfferRide();
        }
        [HttpPost]
        public async Task<ActionResult<OfferingRides>> PostOfferRide(OfferingRides offerRide)
        {
            await offerRideServices.AddOfferRides(offerRide);
            return CreatedAtAction("GetOfferRide", new { id = offerRide.OfferingId }, offerRide);
        }
    }
}
