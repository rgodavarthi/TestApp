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
        public string PrayerDescription { get; set; }
        public string SubmittedBy { get; set;}
        public DateTime SubmittedDate { get; set; }
        public int Answered { get; set; }
    }
}
