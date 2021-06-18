using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BooksPF.Models
{
    public class AuthOptions
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string AccessTokenKey { get; set; }
        public string RefreshTokenKey { get; set; }
        public int RefreshTokenLifeTime { get; set; }
        public int AccessTokenLifeTime { get; set; }

        public SymmetricSecurityKey GetSymmetricSecurityAccessKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(AccessTokenKey));
        }

        public SymmetricSecurityKey GetSymmetricSecurityRefreshKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(RefreshTokenKey));
        }
    }
}
