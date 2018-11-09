using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WhatEatToday.Models;

namespace WhatEatToday.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        private WhatEatToday_Entities db = new WhatEatToday_Entities();
        ApplicationDbContext context;
        public HomeController()
        {
            context = new ApplicationDbContext();
        }
        public ActionResult LoginHome()
        {
            return View();
        }
        public ActionResult Index()
        {
            
            var shop = from str in db.Shops
                       select str;
            return View(shop);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}