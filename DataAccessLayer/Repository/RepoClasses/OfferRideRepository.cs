using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Models;
namespace DataAccessLayer
{
    public class OfferRideRepository : Repository<OfferRide>, IOfferRideRepository
    {
        public OfferRideRepository(CarPoolContext carPoolContext) : base(carPoolContext) { }

    }
}
