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

namespace GameCheckerWpf.MenuControl
{
    /// <summary>
    /// Interaction logic for MenuBar.xaml
    /// </summary>
    public partial class MenuBar : UserControl
    {
        NavigationService navigationService;
        public MenuBar()
        {
            InitializeComponent();
        }
        
        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            navigationService.Navigate("/Views/LoginWindow.xaml");
        }

        private void btn_performance_Click(object sender, RoutedEventArgs e)
        {
            navigationService.Navigate("/Views/PerformanceWindow.xaml");
        }
    }
}
