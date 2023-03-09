using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace DataAccessLayer
{
    public class RequiredModel
    {
        public OfferingRides OfferingRide { get; set; }
        public List<int> LocationId { get; set; }
    }
}
