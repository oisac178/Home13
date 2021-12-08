using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Home13
{
    public partial class App: Application 
    {
        private ILoad load;

        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindowVM mainViewModel = new MainWindowVM(load);
            MainWindow mainWindow = new MainWindow(mainViewModel);
            mainWindow.Show();

            base.OnStartup(e);
        }
    }
}
