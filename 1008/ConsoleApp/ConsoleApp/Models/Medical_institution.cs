using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Models
{
    public class Medical_institution
    {
        
        public string 十碼章 { get; set; }
        public string 醫院名稱 { get; set; }
        public string 行政區 { get; set; }
        public string 地址 { get; set; }
        public string 連絡電話 { get; set; }
        public string 座標緯度 { get; set; }
        public string 座標經度 { get; set; }


        public Dictionary<string, string> Datas { get; set; }


        public Medical_institution()
        {

            this.Datas = new Dictionary<string, string>();
        }
    }
}
