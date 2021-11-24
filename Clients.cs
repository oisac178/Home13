﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Home13
{
    public class Clients
    {
        public string Name { get; set; }
        public string Acc { get; set; }
        public uint Total { get; set; }
        public ObservableCollection<Clients> People { get; set; } = new ObservableCollection<Clients>();
    }
}