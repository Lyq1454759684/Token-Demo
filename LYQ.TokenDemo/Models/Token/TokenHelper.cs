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
        private const string SecretKey = "LYQ.abcqwe123";

        public static string GenerateToken()
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
                { "userName", "Tim" },
                { "userID", "001" },
                { "level",18}
            };

            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);

            var token = encoder.Encode(payload, SecretKey);

            return token;
        }

        public static string GetDecodingToken(string strToken)
        {
            try
            {

                IJsonSerializer serializer = new JsonNetSerializer();
                IDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);

                var json = decoder.Decode(strToken, SecretKey, verify: true);

                return json;
            }
            catch (Exception)
            {

                return "";
            }
        }



    }
}