//using ConsoleApp.Models;
using ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Services
{
    public class ImportCsvService
    {
        public List<Medical_institution> LoadFormFile(string filePath)
        {
            List<Medical_institution> result = new List<Medical_institution>();
            string[] lines = System.IO.File.ReadAllLines(filePath);

            result = lines
                .ToList()
                .Skip(1)
                .Select(x =>
                {
                    var columns = x.Split(',');
                    var item = new Medical_institution()
                    {
                        十碼章 = columns[0],
                        醫院名稱 = columns[1],
                        行政區 = columns[2],
                        地址 = columns[3],
                        連絡電話 = columns[4],
                        座標緯度 = columns[5],
                        座標經度 = columns[6]
                    };

                    return item;
                }).ToList();

            return result;
            //return cameras.ToList();
            ////return Newtonsoft.Json.JsonConvert.DeserializeObject<List<Activity>>(str);
        }
    }
}
