using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class OfferingRides
    {
        public int OfferingId { get; set; }//PK
        public string From { get; set; }
        public string To { get; set; }
        public int TotalSeats { get; set; }
        public int AvailableSeats { get; set; }
        public string OfferTiming { get; set; }
        public string OfferDate { get; set; }
        public int Price { get; set; }
        public List<Destination> Destinations { get; set; }
        public int AccountId { get; set; }//FK

    }
}
;