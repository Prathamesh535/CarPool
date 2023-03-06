using DataAccessLayer;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{

    public class RepoWrapper : IRepoWrapper
    {
        private readonly CarPoolContext _CarPoolContext;
        private IOfferRideRepository OfferRideRepository;
        private ILocationRepository LocationRepository;
        private IBookRideRepository BookRideRepository;
        private IAccountRepository AccountRepository;
        private IOfferingRideDetailsRepository OfferingRideDetailsRepository;
        public RepoWrapper(CarPoolContext carPoolContext)
        {
            _CarPoolContext = carPoolContext;
        }
        public IAccountRepository _AccountRepository
        {
            get
            {
                if (AccountRepository == null)
                {
                    AccountRepository = new AccountRepository(_CarPoolContext);
                }
                return AccountRepository;
            }
        }
        public IOfferRideRepository _OfferRideRepository
        {
            get
            {
                if (OfferRideRepository == null)
                {
                    OfferRideRepository = new OfferRideRepository(_CarPoolContext);
                }
                return OfferRideRepository;

            }
        }
        public ILocationRepository _LocationRepository
        {
            get
            {
                if (LocationRepository == null)
                {
                    LocationRepository = new LocationRepository(_CarPoolContext);
                }
                return LocationRepository;
            }
        }
        public IBookRideRepository _BookRideRepository
        {
            get
            {
                if (BookRideRepository == null)
                {
                    BookRideRepository = new BookRideRepository(_CarPoolContext);
                }
                return BookRideRepository;
            }
        }
        public IOfferingRideDetailsRepository _OfferingRideDetailsRepository
        {
            get
            {
                if (OfferingRideDetailsRepository == null)
                {
                    OfferingRideDetailsRepository = new OfferingRideDetailsRepository(_CarPoolContext);
                }
                return OfferingRideDetailsRepository;
            }
        }
    }
}
