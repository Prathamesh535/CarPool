using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer;
using Entities;

namespace CarPool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookRidesController : ControllerBase
    {
        private readonly IRepoWrapper _RepoWrapper;
        public BookRidesController(IRepoWrapper repoWrapper)
        {
            _RepoWrapper = repoWrapper ;
        }

        [HttpGet]
        public  Task<ActionResult<IEnumerable<BookRide>>> GetBookRide()
        {
            return  _RepoWrapper._BookRideRepository.GetAll();
        }

        [HttpPost]
        public async Task<ActionResult<BookRide>> PostBookRide(BookRide bookRide)
        {
            var Seats=_RepoWrapper._OfferRideRepository.GetOne(x=>x.OfferingId== bookRide.OfferBookingId);
            Seats.SeatsAvailable -= bookRide.NumberOfSeatsBooked;
            await _RepoWrapper._BookRideRepository.Add(bookRide);
            return CreatedAtAction("GetBookRide", new { id = bookRide.BookingId }, bookRide);
        }
    }
}
