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
    [Route("api/[controller]")]
    public class TokenController : ControllerBase
    {
        private readonly TokenGenerator generator;
        private readonly AuthOptions authOptions;
        private readonly IUserService userService;
        public TokenController(TokenGenerator generator, IOptions<AuthOptions> authOptions, IUserService userService)
        {
            this.generator = generator;
            this.authOptions = authOptions.Value;
            this.userService = userService;
        }
        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody]string refreshToken)
        {
            string id;
            string login;
            if (!RefreshTokenIsValid(refreshToken,out id,out login))
            {
                return Unauthorized();
            }

            if (!await userService.UserExist(login))
            {
                return Unauthorized();
            }

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.UniqueName,login),
                new Claim(JwtRegisteredClaimNames.Sub,id)
            };

            var accessToken = generator.GenerateAccessToken(claims);
            var newRefreshToken = generator.GenerateRefreshToken(claims);

            return Ok(new AuthentificatedResponse(accessToken,newRefreshToken));
        }
        private bool RefreshTokenIsValid(string refreshToken,out string id,out string login)
        {
            var validator = new JwtSecurityTokenHandler();
            id = null;
            login = null;

            SecurityToken validatedToken;
            TokenValidationParameters validationParameters = new TokenValidationParameters()
            {
                ValidIssuer = authOptions.Issuer,
                ValidAudience = authOptions.Audience,
                IssuerSigningKey = authOptions.GetSymmetricSecurityRefreshKey(),
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
            };

            if (validator.CanReadToken(refreshToken))
            {
                ClaimsPrincipal principal;
                try
                {
                    principal = validator.ValidateToken(refreshToken, validationParameters, out validatedToken);
                    if (principal.HasClaim(c => c.Type == ClaimTypes.Name || c.Type == ClaimTypes.NameIdentifier))
                    {
                        id = principal.FindFirstValue(ClaimTypes.NameIdentifier);
                        login = principal.FindFirstValue(ClaimTypes.Name);
                        return true;
                    }
                }
                catch (Exception e)
                {
                    return false;
                }
            }

            return false;
        }
    }
}
