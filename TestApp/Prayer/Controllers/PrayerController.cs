using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Prayer.Models;

namespace Prayer.Controllers
{
    public class PrayerController : Controller
    {
        // GET: Prayer
        public ActionResult Default()
        {
            return View();
        }
        public ActionResult SavePrayer(PrayerRequest p, string Btnsubmit)
        {
            PrayerRequestBusinessLayer prayer = new PrayerRequestBusinessLayer();
            prayer.Saveprayer((PrayerRequest)p);
            return View("Prayer");
        }   
    }
}