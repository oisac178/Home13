using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Home13
{
    public class Window_Acc_VM : ViewModelBase
    {
        public ObservableCollection<Client> People
        {
            get => people;
            set
            {
                people = value;
                RaisePropertyChanged(nameof(People));
            }
        }

        private RelayCommand createCommand;
        private Client selectClient;
        private uint total;
        private ObservableCollection<Client> people = new ObservableCollection<Client>();

        public uint Total
        {
            get { return total; }
            set
            {
                RaisePropertyChanged(nameof(Total));
                total = value;
            }
        }

        public RelayCommand CreateCommand
        {
            get
            {
                return createCommand ??
                    (createCommand = new RelayCommand(obj =>
                    {
                        Client client = new Client { Total = this.Total };
                        People.Add(client);
                    }));
            }
        }

        public Client SelectClient
        {
            get { return selectClient; }
            set
            {
                selectClient = value;
                RaisePropertyChanged(nameof(SelectClient));
            }
        }
    }
}
