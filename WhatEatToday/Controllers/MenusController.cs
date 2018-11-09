using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WhatEatToday.Models;

namespace WhatEatToday
{
    public class MenusController : Controller
    {
        private WhatEatToday_Entities db = new WhatEatToday_Entities();
                ApplicationDbContext context;

        public MenusController()
        {
            context = new Models.ApplicationDbContext();
        }
        // GET: Menus
        public ActionResult Index(int? id)
        {
            var menus = from m in db.Menus
                        select m;
            if (Request.IsAuthenticated)
            {
                menus = menus.Where(mn => mn.shop_id == id);
            }else
            {

            }

            return View(menus.ToList());
        }

        // GET: Menus/GetMenu/5
        public ActionResult GetMenu(int? id)
        {
            if (Request.IsAuthenticated)
            {
                var menus = from m in db.Menus
                            select m;
                var user = User.Identity;
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var getR = UserManager.GetRoles(user.GetUserId());
                var userid = User.Identity.GetUserName();

                if (!String.IsNullOrEmpty(id.ToString()))
                {
                    menus = menus.Where(m => m.shop_id == id);
                    return View(menus.ToList());
                }
                else
                {
                    if (getR[0].ToString() == "Shop")
                    {
                        ViewBag.ViewEdit = "Shop";
                    }
                    else
                    {

                    }
                    if (!String.IsNullOrEmpty(id.ToString()))
                    {
                        return RedirectToAction("Index", "Shops");
                    }
                    else
                    {

                    }
                }
            }else
            {

            }
            return View("");
        }

        // GET: Menus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menu menu = db.Menus.Find(id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            return View(menu);
        }

        // GET: Menus/Create
        public ActionResult Create(int? id)
        {
            if (!String.IsNullOrEmpty(id.ToString()))
            {
                var menus = from m in db.Shops
                            select m;
                menus = menus.Where(m => m.shop_id == id);
                ViewBag.shop_id = new SelectList(menus, "shop_id", "name");
            }else
            {
                return View();
            }

            return View();
        }

        // POST: Menus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "menu_id,shop_id,menu_name,comment")] Menu menu)
        {
            if (ModelState.IsValid)
            {
                db.Menus.Add(menu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.shop_id = new SelectList(db.Shops, "shop_id", "name", menu.shop_id);
            return View(menu);
        }

        // GET: Menus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menu menu = db.Menus.Find(id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            ViewBag.shop_id = new SelectList(db.Shops, "shop_id", "name", menu.shop_id);
            return View(menu);
        }

        // POST: Menus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "menu_id,shop_id,menu_name,comment")] Menu menu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(menu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.shop_id = new SelectList(db.Shops, "shop_id", "name", menu.shop_id);
            return View(menu);
        }

        // GET: Menus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menu menu = db.Menus.Find(id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            return View(menu);
        }

        // POST: Menus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Menu menu = db.Menus.Find(id);
            db.Menus.Remove(menu);
            db.SaveChanges();
            return RedirectToAction("Index");
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
