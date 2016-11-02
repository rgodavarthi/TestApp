using Prayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prayer.View_Model
{
    public class PrayerRequestViewModel
    {
        // View model
        public int ID { get; set; }
        public string PrayerDescription { get; set; }
        public string SubmittedBy { get; set; }
        public DateTime SubmittedDate { get; set; }
        public int Answered { get; set; }
        public bool IsNew { get; set; }

        // Original data set prayer list & view model list
        public List<PrayerRequestViewModel> PrayerRequestViewModelList { get; set; }
        public List<PrayerRequest> prayers = new List<Models.PrayerRequest>();

        // View binding variables
        public string PrayerRequest { get; set; }
        public string PrayerID { get; set; }
        public string Mode { get; set; }


        // Gets and sets initial data set to view model list
        public void Get()
        {
            // Get data
            PrayerRequestBusinessLayer prayer = new PrayerRequestBusinessLayer();            
            prayers = prayer.GetPrayers();

            List<PrayerRequestViewModel> PrayerList = new List<PrayerRequestViewModel>();
            // Assign to view & viewmodel list
            foreach (PrayerRequest p in prayers)
            {
                PrayerList.Add(new PrayerRequestViewModel()
                {
                    ID = p.ID,
                    PrayerDescription = p.PrayerDescription,
                    Answered = p.Answered,
                    SubmittedBy = p.SubmittedBy,
                    SubmittedDate = p.SubmittedDate,
                    IsNew = (DateTime.Compare(p.SubmittedDate, DateTime.Today) <= 1)
                });
            }

            PrayerRequestViewModelList = PrayerList;
        }
    }
}