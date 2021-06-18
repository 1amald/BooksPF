using BooksPF.Core.Abstract;
using BooksPF.Models;
using BooksPF.ViewModels;
using Microsoft.AspNetCore.Authorization;
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
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly AuthOptions authOptions;
        private readonly TokenGenerator tokenGenerator;
        public UserController(IUserService userService,IOptions<AuthOptions> authOptions,TokenGenerator tokenGenerator)
        {
            this.userService = userService;
            this.authOptions = authOptions.Value;
            this.tokenGenerator = tokenGenerator;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginViewModel model)
        {
            var user = await AuthentificateUser(model.Login, model.Password);
            if(user!= null)
            {
                var claims = new List<Claim>()
                {
                    new Claim(JwtRegisteredClaimNames.UniqueName,user.Login),
                    new Claim(JwtRegisteredClaimNames.Sub,user.Id)
                };

                var accessToken = tokenGenerator.GenerateAccessToken(claims);
                var refreshToken = tokenGenerator.GenerateRefreshToken(claims);
                return Ok(new AuthentificatedResponse(accessToken,refreshToken));
            }
            return Unauthorized();
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]RegisterViewModel model)
        {
            if (await userService.UserExist(model.Login))
            {
                return Unauthorized("Login is busy");
            }

            var user = await userService.AddUser(new Models.User(model.Login, model.Password));
            var claims = new List<Claim>()
                {
                    new Claim(JwtRegisteredClaimNames.UniqueName,user.Login),
                    new Claim(JwtRegisteredClaimNames.Sub,user.Id)
                };

            var accessToken = tokenGenerator.GenerateAccessToken(claims);
            var refreshToken = tokenGenerator.GenerateRefreshToken(claims);
            return Ok(new AuthentificatedResponse(accessToken, refreshToken));
        }
        private async Task<User> AuthentificateUser(string login,string password)
        {
            var user = await userService.AuthentificateUser(login,password);
            return user;
        }
    }
}
