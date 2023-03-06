using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entities;
using BusinessLayer;
using DataAccessLayer;

namespace CarPool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        public  IRepoWrapper _RepoWrapper;
        public AccountServices accountServices;

        public AccountsController(IRepoWrapper repoWrapper)
        {
            _RepoWrapper = repoWrapper;
            accountServices = new AccountServices(_RepoWrapper);
        }

        [HttpGet]
        public  Task<ActionResult<IEnumerable<Account>>> GetAccount()
        {
            return  accountServices.GetAccount();
        }

        [HttpPost]
        public async Task<ActionResult<Account>> PostAccount(Account account)
        {

             await accountServices.AddAccount(account);
             return CreatedAtAction("GetAccount", new { id = account.AccountId }, account);
        }
    }
}
