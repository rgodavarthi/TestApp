using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prayer.Models
{
    public class PrayerRequest
    {
        public int ID { get; set; }
        public string PrayerText { get; set; }
        public string SubmittedBy { get; set;}
        public string SubmittedDate { get; set; }
        public int Answered { get; set; }
    }
}
