using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Services
{
    public class DataService {
        private string _connectionString = @"Server=DESKTOP-FP5B1VH\SQLEXPRESS;Database=NKUST;Trusted_Connection=True";

        public void GetMedical_institution()
        {
            var cn = new SqlConnection(_connectionString);
            cn.Open();
            SqlCommand command = new SqlCommand("Select * from Medical_institution", cn);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var id = reader["十碼章"];
                var name = reader["醫院名稱"];
                var Administrative_District = reader["行政區"];
                var address = reader["地址"];
                var telephone = reader["連絡電話"];

            }
            cn.Close();
        }


    }
}
