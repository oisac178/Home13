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
        public string SomethingMessage { get; set; }
        public SomethingException(string Msg)
        {
            this.SomethingMessage = Msg;
        }
    }
}
