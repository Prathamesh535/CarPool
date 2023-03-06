using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IAccountRepository
    {
        public Task Add(Account account);
        public Task<ActionResult<IEnumerable<Account>>> GetAll();
        public Account GetOne(Expression<Func<Account, bool>> predicate);
    }
}
