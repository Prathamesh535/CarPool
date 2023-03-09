using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entities;
using BusinessLayer;
using DataAccessLayer;
using Microsoft.AspNetCore.Authorization;

namespace CarPool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BookRidesController : ControllerBase
    {
        private readonly IRepoWrapper _RepoWrapper;
        public BookRideServices bookRideServices;
        public BookRidesController(IRepoWrapper repoWrapper)
        {
            _RepoWrapper = repoWrapper;
            bookRideServices = new BookRideServices(_RepoWrapper);
        }
        //BookRideServices b = new BookRideServices()
        [HttpGet]
        public  Task<ActionResult<IEnumerable<BookRide>>> GetBookRide()
        {
            return bookRideServices.GetBookRide();
        }

        [HttpPost]
        public async Task<ActionResult<BookRide>> PostBookRide(BookRide bookRide)
        {
            await bookRideServices.AddBookRide(bookRide); 
            return CreatedAtAction("GetBookRide", new { id = bookRide.BookingId }, bookRide);
        }
    }
}
