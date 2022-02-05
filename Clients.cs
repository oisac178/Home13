using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Home13
{
    public class Client : ViewModelBase
    {
        public string Name { get; set; }
        public string Acc { get; set; }
        public uint Total { get; set; }

        private ObservableCollection<ClientAccount> observableCollection = new ObservableCollection<ClientAccount>();
        public ObservableCollection<ClientAccount> Accounts
        {
            get => observableCollection;
            set
            {
                observableCollection = value;
                RaisePropertyChanged(nameof(Accounts));
            }
        }
    }
}
