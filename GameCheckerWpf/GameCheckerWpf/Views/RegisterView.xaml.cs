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
    /// Interaction logic for RegisterView.xaml
    /// </summary>
    public partial class RegisterView : UserControl
    {
        public RegisterView()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel();
        }

        private void btn_register_Click(object sender, RoutedEventArgs e)
        {
            txt_userName.Clear();
            txt_passWord.Clear();
            txt_email.Clear();
            txt_confirmPassWord.Clear();
        }
    }
}
