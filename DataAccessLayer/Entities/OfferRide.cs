using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class OfferRide
    {
        public int OfferingId { get; set; }//PK
        public string From { get; set; }
        public string To { get; set; }
        public int TotalSeats { get; set; }
        public int AvailableSeats { get; set; }
        public string OfferTiming { get; set; }
        public string OfferDate { get; set; }
        public int Price { get; set; }
        public List<Stops> Stops { get; set; }
        public List<BookRide>? BookRide { get; set; }
        public int AccountId { get; set; }//FK

        public Account Account; 
    }
}
;