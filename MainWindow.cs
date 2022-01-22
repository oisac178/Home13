using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Home13
{
    public partial class MainWindow : Window
    {
        private readonly MainWindowVM mainWindowVM;

        public MainWindow(MainWindowVM mainWindowVM)
        {
            InitializeComponent();
            this.mainWindowVM = mainWindowVM;
            DataContext = mainWindowVM;
        }
    }    
}
