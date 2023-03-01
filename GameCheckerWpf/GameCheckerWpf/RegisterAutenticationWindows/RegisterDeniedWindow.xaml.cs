using GameCheckerWpf.Exceptions;
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

namespace GameCheckerWpf.RegisterAutenticationWindows
{
    /// <summary>
    /// Interaction logic for RegisterDeniedWindow.xaml
    /// </summary>
    public partial class RegisterDeniedWindow : Window
    {
        public RegisterDeniedWindow(PasswordNotMatchMessage passwordNotMatchMessage)
        {
            InitializeComponent();
            exception_box.Text = passwordNotMatchMessage.Message;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
