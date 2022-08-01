using System;
using System.Collections.Generic;
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

namespace GameCheckerWpf.Views
{
    /// <summary>
    /// Interaction logic for HardwareMonitor.xaml
    /// </summary>
    public partial class HardwareMonitor : UserControl
    {
        private System.Timers.Timer _timer;

        public HardwareMonitor()
        {
            InitializeComponent();
            _timer = new System.Timers.Timer();
            _timer.Interval = 3000; //set timer to 1 second
            _timer.Elapsed += OntimedEvent;
            _timer.AutoReset = true;
           
        }

        private void btn_start_Click(object sender, RoutedEventArgs e)
        {
            _timer.Enabled = true;
        }

        private void OntimedEvent(object sender, ElapsedEventArgs e)
        {
            //monitor and get the values of the CPU and MEMORY
            int cpuValue = getCpuValue();
            int memValue = getMemValue();

            prog_cpu.Value = cpuValue;
            prog_mem.Value = memValue;
        }

        private int getCpuValue()
        {
            var cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_total");
            cpuCounter.NextValue();
            System.Threading.Thread.Sleep(1000);
            int returnvalue = (int)cpuCounter.NextValue();
            return returnvalue;
        }

        private int getMemValue()
        {
            var memCounter = new PerformanceCounter("Memory", "% Committed Bytes in Use");
            int returnvalue = (int)memCounter.NextValue();
            return returnvalue;
        }
    }
}
