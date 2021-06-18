using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BooksPF.Models
{
    public class TokenGenerator
    {
        private readonly AuthOptions authOptions;
        public TokenGenerator(IOptions<AuthOptions> authOptions)
        {
            this.authOptions = authOptions.Value;
        }
        private string GenerateToken(SymmetricSecurityKey key, string issuer, string audience, int lifeTime, IEnumerable<Claim> claims = null)
        {
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer,
                audience,
                claims,
                expires: DateTime.Now.AddMinutes(lifeTime),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public string GenerateRefreshToken(IEnumerable<Claim> claims)
        {
            return GenerateToken(
                    authOptions.GetSymmetricSecurityRefreshKey(),
                    authOptions.Issuer,
                    authOptions.Audience,
                    authOptions.RefreshTokenLifeTime,
                    claims
                    );
        }
        public string GenerateAccessToken(IEnumerable<Claim> claims)
        {
            return GenerateToken(
                    authOptions.GetSymmetricSecurityAccessKey(),
                    authOptions.Issuer,
                    authOptions.Audience,
                    authOptions.AccessTokenLifeTime,
                    claims
                    );
        }
    }
}
