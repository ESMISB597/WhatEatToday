using Microsoft.AspNet.Identity;
using System;
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
        public void checkin(int shop_id,string customer_id,int rating)
        {
            if (Request.IsAuthenticated)
            {
                String userid = "";
                var checkin_cus = from str in db.Customers
                                  select str;
                checkin_cus = checkin_cus.Where(checkin => checkin.email == User.Identity.GetUserId().ToString());
                foreach(var gets in checkin_cus)
                {
                    userid = gets.cus_id;
                }

                CheckIn checkin_INS = new Models.CheckIn();
                if (!String.IsNullOrEmpty(userid))
                {
                    checkin_INS.Cus_Id = userid;
                    checkin_INS.Shop_Id = shop_id;
                    checkin_INS.Rating = rating;
                }else
                {

                }
                db.CheckIns.Add(checkin_INS);
                db.SaveChanges();
            }

        }
    }
}