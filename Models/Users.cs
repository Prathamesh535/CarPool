using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Users
    {
        public int AccountId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        List<BookingRides> BookRide { get; set;}
        List<OfferingRides> OfferRide { get; set;}
    }
}
