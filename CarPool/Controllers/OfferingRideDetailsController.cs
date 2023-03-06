using BusinessLayer;
using DataAccessLayer;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarPool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferingRideDetailsController : ControllerBase
    {
        private IRepoWrapper _RepoWrapper;
        public OfferingRideDetailsServices offeringRideDetailsServices;
        public OfferingRideDetailsController(IRepoWrapper repoWrapper)
        {
            _RepoWrapper= repoWrapper;
            offeringRideDetailsServices = new OfferingRideDetailsServices(_RepoWrapper);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OfferingRideDetails>>> GetAccount()
        {

            return await offeringRideDetailsServices.GetOfferingRideDetails();
        }
    }
}
