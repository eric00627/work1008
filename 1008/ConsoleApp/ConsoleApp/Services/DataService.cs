using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.Models;
namespace ConsoleApp.Services
{
    public class DataService {
        private string _connectionString = @"Server=DESKTOP-FP5B1VH\SQLEXPRESS;Database=NKUST;Trusted_Connection=True";

        public List<Medical_institution> GetMedical_institution()
        {
            var result = new List<Medical_institution>();
            var cn = new SqlConnection(_connectionString);
            cn.Open();
            SqlCommand command = new SqlCommand("Select * from Medical_institution", cn);
            var indexer = command.ExecuteReader();
            while (indexer.Read())
            {               
                var Id = indexer["id"];
                var Ten_num_code = indexer["ten_num_code"];
                var Name = indexer["name"];
                var Administrative_District = indexer["administrative_district"];
                var Address = indexer["address"];
                var Telephone = indexer["telephone"];
                var item = new Medical_institution()
                {
                    十碼章 = Ten_num_code.ToString(),
                    醫院名稱 = Name.ToString(),
                    行政區 = Administrative_District.ToString(),
                    地址 = Address.ToString(),
                    連絡電話 = Telephone.ToString()                    
                };
                
            }
            cn.Close();
            return result;
        }
        public void Insert(Medical_institution medical_Institution)
        {
           var commandString = @"INSERT INTO[dbo].
[Medical_institution] ([ten_num_code] ,[name] ,[administrative_district],[address],[telephone])
VALUES(@ten_num_code,@name, @administrative_district, @address, @telephone)";
           
            var cn = new SqlConnection(_connectionString);

           cn.Open();

           SqlCommand command = new SqlCommand(commandString, cn);
           command.Parameters.Add(new SqlParameter("ten_num_code", medical_Institution.十碼章));
           command.Parameters.Add(new SqlParameter("name", medical_Institution.醫院名稱));
           command.Parameters.Add(new SqlParameter("administrative_district",medical_Institution.行政區));
           command.Parameters.Add(new SqlParameter("address", medical_Institution.地址));
           command.Parameters.Add(new SqlParameter("telephone", medical_Institution.連絡電話));
           var count = command.ExecuteNonQuery();
           
           cn.Close();
        }

    }
}
