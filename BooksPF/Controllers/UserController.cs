using BooksPF.Core.Abstract;
using BooksPF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BooksPF.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IOptions<AuthOptions> authOptions;
        public UserController(IUserService userService,IOptions<AuthOptions> authOptions)
        {
            this.userService = userService;
            this.authOptions = authOptions;
        }
        [HttpPost]
        [Route("/token")]
        public async Task<IActionResult> Login([FromBody]Login login)
        {
            var user = await AuthentificateUser(login.UserName, login.Password);

            if(user!= null)
            {
                return Ok(GenerateJWT(user));
            }
            return Unauthorized();
        }
        [HttpPost]
        public IActionResult AddUser(User user)
        {
            userService.AddUser(user);
            return Ok(user);
        }
        private async Task<User> AuthentificateUser(string login,string password)
        {
            var user = await userService.GetUser(login, password);
            return user;
        }

        private string GenerateJWT(User user)
        {
            var authParams = authOptions.Value;
            var securityKey = authParams.GetSymmetricSecurityKey();
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.UniqueName,user.UserName),
                new Claim(JwtRegisteredClaimNames.Sub,user.Id)
            };

            var token = new JwtSecurityToken(
                authParams.Issuer,
                authParams.Audience,
                claims,
                expires: DateTime.Now.AddSeconds(authParams.Lifetime),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
