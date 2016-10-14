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
    }
}
