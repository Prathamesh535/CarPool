using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class OfferRide
    {
        public string OfferingId { get; set; }//PK
        public string From { get; set; }
        public string To { get; set; }
        public int TotalSeatsAvailable { get; set; }
        public int SeatsAvailable { get; set; }
        public string OfferTiming { get; set; }
        public string OfferDate { get; set; }
        public double Price { get; set; }
        public List<Stops> Stops { get; set; }
        public List<BookRide>? BookRide { get; set; }
        public string AccountId { get; set; }//FK

        public Account Account; 
    }
}
;