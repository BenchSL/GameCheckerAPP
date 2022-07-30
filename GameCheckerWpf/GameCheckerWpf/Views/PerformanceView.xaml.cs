using GameCheckerWpf.Models;
using GameCheckerWpf.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
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
using System.Data;

namespace GameCheckerWpf.Views
{
    /// <summary>
    /// Interaction logic for PerformanceView.xaml
    /// </summary>
    public partial class PerformanceView : UserControl
    {
        private readonly HttpClient client;
        private GameService gameService;

        public PerformanceView()
        {
            InitializeComponent();
            this.DataContext = new ComputerHardware();
            client = new HttpClient();
            gameService = new GameService(client);
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            dataGame.ItemsSource = (await gameService.getGames()).ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
