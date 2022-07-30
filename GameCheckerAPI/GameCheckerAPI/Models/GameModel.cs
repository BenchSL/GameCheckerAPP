using System.ComponentModel.DataAnnotations;

namespace GameCheckerAPI.Models
{
    public class GameModel
    {
        [Key]
        public int Id { get; set; }
        public int Appid { get; set; }
        public string Name { get; set; }
        public int Playtime_forever { get; set; }
        public string Img_icon_url { get; set; }
        public bool Has_community_visible_stats { get; set; }

        public GameModel() { }

        public GameModel(int id, string nam, int playtime, string img_icon, bool has_comm)
        {
            this.Appid = id;
            this.Name = nam;
            this.Playtime_forever = playtime;
            this.Img_icon_url = img_icon;
            this.Has_community_visible_stats = has_comm;
        }
    }
}
