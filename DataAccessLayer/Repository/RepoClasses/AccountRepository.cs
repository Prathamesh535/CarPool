using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
namespace DataAccessLayer
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        public AccountRepository(CarPoolContext carPoolContext) : base(carPoolContext) { }
    }
}
