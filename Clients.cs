using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Home13
{
    public class Client
    {
        public string Name { get; set; }
        public string Acc { get; set; }
        public uint Total { get; set; }

        public List<string> Accounts = new List<string>();
    }
}
