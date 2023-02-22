using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class OfferingRides
    {
        public string OfferingId { get; set; }//PK
        public string From { get; set; }
        public string To { get; set; }
        public int TotalSeatsAvailable { get; set; }
        public int SeatsAvailable { get; set; }
        public string OfferTiming { get; set; }
        public string OfferDate { get; set; }
        public double Price { get; set; }
        public List<Destination> Destinations { get; set; }
        public string AccountId { get; set; }//FK

    }
}
;