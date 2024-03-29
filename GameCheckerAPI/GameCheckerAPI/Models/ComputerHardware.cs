﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GameCheckerAPI.Models
{
    public class ComputerHardware
    {
        [Key]
        public int id { get; set; }
        public string CPU { get; set; }
        public string RAM { get; set; }

        public string OS { get; set; }
        public string GraphicsCard { get; set; }

        public string guid { get; set; }

        public int RankingScale { get; set; }

        public ComputerHardware()
        {
        }

        public ComputerHardware(string CPU, string RAM, string OS, string GraphicsCard, string guid, int RankingScale)
        {
            this.CPU = CPU;
            this.RAM = RAM;
            this.OS = OS;
            this.GraphicsCard = GraphicsCard;
            this.guid = guid;
            this.RankingScale = RankingScale;
        }

        public override string ToString()
        {
            return $"CPU: {CPU}, RAM: {RAM} , OS: {OS}, GraphicsCard: {GraphicsCard}, Guid: {guid}, RankingScale: {RankingScale}";
        }
    }
}
