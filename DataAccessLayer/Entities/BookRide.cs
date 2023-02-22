using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Entities
{
    public class BookRide
    {
        public string AccountId { get; set; }//FK
        public string BookingId { get; set; }//PK
        public string OfferBookingId { get; set; }//FK
        public string From { get; set; }
        public string To { get; set; }
        public double Charges { get; set; }
        public string BookingDate { get; set; }
        public string BookTiming { get; set; }
        public int NumberOfSeatsBooked { get; set; }

        public Account Account;

        public OfferRide OfferRide;
    }
}
