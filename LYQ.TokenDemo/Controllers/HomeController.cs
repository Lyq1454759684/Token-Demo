using LYQ.TokenDemo.Models;
using LYQ.TokenDemo.Models.Infrastructure;
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

            Response.Cookies.Add(new HttpCookie(Key.CookieKey, TokenHelper.GenToken()));
            Response.Cookies.Add(new HttpCookie("name", "Tim"));

            return View();
        }

        [HttpPost]
        public ActionResult TestPost()
        {
            var header = HttpContext.Request.Headers["Authorization"];

            if (!string.IsNullOrEmpty(header))
                return Json("y");
            else
                return Json("n");
        }

    }
}