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
            string query = "SELECT * FROM PrayerRequest order by 1 desc";
            string connectionString = "Data Source=HBMSEA-BATTAGAN;Initial Catalog=Prayer;Integrated Security=true;";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            
            if (connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand command = new SqlCommand(query);
                command.Connection = connection;
                SqlDataReader rd = command.ExecuteReader();

                while (rd.Read())
                {
                    PrayerRequest prayerRequest = new PrayerRequest();
                    prayerRequest.PrayerText = Convert.ToString(rd.GetSqlValue(1));
                    prayerRequest.SubmittedBy = Convert.ToString(rd.GetSqlValue(2));
                    prayerRequest.SubmittedDate = Convert.ToString(rd.GetSqlValue(3));
                    prayers.Add(prayerRequest);
                }
                connection.Close();
            }
            return prayers;
        }

    }
}
