using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace GameCheckerWpf.Models
{
    public class ComputerHardware : BaseClass
    {
        private string operatingSystem;
        private string centralProcessingUnit;
        private string graphicsProcessingUnit;
        private string disc;
        private string motherboard;
        private string randomAccessMemory;

        public string OperatingSystem
        {
            get { return operatingSystem; }
            set
            {
                operatingSystem = value;
                OnPropertyChanged(nameof(OperatingSystem));
            }
        }

        public string MotherBoard
        {
            get { return motherboard; }
            set
            {
                motherboard = value;
                OnPropertyChanged(nameof(MotherBoard));
            }
        }

        public string GraphicCard
        {
            get { return graphicsProcessingUnit; }
            set
            {
                graphicsProcessingUnit = value;
                OnPropertyChanged(nameof(GraphicCard));
            }
        }

        public string Disc
        {
            get { return disc; }
            set
            {
                disc = value;
                OnPropertyChanged(nameof(Disc));
            }
        }

        public string CentralProcessingUnit
        {
            get { return centralProcessingUnit; }
            set
            {
                centralProcessingUnit = value;
                OnPropertyChanged(nameof(CentralProcessingUnit));
            }
        }

        public string RandomAccessMemory
        {
            get { return randomAccessMemory; }
            set
            {
                randomAccessMemory = value;
                OnPropertyChanged(nameof(RandomAccessMemory));
            }
        }

        public ComputerHardware() 
        {
            this.OperatingSystem = System.Environment.OSVersion.ToString();
            this.MotherBoard = getMotherBoardInfo();
            this.GraphicCard = getGraphicsCardInfo();
            this.CentralProcessingUnit = getProcessorInfo();
            this.randomAccessMemory = getRandomAccessMemoryInfo();
        }

        public override string ToString()
        {
            return $"OS: {OperatingSystem} | CPU: {CentralProcessingUnit} | GPU: {GraphicCard} | Disc: {Disc} | Motherboard: {MotherBoard} | RAM: {RandomAccessMemory}";
        }

        private string getGraphicsCardInfo()
        {
            ManagementObjectSearcher myGraphicsCard = new ManagementObjectSearcher("select * from Win32_VideoController");

            string graphicsName = "";

            foreach(ManagementObject obj in myGraphicsCard.Get())
            {
                graphicsName = obj["Name"].ToString();
            }

            return graphicsName;
        }

        private string getMotherBoardInfo()
        {
            SelectQuery Sq = new SelectQuery("Win32_MotherboardDevice");
            ManagementObjectSearcher objOSDetails = new ManagementObjectSearcher(Sq);
            ManagementObjectCollection osDetailsCollection = objOSDetails.Get();
            StringBuilder sb = new StringBuilder();

            string motherboardInfo = "";

            foreach (ManagementObject mo in osDetailsCollection)
            {
                motherboardInfo = (string)mo["Name"] + " GA-H61M";
            }
            return motherboardInfo;
        }

        private string getProcessorInfo()
        {
            ManagementObjectSearcher myProcessor = new ManagementObjectSearcher("select * from Win32_Processor");

            string myProcessorName = "";

            foreach (ManagementObject obj in myProcessor.Get())
            {
                myProcessorName = obj["Name"].ToString();
            }

            return myProcessorName;
        }

        private string getRandomAccessMemoryInfo()
        {
            ManagementObjectSearcher ramSearcher = new ManagementObjectSearcher("select * from Win32_OperatingSystem");

            string myRAMsize = "";

            foreach(ManagementObject ramObj in ramSearcher.Get())
            {
                myRAMsize = ramObj["TotalVirtualMemorySize"].ToString();
            }

            int ramInt = int.Parse(myRAMsize);
            int totalInt = (ramInt / 1000000)-2;
            myRAMsize = totalInt.ToString() + "GB";

            return myRAMsize;
        }
       }
    }
