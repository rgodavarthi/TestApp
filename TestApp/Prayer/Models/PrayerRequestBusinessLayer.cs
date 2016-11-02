using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.IO;
using Prayer.View_Model;

namespace Prayer.Models
{

    class PrayerRequestBusinessLayer
    {
        public List<PrayerRequest> GetPrayers()
        {
            
            List<PrayerRequest> prayers = new List<PrayerRequest>();

            // Initial data set
            // Deserialize json data to list
            using (StreamReader sr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "App_Data\\PrayerData.json"))
            {
                string data = sr.ReadToEnd();

                // Deserialize only when you have some data
                if (!string.IsNullOrEmpty(data))
                    prayers = JsonConvert.DeserializeObject<List<PrayerRequest>>(data);
            }

            //// Sample data set
            //prayers.Add(new PrayerRequest()
            //    {
            //        ID = 1,
            //        PrayerDescription = "Pray for this country",
            //        Answered = 0,
            //        SubmittedBy = "Rajesh",
            //        SubmittedDate = Convert.ToDateTime("10/25/2016")
            //    });

            //prayers.Add(new PrayerRequest()
            //{
            //    ID = 2,
            //    PrayerDescription = "Pray for our kids",
            //    Answered = 0,
            //    SubmittedBy = "ISCF",
            //    SubmittedDate = Convert.ToDateTime("6/2/2016")

            //});

            //prayers.Add(new PrayerRequest()
            //{
            //    ID = 3,
            //    PrayerDescription = "Pray for our leaders",
            //    Answered = 0,
            //    SubmittedBy = "Church",
            //    SubmittedDate = Convert.ToDateTime("1/2/2015")

            //});

            //prayers.Add(new PrayerRequest()
            //{
            //    ID = 4,
            //    PrayerDescription = "Pray for our schools",
            //    Answered = 0,
            //    SubmittedBy = "Students",
            //    SubmittedDate = Convert.ToDateTime("1/5/2016")

            //});

            //// Creates a JSON file under App_Data folder
            //File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "App_Data\\PrayerData.json", JsonConvert.SerializeObject(prayers));

            return prayers;
        }

    }
}
