﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;


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
                if (isDeposit != null)
                {
                    RaisePropertyChanged(nameof(IsDeposit));
                    isDeposit = value;
                }
                
            }
        }

        ///public ICommand CreateAccountCommand { get; set; }

        private RelayCommand createAccountCommand;
        private MainWindowVM mainWindowVM;

        public static event Action<string> CreateAcc;
        public RelayCommand CreateAccountCommand
        {
            get
            {
                return createAccountCommand ??
                    (createAccountCommand = new RelayCommand((obj) =>
                    {
                        if (mainWindowVM.SelectClient != null)
                        {
                            mainWindowVM.SelectClient.Accounts.Add(new ClientAccount
                            {
                                Value = Sum,
                                Type = IsDeposit ? "Депозитный" : "Недепозитный",
                            }) ;
                        }
                        CreateAcc?.Invoke($"Счет создан в {DateTime.Now.ToShortTimeString()}");
                    }));
            }
        }
        
        public Window_Acc_VM(MainWindowVM mainWindowVM)
        {
            this.mainWindowVM = mainWindowVM;
        }
    }
}
