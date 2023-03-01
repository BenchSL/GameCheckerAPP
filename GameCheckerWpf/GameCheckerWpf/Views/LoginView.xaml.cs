using GameCheckerWpf.Commands;
using GameCheckerWpf.Models;
using GameCheckerWpf.ViewModels;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GameCheckerWpf.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void Label_MouseEnter(object sender, MouseEventArgs e)
        {
            label_register.Foreground = Brushes.Red;
        }

        private void Label_MouseLeave(object sender, MouseEventArgs e)
        {
            label_register.Foreground = Brushes.White;
        }
    }
}
