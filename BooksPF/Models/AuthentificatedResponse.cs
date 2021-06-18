using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksPF.Models
{
    public class AuthentificatedResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }

        public AuthentificatedResponse(string access,string refresh)
        {
            AccessToken = access;
            RefreshToken = refresh;
        }
    }
}
