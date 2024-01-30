namespace GameCheckerAPI.Models
{
    /* Requirements needed to run a game are specified in this model.
     */
    public class Specification
    {
        public int id { get; set; }
        public string CPU { get; set; }
        public string RAM { get; set; }
        public string OS { get; set; }
        public string GraphicsCard { get; set; }
        public string DiskSpaceRequired { get; set; }
        public int RankingScale { get; set; }

        public Specification()
        {
        }

        public Specification(string CPU, string RAM, string OS, string GraphicsCard, string DiskSpaceRequired, int RankingScale)
        {
            this.CPU = CPU;
            this.RAM = RAM;
            this.OS = OS;
            this.GraphicsCard = GraphicsCard;
            this.DiskSpaceRequired = DiskSpaceRequired;
            this.RankingScale = RankingScale;
        }

        public override string ToString()
        {
            return $"CPU: {CPU}, RAM: {RAM} , OS: {OS}, GraphicsCard: {GraphicsCard}, Disk space req: {DiskSpaceRequired}, Ranking scale {RankingScale}";
        }
    }
}
