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

namespace Home13
{
    public class MainWindowVM : ViewModelBase
    {
        public ObservableCollection<Clients> People { get; set; } = new ObservableCollection<Clients>();
        private Clients selectDepart;
        private ILoad saveData;

        public MainWindowVM(ILoad load)
        {
            saveData = load;
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
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                    (addCommand = new RelayCommand(obj =>
                    {
                    
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
                        
                    }));
            }
        }

        public Clients SelectDepart
        {
            get { return selectDepart; }
            set
            {
                selectDepart = value;
                RaisePropertyChanged(nameof(SelectDepart));
            }
        }

       
    }
}
