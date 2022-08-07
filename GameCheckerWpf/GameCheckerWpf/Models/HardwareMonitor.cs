using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
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
        double realTimeCountMemoryUsage;
        double realTimeCountCPUUsage;
        Dictionary<int, double> performanceTracker;

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
        public double RealTimeCountMemoryUsage
        {
            get { return realTimeCountMemoryUsage; }
            set
            {
                realTimeCountMemoryUsage = value;
                OnPropertyChanged(nameof(RealTimeCountMemoryUsage));
            }
        }
        public double RealTimeCountCpuUsage
        {
            get { return realTimeCountCPUUsage; }
            set
            {
                realTimeCountCPUUsage = value;
                OnPropertyChanged(nameof(RealTimeCountCpuUsage));
            }
        }
        public Dictionary<int, double> PerformanceTracker
        {
            get { return performanceTracker; }
            set
            {
                performanceTracker = value;
                OnPropertyChanged(nameof(PerformanceTracker));
            }
        }

        private System.Timers.Timer _timer;
        PerformanceCounter myAppCPU = new PerformanceCounter("Process", "% Processor Time", Process.GetCurrentProcess().ProcessName, true);
        PerformanceCounter MyMem = new PerformanceCounter("Memory", "% Committed Bytes In Use");

        public HardwareMonitor()
        {
            PerformanceTracker = new Dictionary<int, double>();
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
            double infomem = getRandomAccessMemoryInfo();
            double test = infomem / 100;
            RealTimeCountMemoryUsage = test * infomem;

            PerformanceTracker.Add(CountMemoryInt, RealTimeCountMemoryUsage*3);
        }

        private int getRandomAccessMemoryInfo()
        {
            ManagementObjectSearcher ramSearcher = new ManagementObjectSearcher("select * from Win32_OperatingSystem");

            string myRAMsize = "";

            foreach (ManagementObject ramObj in ramSearcher.Get())
            {
                myRAMsize = ramObj["TotalVirtualMemorySize"].ToString();
            }

            int ramInt = int.Parse(myRAMsize);
            int totalInt = (ramInt / 1000000);

            return totalInt;
        }

        private Dictionary<int, double> returnDictionaryTest()
        {
            return PerformanceTracker;
        }
    }
}
