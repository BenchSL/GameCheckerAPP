using GameCheckerAPI.Models;
using System.Management;
using System.Text;

namespace GameCheckerAPI.Helper
{
    public class HardwareHelper
    {
        private static int GUID_LENGTH = 10;

        public static ComputerHardware getCurrentHardware()
        {
            HardwareHelper helper = new HardwareHelper();
            ComputerHardware thisHardware = new ComputerHardware();
            thisHardware.GraphicsCard = helper.getGraphicsCardInfo();
            thisHardware.CPU = helper.getProcessorInfo();
            thisHardware.RAM = helper.getRandomAccessMemoryInfo();
            thisHardware.OS = helper.getOS();
            thisHardware.guid = MethodHelper.generateGuid(GUID_LENGTH);
            return thisHardware;
        }

        public string getOS()
        { 
            string os = System.Environment.OSVersion.ToString();
            if (os != null)
            {
                return os;
            }
            return "";
        }

        public string getGraphicsCardInfo()
        {
            ManagementObjectSearcher myGraphicsCard = new ManagementObjectSearcher("select * from Win32_VideoController");

            string graphicsName = "";

            foreach (ManagementObject obj in myGraphicsCard.Get())
            {
                graphicsName = obj["Name"].ToString();
            }

            return graphicsName;
        }

        public string getMotherBoardInfo()
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

        public string getProcessorInfo()
        {
            ManagementObjectSearcher myProcessor = new ManagementObjectSearcher("select * from Win32_Processor");

            string myProcessorName = "";

            foreach (ManagementObject obj in myProcessor.Get())
            {
                myProcessorName = obj["Name"].ToString();
            }

            return myProcessorName;
        }

        public string getRandomAccessMemoryInfo()
        {
            ManagementObjectSearcher ramSearcher = new ManagementObjectSearcher("select * from Win32_OperatingSystem");

            string myRAMsize = "";

            foreach (ManagementObject ramObj in ramSearcher.Get())
            {
                myRAMsize = ramObj["TotalVirtualMemorySize"].ToString();
            }

            int ramInt = int.Parse(myRAMsize);
            int totalInt = (ramInt / 1000000) - 2;
            myRAMsize = totalInt.ToString() + "GB";

            return myRAMsize;
        }
    }
}
