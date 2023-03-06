using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class OfferingRideDetails
    {
        public int AccountId { get; set; }
        public string UserName { get; set; }
        public int OfferingId { get; set; }
        public string To { get; set; }  
        public string From { get; set; }
        public int AvailableSeats { get; set; }
        public string OfferTiming { get; set; }
        public string OfferDate { get; set; }
        public int Price { get; set; }
        public int StopId { get; set; }
        public int StopNumber { get; set; }
        public int LocationId { get; set; }
        public string LocationName { get; set; }
    }
}
