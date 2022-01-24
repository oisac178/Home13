﻿using System;
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
        private MainWindowVM mainWindowVM;

        public Window_CreateAcc(MainWindowVM mainWindowVM)
        {
            this.mainWindowVM = mainWindowVM;
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mainWindowVM.SelectClient.Accounts.Add("новый счет");
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            mainWindowVM.SelectClient.Accounts.Add("123");
        }
    }
}