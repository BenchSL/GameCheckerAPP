using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace GameCheckerWpf.Views
{
    /// <summary>
    /// Interaction logic for HardwareMonitor.xaml
    /// </summary>
    public partial class HardwareMonitor : UserControl
    {
        public HardwareMonitor()
        {
            InitializeComponent();
            DataContext = new GameCheckerWpf.Models.HardwareMonitor();
        }

        private void btn_start_Click(object sender, RoutedEventArgs e)
        {
            //_timer.Enabled = true;
        }
    }

    
}
