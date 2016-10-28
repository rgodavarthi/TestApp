using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prayer.View_Model
{
    public class PrayerRequestListViewModel
    {
        public List<PrayerRequestViewModel> GetPrayers { get; set;}
        public string PrayerRequest { get; set; }
        public string SubmittedBy { get; set; }
        public string EventData { get; set; }
    }
}
