using LYQ.TokenDemo.Models.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LYQ.TokenDemo.Models.CustomAttribute
{
    public class AuthorizeAttribute : FilterAttribute, IAuthorizationFilter
    {
        public AuthorizeAttribute(bool _isCheck = true)
        {
            this.isCheck = _isCheck;
        }

        private bool isCheck { get; }

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            var httpContext = filterContext.HttpContext;
            var actionDescription = filterContext.ActionDescriptor;

            if (actionDescription.IsDefined(typeof(AllowAnonymousAttribute), false) ||
                actionDescription.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), false)) { return; }

            if (!isCheck) return;

            if (AppManager.UserState == null)
            {
                if (httpContext.Request.IsAjaxRequest())
                {
                    filterContext.Result = new JsonResult()
                    {
                        Data = new { Status = "Fail", Message = "403 Forbin", StatusCode = "403" },
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                }
                else
                {
                    filterContext.Result = new RedirectResult(("/Home/Login"));
                }
            }

        }
    }
}