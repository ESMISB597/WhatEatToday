using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Dynamic;
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
        [HttpPost]
        public ActionResult Index()
        {
            int id = int.Parse(Request["shopid"]);
            if (Request.IsAuthenticated)
            {
                dynamic menu_shop = new ExpandoObject();
                var shop = from str in db.Shops
                           select str;
                menu_shop.shop = shop.Where(shops => shops.shop_id == id);
                var menu = from str in db.Menus
                           select str;
                menu_shop.menu = menu.Where(me => me.shop_id == id);
                return View(menu_shop);
            }else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        [HttpPost]
        public ActionResult Shops()
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