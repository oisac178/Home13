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

        private static readonly ObservableCollection<string> observableCollection = new ObservableCollection<string>();
        public ObservableCollection<string> Accounts { get; set; } = observableCollection;
    }
}
