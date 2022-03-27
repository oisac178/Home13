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
            data = $"Счет создан в {DateTime.Now.ToShortTimeString()}";
            File.AppendAllText("log777.txt", data + Environment.NewLine, Encoding.GetEncoding("Windows-1251"));
        }
    }
}
