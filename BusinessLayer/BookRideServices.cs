using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer;

namespace BusinessLayer
{
    public class BookRideServices
    {
        private readonly IRepoWrapper _RepoWrapper;
        public BookRideServices(IRepoWrapper repoWrapper) 
        {
            _RepoWrapper= repoWrapper;
        }
        public async Task AddBookRide(BookRide bookRide)
        {
            var Seats = _RepoWrapper._OfferRideRepository.GetOne(x => x.OfferingId == bookRide.OfferBookingId);
            Seats.AvailableSeats -= bookRide.NumberOfSeatsBooked;
            await _RepoWrapper._BookRideRepository.Add(bookRide);
        }
        public Task<ActionResult<IEnumerable<BookRide>>> GetBookRide()
        {
            return _RepoWrapper._BookRideRepository.GetAll();
        }

    }
}
