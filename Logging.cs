using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home13
{
    class Logging
    {
       
        public static void CreateLog(string data)
        {
            //Console.WriteLine($"Счет создан в {DateTime.Now.ToShortTimeString()}  {data}");
            data = $"Счет создан в {DateTime.Now.ToShortTimeString()}";
            File.WriteAllText("log777.txt", data, Encoding.GetEncoding("Windows-1251"));
        }
    }
}
