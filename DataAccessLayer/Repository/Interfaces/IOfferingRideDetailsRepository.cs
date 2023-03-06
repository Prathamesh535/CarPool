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
    public interface IOfferingRideDetailsRepository
    {
        public Task Add(OfferingRideDetails offerRide);
        public Task<ActionResult<IEnumerable<OfferingRideDetails>>> GetAll();
        public OfferingRideDetails GetOne(Expression<Func<OfferingRideDetails, bool>> predicate);
    }
}
