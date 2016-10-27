using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Prayer.Models;
using Prayer.View_Model;
using Newtonsoft.Json;
using System.IO;

namespace Prayer.Controllers
{
    public class PrayerController : Controller
    {

        List<PrayerRequestViewModel> prvmlist = new List<PrayerRequestViewModel>();
        PrayerRequestListViewModel prayerRequestListViewModel = new PrayerRequestListViewModel();

        // GET: Prayer
        public ActionResult Default()  
        {
            Get();

            string json = JsonConvert.SerializeObject(prvmlist);
            System.IO.File.WriteAllText(@"C:\Users\godavartra01\Source\Repos\TestApp\TestApp\Prayer\App_Data\PrayerData.json", json); 

            prayerRequestListViewModel.GetPrayers = prvmlist;

            return View("Index", prayerRequestListViewModel);
        }

        [HttpPost]
        public ActionResult Default(PrayerRequestListViewModel vml)
        {
            Get();

            prvmlist.Add(new PrayerRequestViewModel()
            {
                PrayerText = vml.PrayerRequest,
                Answered = 0,
                SubmittedBy = "Anonymous",
                SubmittedDate = DateTime.Today,
                IsNew = true
            });

            
            SavePrayerRequest();
            prayerRequestListViewModel.GetPrayers = prvmlist;
            return View("Index", prayerRequestListViewModel);
        }

        private void SavePrayerRequest()
        {
            //// Add to json file
            //using (StreamReader file = System.IO.File.OpenText(@"C:\Users\godavartra01\Source\Repos\TestApp\TestApp\Prayer\App_Data\PrayerData.json")
            //using (JsonTextReader reader = new JsonTextReader(file))
            //{
            //      List<PrayerRequestViewModel> vml = JsonConvert.DeserializeObject()
            //}

                string json = JsonConvert.SerializeObject(prvmlist);
                System.IO.File.WriteAllText(@"C:\Users\godavartra01\Source\Repos\TestApp\TestApp\Prayer\App_Data\PrayerData.json", json);
        }

        private void Get()
        {
            // Get data
            PrayerRequestBusinessLayer prayer = new PrayerRequestBusinessLayer();
            List<PrayerRequest> prayers = prayer.GetPrayers();

            // Assign to view & viewmodel list
            foreach (PrayerRequest p in prayers)
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