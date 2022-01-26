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
        public ObservableCollection<Client> People { 
            get => people;
            set
            {
                people = value;
                RaisePropertyChanged(nameof(People));
            }
        }
        private Client selectClient;
        private ILoad saveData;
        private string json;

        public string Json => json;
        public MainWindowVM(ILoad load)
        {
            saveData = load;
            if (File.Exists(saveData.Path))
            {
                json = File.ReadAllText(saveData.Path);
                List<Client> clients = load.ClientsFromJSON();
                People = new ObservableCollection<Client>(clients);

            }
            
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
        private uint total;
        private ObservableCollection<Client> people = new ObservableCollection<Client>();

        public string Name
        {
            get { return name; }
            set
            {
                RaisePropertyChanged(nameof(Name));
                name = value;
            }
        }

        public uint Total
        {
            get { return total; }
            set
            {
                RaisePropertyChanged(nameof(Total));
                total = value;
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
                        new Window_CreateAcc(this).Show();
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
                        saveData.ClientsToJSON(People.ToList());
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
