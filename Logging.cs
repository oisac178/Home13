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
        public void CreateLog()
        {
            var data = ***;
            SaveData processing = new SaveData(data);
            processing.SetProcess(e => File.WriteAllText("log777.txt", e));
        }
    }
}
