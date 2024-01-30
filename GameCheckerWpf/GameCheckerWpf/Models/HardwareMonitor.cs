using OxyPlot;
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
        private int countCpuInt;
        private int countMemoryInt;
        private string title;
        public IList<DataPoint> Points { get; private set; }

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

        public string Title
        {
            get { return title; }
            set 
            {
                title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        PerformanceCounter myAppCPU = new PerformanceCounter("Processor Information", "% Processor Time", "_Total");
        PerformanceCounter MyMem = new PerformanceCounter("Memory", "% Committed Bytes In Use");

        public HardwareMonitor()
        {
            timer_start1();
            timer_start2();

            this.Title = "Example 2";

            this.Points = new List<DataPoint>
            {
                new DataPoint(0, 4),
                new DataPoint(10, 13),
                new DataPoint(20, 15),
                new DataPoint(30, 16),
                new DataPoint(40, 12),
                new DataPoint(50, 12)
            };
        }

        private void timer_start1()
        {
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);

            dispatcherTimer.Start();
        }

        private void timer_start2()
        {
            System.Windows.Threading.DispatcherTimer dispatcherTimer1 = new System.Windows.Threading.DispatcherTimer(); //timer is used for real time charting
            dispatcherTimer1.Tick += DispatcherTimer1_Tick;
            dispatcherTimer1.Interval = new TimeSpan(0, 0, 10);

            dispatcherTimer1.Start();
        }

        private void DispatcherTimer_Tick(object? sender, EventArgs e)
        {
            CountCpuInt = (int)myAppCPU.NextValue() + 10;
            CountCpu = $"{CountCpuInt.ToString()}%";

            CountMemoryInt = (int)MyMem.NextValue() - 6;
            CountMemory = $"{CountMemoryInt.ToString()}%";
            //double infomem = getRandomAccessMemoryInfo();
            //double test = infomem / 100;
            //RealTimeCountMemoryUsage = test * infomem;

            //PerformanceTracker.Add(CountMemoryInt, RealTimeCountMemoryUsage*3);
        }

        private void DispatcherTimer1_Tick(object? sender, EventArgs e)
        {
            double infomem = getRandomAccessMemoryInfo();
            double decimalNum = infomem / 100;
            double memoryUsage = infomem * decimalNum;
            
            //performanceTracker.Add(CountMemoryInt, memoryUsage * 3); //dictionary key values cannot be matching
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
    }
}
