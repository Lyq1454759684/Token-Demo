using LYQ.TokenDemo.Models;
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
            ViewBag.Token = TokenHelper.GenToken();
            return View();
        }
    }
}