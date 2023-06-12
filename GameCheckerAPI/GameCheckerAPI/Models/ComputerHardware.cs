using System.Text.Json.Serialization;

namespace GameCheckerAPI.Models
{
    public class ComputerHardware
    {
        [JsonPropertyName("id")]
        public int id { get; set; }

        [JsonPropertyName("CPU")]
        public string CPU { get; set; }

        [JsonPropertyName("RAM")]
        public string RAM { get; set; }

        [JsonPropertyName("OS")]
        public string OS { get; set; }

        [JsonPropertyName("GraphicsCard")]
        public string GraphicsCard { get; set; }

        [JsonPropertyName("guid")]
        public string guid { get; set; }

        public ComputerHardware()
        {
        }

        public ComputerHardware(string CPU, string RAM, string OS, string GraphicsCard, string guid)
        {
            this.CPU = CPU;
            this.RAM = RAM;
            this.OS = OS;
            this.GraphicsCard = GraphicsCard;
            this.guid = guid;
        }

        public override string ToString()
        {
            return $"CPU: {CPU}, RAM: {RAM} , OS: {OS}, GraphicsCard: {GraphicsCard}, Guid: {guid}";
        }
    }
}
