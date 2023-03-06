using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IRepoWrapper
    {
        IOfferRideRepository _OfferRideRepository { get; }
        ILocationRepository _LocationRepository { get; }
        IBookRideRepository _BookRideRepository { get; }
        IAccountRepository _AccountRepository { get; }
        IOfferingRideDetailsRepository _OfferingRideDetailsRepository { get; }
    }
}
