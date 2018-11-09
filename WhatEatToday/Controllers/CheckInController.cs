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
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        [HttpPost]
        public ActionResult Shops()
        {
            if (Request.IsAuthenticated)
            {
                float rating;
                int id = int.Parse(Request["shopid"]);
                var userid = User.Identity.GetUserName();
                if (String.IsNullOrEmpty(Request["rating"]))
                {
                    rating = 0;
                }else
                {
                    rating = float.Parse(Request["rating"]);
                }
                checkin(id, userid, rating);
            }
            else
            {

            }

            return RedirectToAction("Index", "Home");
        }
        public void checkin(int shop_id, string customer_id, float rating)
        {
            if (Request.IsAuthenticated)
            {
                String userid = "";
                var checkin_cus = from str in db.Customers
                                  select str;
                checkin_cus = checkin_cus.Where(checkin => checkin.email == customer_id);
                foreach (var gets in checkin_cus)
                {
                    userid = gets.cus_id;
                }

                CheckIn checkin_INS = new Models.CheckIn();
                if (!String.IsNullOrEmpty(customer_id))
                {
                    checkin_INS.Cus_Id = customer_id;
                    checkin_INS.Shop_Id = shop_id;
                    checkin_INS.Rating = rating;
                }
                else
                {

                }
                db.CheckIns.Add(checkin_INS);
                db.SaveChanges();
            }

        }
    }
}