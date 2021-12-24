using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.IO;

namespace Home13
{
    public class MainWindowVM : ViewModelBase
    {
        public List<Client> People { get; set; } = new List<Client>();
        private Client selectClient;
        private ILoad saveData;

        public MainWindowVM(ILoad load)
        {
            List<Client> clients = load.ClientsFromJSON();
            People.Add(List < Client > clients);
        }
        public ILoad LoadWriteData
        {
            get { return this.saveData; }
            set
            {
                if (this.saveData != value)
                {
                    this.saveData = value;
                }
            }
        }
        private RelayCommand addCommand;
        private RelayCommand delCommand;
        private RelayCommand openCommand;
        private RelayCommand closeCommand;
        private RelayCommand saveCommand;

        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                RaisePropertyChanged(nameof(Name));
                name = value;
            }
        }
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                    (addCommand = new RelayCommand(obj =>
                    {
                        Client client = new Client { Name = this.Name};
                        People.Add(client);
                    }));
            }
        }
        public RelayCommand DelCommand
        {
            get
            {
                return delCommand ??
                    (delCommand = new RelayCommand(obj =>
                    {
                        People.Remove(SelectClient);
                    }));
            }
        }

        public RelayCommand OpenCommand
        {
            get
            {
                return openCommand ??
                    (openCommand = new RelayCommand(obj =>
                    {

                    }));
            }
        }

        public RelayCommand CloseCommand
        {
            get
            {
                return closeCommand ??
                    (closeCommand = new RelayCommand(obj =>
                    {

                    }));
            }
        }

        public RelayCommand SaveCommand
        {
            get
            {
                return saveCommand ??
                    (saveCommand = new RelayCommand(obj =>
                    {
                        ILoad.ClientsToJSON(List < Client > People);
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
