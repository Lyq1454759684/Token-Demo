using LYQ.TokenDemo.Models.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LYQ.TokenDemo.Models.Infrastructure
{
    public class AppManager
    {
        public static UserState UserState
        {
            get
            {
                HttpContext httpContext = HttpContext.Current;
                var cookie = httpContext.Request.Cookies[Key.AuthorizeCookieKey];

                var tokenInfo = cookie?.Value ?? "";

                //token 解密
                var encodeTokenInfo = TokenHelper.GetDecodingToken(tokenInfo);

                UserState userState = JsonHelper<UserState>.JsonDeserializeObject(encodeTokenInfo);
               
                return userState;
            }
        }

    }
}