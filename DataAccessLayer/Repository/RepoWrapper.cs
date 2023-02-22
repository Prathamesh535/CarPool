using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{

    public class RepoWrapper: IRepoWrapper
    {
        private readonly CarPoolContext _CarPoolContext;
        private IOfferRideRepository OfferRideRepository;
        private ILocationRepository LocationRepository;
        private IBookRideRepository BookRideRepository;
        public RepoWrapper(CarPoolContext carPoolContext) 
        {
            _CarPoolContext = carPoolContext;
        }

        public IOfferRideRepository _OfferRideRepository
        { get 
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
                    BookRideRepository=new BookRideRepository(_CarPoolContext);
                }
                return BookRideRepository;
            }
        }
    }
}
