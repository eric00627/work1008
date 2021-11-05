using ConsoleApp.Services;
using ConsoleApp.Utils;
using System;
using System.Linq;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args) 
        {
            var csvService = new ImportCsvService();
            DataService dataService = new DataService();
            var csvDatas = csvService.LoadFormFile(Utils.FilePath.GetFullPath("流感疫苗接種合約醫療院所.csv"));

            csvDatas.ForEach(i =>
            {
                dataService.Insert(i);
            });

            
            var rows = dataService.GetMedical_institution();
            var groupDatas = csvDatas.GroupBy(x => x.行政區, y => y).ToList();
            Console.WriteLine(string.Format("分析完成，共有{0}筆資料", rows.Count));
            rows.ForEach(x =>
            {
                Console.WriteLine($"醫院名稱 :{x.醫院名稱} 行政區 :{x.行政區} 地址:{x.地址}");
            });

            Console.ReadKey();
            /*string fullfileName = FilePath.GetFullPath("流感疫苗接種合約醫療院所.csv");

            var csvService = new ConsoleApp.Services.ImportCsvService();
            var csvDatas = csvService.LoadFormFile(fullfileName);
           
            
            groupDatas.ForEach(x =>
            {
                var items = x.ToList();
                Console.WriteLine($"行政區 :{x.Key} 數量:{x.ToList().Count}");
                items.ForEach(x =>
                {
                    Console.WriteLine($"醫院名稱 :{x.醫院名稱} 行政區 :{x.行政區} 地址:{x.地址}");
                });
            });*/
        }
    }
}
