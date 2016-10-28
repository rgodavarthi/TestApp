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

        List<PrayerRequestViewModel> prayerRequestViewModelList = new List<PrayerRequestViewModel>();
        PrayerRequestListViewModel prayerRequestListViewModel = new PrayerRequestListViewModel();

        // First entry point when you launch application
        public ActionResult Default()  
        {
            // Get initial data set
            Get();

            // Assign prayer list data set to view model
            prayerRequestListViewModel.GetPrayers = prayerRequestViewModelList;

            // Send to view
            return View("Index", prayerRequestListViewModel);
        }

        // Entry point when you post - after adding a prayer request
        [HttpPost]
        public ActionResult Default(PrayerRequestListViewModel vml)
        {
            // Deserialize json data to list
            using (StreamReader sr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "App_Data\\PrayerData.json"))
            { 
                string data = sr.ReadToEnd();
                prayerRequestViewModelList = JsonConvert.DeserializeObject<List<PrayerRequestViewModel>>(data);
            }

            // Add new prayer request to the list
            prayerRequestViewModelList.Add(new PrayerRequestViewModel()
            {
                PrayerText = vml.PrayerRequest,
                Answered = 0,
                SubmittedBy = "Anonymous",
                SubmittedDate = DateTime.Today,
                IsNew = true
            });

            // Save to json file
            SavePrayerRequest();

            // Assign to view mode list
            prayerRequestListViewModel.GetPrayers = prayerRequestViewModelList;

            // Send to view
            return View("Index", prayerRequestListViewModel);
        }

        // Saves data to Json file
        private void SavePrayerRequest()
        {
            System.IO.File.WriteAllText(@"C:\Users\godavartra01\Source\Repos\TestApp\TestApp\Prayer\App_Data\PrayerData.json", JsonConvert.SerializeObject(prayerRequestViewModelList));
        }

        // Gets and sets initial data set to view model list
        private void Get()
        {
            // Get data
            PrayerRequestBusinessLayer prayer = new PrayerRequestBusinessLayer();
            List<PrayerRequest> prayers = prayer.GetPrayers();

            // Assign to view & viewmodel list
            foreach (PrayerRequest p in prayers)
            {
                prayerRequestViewModelList.Add(new PrayerRequestViewModel()
                {
                    PrayerText = p.PrayerText,
                    Answered = p.Answered,
                    SubmittedBy = p.SubmittedBy,
                    SubmittedDate = p.SubmittedDate,
                    IsNew = (DateTime.Compare(p.SubmittedDate, DateTime.Today) == 0)
                });
            }

        } 
    }
}