using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LYQ.TokenDemo.Models.CustomAttribute
{
    public class AuthorizeAttribute : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            var httpContext = filterContext.HttpContext;
            var actionDescription = filterContext.ActionDescriptor;

            if (actionDescription.IsDefined(typeof(AllowAnonymousAttribute), false) ||
                actionDescription.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), false)) { return; }

        }
    }
}