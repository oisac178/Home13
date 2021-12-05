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
        private SaveData saveData;

        public MainWindowVM(ILoad load)
        {
            saveData = load;
        }
        public SaveData LoadWriteData
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
                    Department departament = new Department { Name = "2345" };
                    for (int i = 1; i < 10; i++)
                    {
                        departament.Employee.Add(new Human("имя"+i, "фамилия"+i, "должность"+i, 1000));
                    }    
                    if (!Inner.Any())
                        {
                            Inner.Add(departament);
                        }
                    else
                        {
                            departament.Name = "{111555}";
                            SelectDepart?.Inner.Add(departament);
                        }
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
                        Department departament = new Department();
                        Inner.Remove(departament);
                        SelectDepart = departament;
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
