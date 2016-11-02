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

        // Initiatialize view model
        // Send to view
        PrayerRequestViewModel vm = new PrayerRequestViewModel();

        // random number for ID column
        Random rnd = new Random();

        // First entry point when you launch application
        public ActionResult Default()  
        {
            // Get initial data set
            vm.Get();
            
            // Send to view
            return View("Index", vm);
        }

        // Entry point when you post - after add/edit/update/delete a prayer request
        [HttpPost]
        public ActionResult Default(PrayerRequestViewModel vml)
        {
            vm.Get();

            // Handling prayer CRUD operations
            switch (vml.Mode.ToLower())
            {
                case "submit":

                    if (!string.IsNullOrEmpty(vml.PrayerRequest) && (string.IsNullOrEmpty(vml.PrayerID)))
                    {
                        int randomNext = rnd.Next();

                        // Add new prayer request to the list
                        vm.prayers.Add(new PrayerRequest()
                        {
                            ID = randomNext,
                            PrayerDescription = vml.PrayerRequest,
                            Answered = 0,
                            SubmittedBy = vml.SubmittedBy,
                            SubmittedDate = DateTime.Now,
                        });

                        // Add to view list
                        vm.PrayerRequestViewModelList.Add(new PrayerRequestViewModel()
                        {
                            ID = randomNext,
                            PrayerDescription = vml.PrayerRequest,
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
                        PrayerRequest pr = vm.prayers.Find(id => id.ID == Convert.ToInt32(vml.PrayerID));
                        pr.PrayerDescription = vml.PrayerRequest;
                        pr.SubmittedBy = vml.SubmittedBy;
                        pr.SubmittedDate = DateTime.Now;

                        // Add to view list
                        PrayerRequestViewModel pvm = vm.PrayerRequestViewModelList.Find(id => id.ID == Convert.ToInt32(vml.PrayerID));
                        pvm.PrayerDescription = vml.PrayerRequest;
                        pvm.Answered = 0;
                        pvm.SubmittedBy = vml.SubmittedBy;
                        pvm.SubmittedDate = DateTime.Now;
                        pvm.IsNew = true;

                        // Save to json file
                        SavePrayerRequest();
                    }

                    ModelState.Clear();

                    break;


                case "delete":

                    vm.prayers.Remove(vm.prayers.Find(id => id.ID == Convert.ToInt32(vml.PrayerID)));
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
            System.IO.File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "App_Data\\PrayerData.json", JsonConvert.SerializeObject(vm.prayers));
        }
    }
}