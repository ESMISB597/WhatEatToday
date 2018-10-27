using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WhatEatToday.Controllers
{
    public class GameController : Controller
    {
        // GET: Game
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Game1()
        {
            return View();
        }
        public ActionResult Game2()
        {
            return View();
        }
        public ActionResult Game3()
        {
            return View();
        }
        public ActionResult rule()
        {
            return View();
        }
    }
}