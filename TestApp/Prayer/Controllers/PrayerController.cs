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

        PrayerRequestViewModel vm = new PrayerRequestViewModel();
        Random rnd = new Random();

        // First entry point when you launch application
        public ActionResult Default()  
        {
            // Get initial data set
            vm.Get();

            // Send to view
            return View("Index", vm);
        }

        // Entry point when you post - after adding a prayer request
        [HttpPost]
        public ActionResult Default(PrayerRequestViewModel vml)
        {
           
            // Deserialize json data to list
            using (StreamReader sr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "App_Data\\PrayerData.json"))
            {
                string data = sr.ReadToEnd();
                vm.PrayerRequestViewModelList = JsonConvert.DeserializeObject<List<PrayerRequestViewModel>>(data);
            }
            
            switch (vml.EventData.ToLower())
            { 
                case "submit":               

                    if (!string.IsNullOrEmpty(vml.PrayerRequest) && (string.IsNullOrEmpty(vml.PrayerID)))
                    {
                        // Add new prayer request to the list
                        vm.PrayerRequestViewModelList.Add(new PrayerRequestViewModel()
                        {
                            //ID = vm.PrayerRequestViewModelList.Count + 1,
                            ID = rnd.Next(),
                            PrayerText = vml.PrayerRequest,
                            Answered = 0,
                            SubmittedBy = vml.SubmittedBy,
                            SubmittedDate = DateTime.Now,
                            IsNew = true
                        });

                        // Save to json file
                        SavePrayerRequest();
                    }
                    else if (!(string.IsNullOrEmpty(vml.PrayerID)))
                    {
                        // Update
                        PrayerRequestViewModel vmEdit = vm.PrayerRequestViewModelList.Find(id => id.ID == Convert.ToInt32(vml.PrayerID));
                        vmEdit.PrayerText = vml.PrayerRequest;
                        vmEdit.SubmittedBy = vml.SubmittedBy;
                        vmEdit.SubmittedDate = DateTime.Now;
                        vmEdit.IsNew = true;

                        // Save to json file
                        SavePrayerRequest();
                    }

                    ModelState.Clear();

                    break;


                case "delete":

                    vm.PrayerRequestViewModelList.Remove(vm.PrayerRequestViewModelList.Find(id => id.ID == Convert.ToInt32(vml.PrayerID)));
                    SavePrayerRequest();

                    ModelState.Clear();

                    break;

                case "reset":

                    ModelState.Clear();

                    break;
            }

            // Send to view
            return View("Index", vm);
        }

        // Saves data to Json file
        private void SavePrayerRequest()
        {
            System.IO.File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "App_Data\\PrayerData.json", JsonConvert.SerializeObject(vm.PrayerRequestViewModelList));
        }
    }
}