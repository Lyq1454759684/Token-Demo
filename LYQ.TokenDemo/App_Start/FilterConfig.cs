﻿using System.Web;
using System.Web.Mvc;

namespace LYQ.TokenDemo
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {

            filters.Add(new LYQ.TokenDemo.Models.CustomAttribute.AuthorizeAttribute());
            filters.Add(new HandleErrorAttribute());
        }
    }
}
