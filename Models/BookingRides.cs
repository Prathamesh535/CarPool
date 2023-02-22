using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Models
{
    public class BookingRides
    {
        public string BookId { get; set; }
        public string  From { get; set; }
        public string To { get; set; }
        public string OfferedFrom { get; set; }
        public string OfferedTo { get; set;}
        public double Charges { get; set; }
        public string BookTiming { get; set; }
        public string AccountId { get; set; }
    }
}
