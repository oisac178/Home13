using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Home13
{
    public class Clients
    {
        public string Name { get; set; }
        public uint Acc1 { get; set; }
        public uint Acc2 { get; set; }
        public ObservableCollection<Clients> People { get; set; } = new ObservableCollection<Clients>();
    }
}
