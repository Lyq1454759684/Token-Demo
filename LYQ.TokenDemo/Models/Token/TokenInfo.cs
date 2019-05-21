using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LYQ.TokenDemo.Models
{
    public class TokenInfo
    {
        public TokenInfo()
        {
            iss = "LYQ";
            iat = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
            exp = iat + 10;
            aud = "";
            sub = "HomeCare.VIP";
            jti = "LYQ." + DateTime.Now.ToString("yyyyMMddhhmmss");
        }

        public string iss { get; set; }
        public double iat { get; set; }
        public double exp { get; set; }
        public string aud { get; set; }
        public double nbf { get; set; }
        public string sub { get; set; }
        public string jti { get; set; }

    }
}