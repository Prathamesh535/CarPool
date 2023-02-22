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
    public interface IBookRideRepository
    {
        public Task Add(BookRide bookRide);
        public Task<ActionResult<IEnumerable<BookRide>>> GetAll();
        public BookRide GetOne(Expression<Func<BookRide, bool>> predicate);
    }
}
