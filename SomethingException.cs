using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home13
{
    class SomethingException : Exception
    {
        private Window_Acc_VM window_Acc_VM;
        private MainWindowVM mainWindowVM;
        public string SomethingMessage { get; set; }
        public SomethingException(string Msg)
        {
            window_Acc_VM = new Window_Acc_VM(mainWindowVM);
            if (window_Acc_VM.Sum > 9999999999999999 || window_Acc_VM.Sum < 1000000000000000)
            {
                this.SomethingMessage = Msg;
            }
        }
    }
}
