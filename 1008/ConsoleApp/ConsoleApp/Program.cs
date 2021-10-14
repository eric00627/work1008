using ConsoleApp.Utils;
using System;
using System.Linq;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string fullfileName=FilePath.GetFullPath("流感疫苗接種合約醫療院所.csv");

            var csvService = new ConsoleApp.Services.ImportCsvService();
            var csvDatas = csvService.LoadFormFile(fullfileName);
            Console.WriteLine(string.Format("分析完成，共有{0}筆資料", csvDatas.Count));
            var groupDatas = csvDatas.GroupBy(x => x.行政區, y => y).ToList();
            groupDatas.ForEach(x =>
            {
                var items = x.ToList();
                Console.WriteLine($"行政區 :{x.Key} 數量:{x.ToList().Count}");
                items.ForEach(x =>
                {
                    Console.WriteLine($"醫院名稱 :{x.醫院名稱} 行政區 :{x.行政區} 地址:{x.地址}");
                });
            });
            Console.ReadKey();
        }
    }
}
