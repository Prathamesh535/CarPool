using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace BusinessLayer
{
    public class AccountServices
    {
        public IRepoWrapper _RepoWrapper { get; set; }
        public AccountServices(IRepoWrapper repoWrapper) 
        {
            _RepoWrapper = repoWrapper;
        }
        public async Task AddAccount(Account accountDetails)
        {
           await _RepoWrapper._AccountRepository.Add(accountDetails);
        }
        public Task<ActionResult<IEnumerable<Account>>> GetAccount()
        {
            return _RepoWrapper._AccountRepository.GetAll();
        }
    }
}
