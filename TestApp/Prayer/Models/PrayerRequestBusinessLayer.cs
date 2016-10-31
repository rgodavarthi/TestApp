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
        public void Saveprayer(PrayerRequest P)
        {
            string connectionString = "Data Source=HBMSEA-BATTAGAN;Initial Catalog=Prayer;Integrated Security=true;";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string insertPrayerRequest = "INSERT INTO PrayerRequest (Text,SubmittedBy, Answered) values('" + P.PrayerText + "','" + P.SubmittedBy + "','" + P.Answered + "')";
            if (connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand command = new SqlCommand(insertPrayerRequest);
                command.Connection = connection;
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public List<PrayerRequest> GetPrayers()
        {
            
            List<PrayerRequest> prayers = new List<PrayerRequest>();  

            // Sample data set
            prayers.Add(new PrayerRequest()
                {
                    ID = 1,
                    PrayerText = "Pray for this country",
                    Answered = 0,
                    SubmittedBy = "Rajesh",
                    SubmittedDate = Convert.ToDateTime("10/25/2016")
                });

            prayers.Add(new PrayerRequest()
            {
                ID = 2,
                PrayerText = "Pray for our kids",
                Answered = 0,
                SubmittedBy = "ISCF",
                SubmittedDate = Convert.ToDateTime("6/2/2016")

            });

            prayers.Add(new PrayerRequest()
            {
                ID = 3,
                PrayerText = "Pray for our leaders",
                Answered = 0,
                SubmittedBy = "Church",
                SubmittedDate = Convert.ToDateTime("1/2/2015")

            });

            prayers.Add(new PrayerRequest()
            {
                ID = 4,
                PrayerText = "Pray for our schools",
                Answered = 0,
                SubmittedBy = "Students",
                SubmittedDate = Convert.ToDateTime("1/5/2016")

            });

            // Creates a JSON file under App_Data folder
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "App_Data\\PrayerData.json", JsonConvert.SerializeObject(prayers));

            return prayers;
        }

    }
}
