﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCheckerWpf.Models
{
    public class GameModel
    {
        public int id { get; set; }
        public int Appid { get; set; }
        public string Name { get; set; }
        public int Playtime_forever { get; set; }
        public string Img_icon_url { get; set; }
        public bool Has_community_visible_stats { get; set; }
        public string cpu { get; set; }
        public string gpu { get; set; }
        public string ram { get; set; }
        public bool canRun { get; set; }

        public GameModel() { }
        public GameModel(int Appid, string Name, int Playtime_forever, string Img_icon_url, bool Has_community_visible_stats,
            string cpu, string gpu, string ram, bool canRun)
        {
            this.Appid = Appid;
            this.Name = Name;
            this.Playtime_forever = Playtime_forever;
            this.Img_icon_url = Img_icon_url;
            this.Has_community_visible_stats = Has_community_visible_stats;
            this.cpu = cpu;
            this.gpu = gpu;
            this.ram = ram;
            this.canRun = canRun;
        }

        public override string ToString()
        {
            return $"Id: {id} | Title: {Name} | Playtime: {Playtime_forever} | Img: {Img_icon_url} | Community visible stats: {Has_community_visible_stats} |" +
                $"cpu : {cpu} | gpu: {gpu} | ram: {ram} | canRun: {canRun}";
        }
    }
}
