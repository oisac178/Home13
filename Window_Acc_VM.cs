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
        private ulong sum;

        public ulong Sum
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
        private string data;
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
                        CreateAcc?.Invoke("data");
                    }));
            }
        }
        
        public Window_Acc_VM(MainWindowVM mainWindowVM)
        {
           
            this.mainWindowVM = mainWindowVM;
            CreateAcc += Logging.CreateLog;
            
            ThrowException();
        }

        public static void ThrowException()
        {
            try
            {
                throw new SomethingException("Вы ввели не 16-значное число");
            }
            catch (SomethingException e)
            {
                Console.WriteLine($"Ошибка ввода числа {e.Message}");
            }
        }
    }
}
