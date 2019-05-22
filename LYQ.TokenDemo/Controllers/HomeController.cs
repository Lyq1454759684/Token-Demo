using LYQ.TokenDemo.Models;
using LYQ.TokenDemo.Models.Infrastructure;
using LYQ.TokenDemo.Models.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LYQ.TokenDemo.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TestPost()
        {
            var user = AppManager.UserState;

            if (!string.IsNullOrEmpty(user.UserName))
                return Json("y");
            else
                return Json("n");
        }

        [HttpGet]
        [LYQ.TokenDemo.Models.CustomAttribute.Authorize(false)]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [LYQ.TokenDemo.Models.CustomAttribute.Authorize(false)]
        public ActionResult Login(string account, string password)
        {
            if (account == "Tim" && password == "abc123")
            {
                var cookie = new HttpCookie(Key.AuthorizeCookieKey, TokenHelper.GenerateToken());
                HttpContext.Response.Cookies.Add(cookie);                
                return Json("y");
            }
            else
            {
                var cookie = new HttpCookie(Key.AuthorizeCookieKey, "");
                HttpContext.Response.Cookies.Add(cookie);
                return Json("n");
            }

        }

    }
}