using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Home13
{
    /// <summary>
    /// Логика взаимодействия для Window_CreateAcc.xaml
    /// </summary>
    public partial class Window_CreateAcc : Window
    {
        private Window_Acc_VM window_Acc_VM;
        private MainWindowVM mainWindowVM;
        public Window_CreateAcc(MainWindowVM mainWindowVM)
        {
            this.DataContext = window_Acc_VM;
            this.mainWindowVM = mainWindowVM;
            this.DataContext = new Window_Acc_VM(mainWindowVM);
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton pressed = sender as RadioButton;
            if (pressed !=null && pressed.IsChecked == true)
            {
                window_Acc_VM.IsDeposit = true;
            }
        }
        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            RadioButton pressed = sender as RadioButton;
            if (pressed != null && pressed.IsChecked == true)
            {
                window_Acc_VM.IsDeposit = false;
            }
        }
    }
}
