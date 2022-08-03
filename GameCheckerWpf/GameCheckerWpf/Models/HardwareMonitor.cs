using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace GameCheckerWpf.Models
{
    public class HardwareMonitor : BaseClass
    {
        private double countCpu;
        private double countMemory;

        public double CountCpu
        {
            get { return countCpu; }
            set 
            {
                countCpu = value;
                OnPropertyChanged(nameof(CountCpu));
            }
        }

        public double CountMemory
        {
            get
            {
                return countMemory;
            }

            set
            {
                countMemory = value;
                OnPropertyChanged(nameof(CountMemory));
            }
        }

        private System.Timers.Timer _timer;
        PerformanceCounter myAppCPU = new PerformanceCounter("Process", "% Processor Time", Process.GetCurrentProcess().ProcessName, true);
        PerformanceCounter MyMem = new PerformanceCounter("Memory", "% Committed Bytes In Use");

        public HardwareMonitor()
        {
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            //Check the CPU every 3 seconds
            dispatcherTimer.Interval = new TimeSpan(0, 0, 3);
            //Start the Timer
            dispatcherTimer.Start();
        }

        private void DispatcherTimer_Tick(object? sender, EventArgs e)
        {
            CountCpu = myAppCPU.NextValue();
            CountMemory = MyMem.NextValue();
        }
    }
}
