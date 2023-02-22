using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class BookRideRepository : Repository<BookRide>, IBookRideRepository
    {
        public BookRideRepository(CarPoolContext carPoolContext) : base(carPoolContext) { }

    }
}
