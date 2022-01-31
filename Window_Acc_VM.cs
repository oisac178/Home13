using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Home13
{
    public class Window_Acc_VM : ViewModelBase
    {
        private int sum;

        public int Sum
        {
            get => sum;
            set
            {
                sum = value;
                RaisePropertyChanged(nameof(Sum));
            }
        }

        private bool isDeposit;

        public bool IsDeposit
        {
            get { return isDeposit; }
            set
            {
                RaisePropertyChanged(nameof(IsDeposit));
                isDeposit = value;
            }
        }

        public ICommand CreateAccountCommand;
        public Window_Acc_VM(MainWindowVM mainWindowVM)
        {
            CreateAccountCommand = new RelayCommand((obj) =>
            {
                mainWindowVM.SelectClient.Accounts.Add("1");
            });
        }
    }
}
