using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LYQ.TokenDemo.Models
{
    public class TokenHelper
    {
        private const string SecretKey = "abcqwe123";

        public static string GenToken()
        {
            var tokenInfo = new TokenInfo();

            var payload = new Dictionary<string, object>
            {
                {"iss", tokenInfo.iss},
                {"iat", tokenInfo.iat},
                {"exp", tokenInfo.exp},
                {"aud", tokenInfo.aud},
                {"sub", tokenInfo.sub},
                {"jti", tokenInfo.jti},
                { "user", "Tim" },
                { "gender", "Male" },
                { "Age",18}
            };

            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);

            var token = encoder.Encode(payload, SecretKey);

            return token;

        }


    }
}