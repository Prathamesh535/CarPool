using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Account
    {
        public string AccountId { get; set; }//PK
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<BookRide>? BookRide { get; set;}
        public List<OfferRide>? OfferRide { get; set;}
    }
}
