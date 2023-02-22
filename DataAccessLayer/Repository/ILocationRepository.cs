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
    public interface ILocationRepository
    {
        public Task Add(Location location);
        public Task<ActionResult<IEnumerable<Location>>> GetAll();
        public Location GetOne(Expression<Func<Location, bool>> predicate);
    }
}
