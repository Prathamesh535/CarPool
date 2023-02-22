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
        private readonly CarPoolContext _context;

        public OfferingRideDetailsController(CarPoolContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OfferingRideDetails>>> GetAccount()
        {
            if (_context.OfferingRideDetails == null)
            {
                return NotFound();
            }
            return await _context.OfferingRideDetails.ToListAsync();
        }
    }
}
