using System;
using System.Collections.Generic;

#nullable disable

namespace GameDatabaseFiller.ClassesM
{
    public partial class GameModel
    {
        public int Id { get; set; }
        public int Appid { get; set; }
        public string Name { get; set; }
        public int PlaytimeForever { get; set; }
        public string ImgIconUrl { get; set; }
        public bool HasCommunityVisibleStats { get; set; }
    }
}
