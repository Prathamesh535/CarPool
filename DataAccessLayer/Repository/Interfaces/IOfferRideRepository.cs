using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IOfferRideRepository
    {
        public Task Add(OfferRide offerRide);
        public Task<ActionResult<IEnumerable<OfferRide>>> GetAll();
        public OfferRide GetOne(Expression<Func<OfferRide, bool>> predicate);
    }

}
