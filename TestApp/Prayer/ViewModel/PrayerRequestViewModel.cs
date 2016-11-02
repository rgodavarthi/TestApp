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
        public string PrayerText { get; set; }
        public string SubmittedBy { get; set; }
        public DateTime SubmittedDate { get; set; }
        public int Answered { get; set; }
        public bool IsNew { get; set; }

        // prayer list
        public List<PrayerRequestViewModel> PrayerRequestViewModelList { get; set; }

        // View binding variables
        public string PrayerRequest { get; set; }
        public string EventData { get; set; }
        public string PrayerID { get; set; }
        public string Mode { get; set; }


        // Gets and sets initial data set to view model list
        public void Get()
        {
            // Get data
            PrayerRequestBusinessLayer prayer = new PrayerRequestBusinessLayer();
            List<PrayerRequest> prayers = new List<Models.PrayerRequest>();
            prayers = prayer.GetPrayers();

            List<PrayerRequestViewModel> PrayerList = new List<PrayerRequestViewModel>();
            // Assign to view & viewmodel list
            foreach (PrayerRequest p in prayers)
            {
                PrayerList.Add(new PrayerRequestViewModel()
                {
                    ID = p.ID,
                    PrayerText = p.PrayerText,
                    Answered = p.Answered,
                    SubmittedBy = p.SubmittedBy,
                    SubmittedDate = p.SubmittedDate,
                    IsNew = (DateTime.Compare(p.SubmittedDate, DateTime.Today) == 0)
                });
            }

            PrayerRequestViewModelList = PrayerList;

        }
    }
}