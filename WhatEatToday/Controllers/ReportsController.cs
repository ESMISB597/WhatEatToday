using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WhatEatToday.Models;


namespace WhatEatToday.Views.Reports
{
    public class ReportsController : Controller
    {
        // GET: Reports
        public ActionResult index()
        {
            return View();
        }
    }
}