using GameCheckerWpf.LoginValidation;
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
    /// Interaction logic for UserLoggedInView.xaml
    /// </summary>
    public partial class UserLoggedInView : UserControl
    {
        public UserLoggedInView()
        {
            InitializeComponent();
            DataContext = new LoggedUser();
        }

        private void btn_logout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("LOGGING OUT USER");
            logoutUser();
            this.Content = new MainViewModel();
        }

        private void logoutUser()
        {
            UserSession.isValid = false;
            UserSession.loggedUser = new UserModel();
        }
    }
}
