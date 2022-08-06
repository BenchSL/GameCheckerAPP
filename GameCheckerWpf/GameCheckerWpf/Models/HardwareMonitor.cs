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
        private string countCpu;
        private string countMemory;
        int countCpuInt;
        int countMemoryInt;

        public string CountCpu
        {
            get { return countCpu; }
            set 
            {
                countCpu = value;
                OnPropertyChanged(nameof(CountCpu));
            }
        }

        public string CountMemory
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

        public int CountCpuInt
        {
            get
            {
                return countCpuInt;
            }

            set
            {
                countCpuInt = value;
                OnPropertyChanged(nameof(CountCpuInt));
            }
        }

        public int CountMemoryInt
        {
            get
            {
                return countMemoryInt;
            }

            set
            {
                countMemoryInt = value;
                OnPropertyChanged(nameof(CountMemoryInt));
            }
        }

        private System.Timers.Timer _timer;
        PerformanceCounter myAppCPU = new PerformanceCounter("Process", "% Processor Time", Process.GetCurrentProcess().ProcessName, true);
        PerformanceCounter MyMem = new PerformanceCounter("Memory", "% Committed Bytes In Use");

        public HardwareMonitor()
        {
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            //Start the Timer
            dispatcherTimer.Start();
        }

        private void DispatcherTimer_Tick(object? sender, EventArgs e)
        {
            CountCpuInt = (int)myAppCPU.NextValue();
            CountCpu = $"{CountCpuInt.ToString()}%";

            CountMemoryInt = (int)MyMem.NextValue();
            CountMemory = $"{CountMemoryInt.ToString()}%";
        }
    }
}
