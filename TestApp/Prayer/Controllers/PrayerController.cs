using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Prayer.Models;
using Prayer.View_Model;

namespace Prayer.Controllers
{
    public class PrayerController : Controller
    {
        // GET: Prayer
        public ActionResult Default()  
        {
            // Get data
            PrayerRequestBusinessLayer prayer = new PrayerRequestBusinessLayer();
            List<PrayerRequest> prayers = prayer.GetPrayers();

            // Assign to view & viewmodel list
            List<PrayerRequestViewModel> prvmlist = new List<PrayerRequestViewModel>();
            foreach(PrayerRequest p in prayers)
            {
                prvmlist.Add(new PrayerRequestViewModel()
                {
                    PrayerText = p.PrayerText,
                    Answered = p.Answered,
                    SubmittedBy = p.SubmittedBy,
                    SubmittedDate = p.SubmittedDate,
                    IsNew = (DateTime.Compare(p.SubmittedDate, DateTime.Today) == 0)
                });             
            }

            PrayerRequestListViewModel prayerRequestListViewModel = new PrayerRequestListViewModel();
            prayerRequestListViewModel.GetPrayers = prvmlist;

            return View("Index", prayerRequestListViewModel);
        }

        //public ActionResult SavePrayer(PrayerRequest p, string Btnsubmit)
        //{
        //    //PrayerRequestBusinessLayer prayer = new PrayerRequestBusinessLayer();
        //    //prayer.Saveprayer((PrayerRequest)p);
        //    //List<PrayerRequest> prayers = prayer.GetPrayers();
        //    //PrayerRequestListViewModel prayerRequestList = new PrayerRequestListViewModel();
        //    //prayerRequestList.GetPrayers = prayers;
        //    return View("Default", prayerRequestList);
        //}   
    }
}