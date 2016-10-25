using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

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

            prayers.Add(new PrayerRequest()
                {
                    PrayerText = "Pray for this country",
                    Answered = 0,
                    SubmittedBy = "Rajesh",
                    SubmittedDate = Convert.ToDateTime("10/25/2016")
                });

            prayers.Add(new PrayerRequest()
            {
                PrayerText = "Pray for our kids",
                Answered = 0,
                SubmittedBy = "ISCF",
                SubmittedDate = Convert.ToDateTime("6/2/2016")

            });

            prayers.Add(new PrayerRequest()
            {
                PrayerText = "Pray for our leaders",
                Answered = 0,
                SubmittedBy = "Church",
                SubmittedDate = Convert.ToDateTime("1/2/2015")

            });

            prayers.Add(new PrayerRequest()
            {
                PrayerText = "Pray for our schools",
                Answered = 0,
                SubmittedBy = "Students",
                SubmittedDate = Convert.ToDateTime("1/5/2016")

            });

            prayers.Add(new PrayerRequest()
            {
                PrayerText = "Pray for our Missionaries",
                Answered = 0,
                SubmittedBy = "Mission Leaders",
                SubmittedDate = Convert.ToDateTime("10/21/2014")

            });

            prayers.Add(new PrayerRequest()
            {
                PrayerText = "Pray for our families",
                Answered = 0,
                SubmittedBy = "Pastors",
                SubmittedDate = Convert.ToDateTime("10/25/2016")

            });
            //string query = "SELECT * FROM PrayerRequest order by 1 desc";
            //string connectionString = "Data Source=HBMSEA-BATTAGAN;Initial Catalog=Prayer;Integrated Security=true;";
            //SqlConnection connection = new SqlConnection(connectionString);
            //connection.Open();
            
            //if (connection.State == System.Data.ConnectionState.Open)
            //{
            //    SqlCommand command = new SqlCommand(query);
            //    command.Connection = connection;
            //    SqlDataReader rd = command.ExecuteReader();

            //    while (rd.Read())
            //    {
            //        PrayerRequest prayerRequest = new PrayerRequest();
            //        prayerRequest.PrayerText = Convert.ToString(rd.GetSqlValue(1));
            //        prayerRequest.SubmittedBy = Convert.ToString(rd.GetSqlValue(2));
            //        prayerRequest.SubmittedDate = Convert.ToString(rd.GetSqlValue(3));
            //        prayers.Add(prayerRequest);
            //    }
            //    connection.Close();
            //}
            return prayers;
        }

    }
}
