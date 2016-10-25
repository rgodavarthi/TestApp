using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prayer.View_Model
{
    public class PrayerRequestViewModel
    {
        public string PrayerText { get; set; }
        public string SubmittedBy { get; set; }
        public DateTime SubmittedDate { get; set; }
        public int Answered { get; set; }
        public bool IsNew { get; set; }
    }
}