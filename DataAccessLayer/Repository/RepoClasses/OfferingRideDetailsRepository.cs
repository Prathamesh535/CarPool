using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DataAccessLayer
{
    public class OfferingRideDetailsRepository:Repository<OfferingRideDetails>,IOfferingRideDetailsRepository
    {
        public OfferingRideDetailsRepository(CarPoolContext carPoolContext) : base(carPoolContext) { }
    }
}
