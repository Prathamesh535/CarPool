using DataAccessLayer;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class OfferingRideDetailsServices
    {
        private IRepoWrapper _RepoWrapper;
        public OfferingRideDetailsServices(IRepoWrapper repoWrapper)
        {
            _RepoWrapper = repoWrapper;
        }
        public Task<ActionResult<IEnumerable<OfferingRideDetails>>> GetOfferingRideDetails()
        {
            return _RepoWrapper._OfferingRideDetailsRepository.GetAll();
        }

    }
}
