﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WhatEatToday.Models;

namespace WhatEatToday.Controllers
{
    public class CheckInController : Controller
    {
        private WhatEatToday_Entities db = new WhatEatToday_Entities();
        // GET: CheckIn
        public ActionResult Index(int? id)
        {
            if (Request.IsAuthenticated)
            {
                var shop = from str in db.Shops
                           select str;
                shop = shop.Where(shops => shops.shop_id == id);
                return View(shop);
            }else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        public ActionResult Shops(int? id)
        {

            return View();
        }
        public void checkin(int shop_id,string customer_id)
        {

        }
    }
}