namespace GameCheckerAPI.Models
{
    public class ComputerHardware
    {
        public int id { get; set; }
        public string CPU { get; set; }
        public string RAM { get; set; }
        public string OS { get; set; }
        public string GraphicsCard { get; set; }
        public string DiskSpaceRequired { get; set; }

        public ComputerHardware()
        {
        }

        public ComputerHardware(string CPU, string RAM, string OS, string GraphicsCard, string DiskSpaceRequired)
        {
            this.CPU = CPU;
            this.RAM = RAM;
            this.OS = OS;
            this.GraphicsCard = GraphicsCard;
            this.DiskSpaceRequired = DiskSpaceRequired;
        }

        public override string ToString()
        {
            return $"CPU: {CPU}, RAM: {RAM} , OS: {OS}, GraphicsCard: {GraphicsCard}, Disk space req: {DiskSpaceRequired}";
        }
    }
}
