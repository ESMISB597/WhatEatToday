using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WhatEatToday.Models;
using System.IO;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WhatEatToday
{
    public class ShopsController : Controller
    {
        private WhatEatToday_Entities db = new WhatEatToday_Entities();

        ApplicationDbContext context;
        public ShopsController()
        {
            context = new Models.ApplicationDbContext();
        }
        // GET: Shops
        public ActionResult Index(string SearchString)
        {
            var store = from s in db.Shops
                        select s;

            var selectstore = from str in db.Owners
                              select str;

            if (Request.IsAuthenticated)
            {
                try
                {
                    var user = User.Identity;
                    var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                    var getR = UserManager.GetRoles(user.GetUserId());
                    if (getR[0].ToString() == "Shop")
                    {
                        if (!String.IsNullOrEmpty(SearchString))
                        {
                            store = store.Where(p => p.name.Contains(SearchString));

                        }
                        else
                        {
                            ViewBag.ViewEdit = getR[0].ToString();
                            return View(store);
                        }
                    }
                    else
                    {
                        return View(store);
                    }
                }
                catch (System.ArgumentOutOfRangeException e)
                {
                    return RedirectToAction("Index", "Home");
                }
            }else
            {

            }
            return View(store);
        }

        // GET: Shops/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shop shop = db.Shops.Find(id);
            if (shop == null)
            {
                return HttpNotFound();
            }
            return View(shop);
        }

        // GET: Shops/Create
        public ActionResult Create()
        {
            //var user = User.Identity;
            //var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            //var getR = UserManager.GetRoles(user.GetUserId());
            //if (getR[0].ToString() == "Shop")
            //{
                return View();
            //}else
            //{
                //return View("Index");
            //}
            
        }

        // POST: Shops/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Include = "shop_id,name,details,type,pic,latitude,longitude")] Shop shop)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userid = User.Identity.GetUserName();
                    var file = Request.Files[0];
                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var path = Path.Combine(Server.MapPath("~/Content/images"), fileName);
                        file.SaveAs(path);
                        shop.pic = fileName;

                    }

                    /* LAMBDA */
                    Owner owner = new Owner();
                    owner.email = userid;
                    owner.shop_id = shop.shop_id;
                    owner.owner_id = User.Identity.GetUserId().ToString();
                    db.Owners.Add(owner);
                    /* LAMBDA */

                    db.Shops.Add(shop);
                    db.SaveChanges();


                    return RedirectToAction("Index");
                }
            }
            catch(System.Data.Entity.Validation.DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }

            return View(shop);
        }

        // GET: Shops/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shop shop = db.Shops.Find(id);
            if (shop == null)
            {
                return HttpNotFound();
            }
            return View(shop);
        }

        // POST: Shops/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Edit([Bind(Include = "shop_id,name,details,type,pic,latitude,longitude")] Shop shop)
        {
            if (ModelState.IsValid)
            {
                var file = Request.Files[0];
                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/images"), fileName);
                    file.SaveAs(path);
                    shop.shop_id = int.Parse(Request["shop_hid"]);
                    shop.pic = fileName;
                }else
                {
                    shop.shop_id = int.Parse(Request["shop_hid"]);
                    shop.pic = Request["pictures_hid"];
                }
                db.Entry(shop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shop);
        }

        // GET: Shops/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shop shop = db.Shops.Find(id);
            if (shop == null)
            {
                return HttpNotFound();
            }
            int del = (int)id;
            DeleteConfirmed(del);
            return View("Index");
        }

        // POST: Shops/Delete/5
        public void DeleteConfirmed(int id)
        {
            Shop shop = db.Shops.Find(id);
            Owner owner = new Owner();
            var finddel = db.Owners.FirstOrDefault(own => own.shop_id == id);
            db.Owners.Remove(finddel);
            db.Shops.Remove(shop);
            db.SaveChanges();
        }

        public ActionResult FindShop(string SearchString)
        {
            var shop = from s in db.Shops
                       select s;
                if (!String.IsNullOrEmpty(SearchString))
                {
                    shop = shop.Where(p => p.name.Contains(SearchString));
                    return View(shop);

                }
                else
                {

                }
            
            return View("");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
