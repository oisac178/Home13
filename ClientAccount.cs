using System.ComponentModel;

namespace Home13
{
    public class ClientAccount : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        //public string Type { get; set; }
        //public int Value { get; set; }

        public string typeAcc;
        public string Type
        {
            get { return this.typeAcc; }
            set
            {
                this.typeAcc = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Type)));
            }
        }

        public ulong value;
        public ulong Value
        {
            get { return this.value; }
            set
            {
                this.value = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Value)));
            }
        }
    }
}
