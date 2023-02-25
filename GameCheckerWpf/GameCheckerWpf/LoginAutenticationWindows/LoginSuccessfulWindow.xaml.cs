﻿using GameCheckerWpf.Exceptions;
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

namespace GameCheckerWpf.LoginAutenticationWindows
{
    /// <summary>
    /// Interaction logic for LoginSuccessfulWindow.xaml
    /// </summary>
    public partial class LoginSuccessfulWindow : Window
    {
        public LoginSuccessfulWindow(UserFoundMessage userFoundMessage)
        {
            InitializeComponent();
            message_box.Text = userFoundMessage.Message;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void btn_next_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
