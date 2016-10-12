using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prayer.Controllers
{
    public class PrayerController : Controller
    {
        // GET: Prayer
        public ActionResult Default()
        {
            return View();
        }
    }
}