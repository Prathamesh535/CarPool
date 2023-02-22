using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class OfferingRideDetails
    {
        public string StopId { get; set; }   
        public string UserName { get; set; }
        public int TotalSeatsAvailable { get; set; }
        public string OfferTiming { get; set; }
        public string OfferDate { get; set; }
        public string From { get; set; }
        public string To { get; set; }  
        public double Price { get; set; }
        public int StopNumber { get; set; }
        public string LocationName { get; set; }
    }
}
