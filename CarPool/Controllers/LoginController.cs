﻿using DataAccessLayer;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CarPool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        private readonly IRepoWrapper _RepoWrapper;

        public LoginController(IConfiguration config,IRepoWrapper repoWrapper)
        {
            _config = config;
            _RepoWrapper = repoWrapper;
        }
        [HttpGet]
        public IActionResult GetToken(Account login)
        {
            return Login(login);
        }
        [HttpPost]
        public IActionResult Login([FromBody]Account login)
        {
            IActionResult response = Unauthorized();
            Account user = AuthenticateUser(login);

            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(tokenString);
            }

            return response;
        }

        private string GenerateJSONWebToken(Account userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Name, userInfo.UserName)
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private Account AuthenticateUser(Account login)
        {
            Account user = _RepoWrapper._AccountRepository.GetOne(x => x.UserName == login.UserName && x.Password == login.Password);
            return user;
        }
    }
}
