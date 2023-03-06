using DataAccessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class LocationRepository : Repository<Location>, ILocationRepository
    {
        public LocationRepository(CarPoolContext carPoolContext) : base(carPoolContext) { }

    }
}
