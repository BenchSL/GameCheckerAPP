using GameCheckerWpf.Commands;
using GameCheckerWpf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GameCheckerWpf.ViewModels
{
    public class GameDetailViewModel : BaseViewModel
    {
        private string appId;
        private string name;
        private string playtimeForever;
        private string imgIconUrl;
        private bool hasCommunityVisibleStats;

        public string AppId
        {
            get => appId;
            set { appId = value; OnPropertyChanged(nameof(AppId)); }
        }

        public string Name
        {
            get => name;
            set { name = value; OnPropertyChanged(nameof(Name)); }
        }

        public string PlayTimeForever
        {
            get => playtimeForever;
            set { playtimeForever = value; OnPropertyChanged(nameof(PlayTimeForever)); }
        }

        public string ImgIconUrl
        {
            get => imgIconUrl;
            set { imgIconUrl = value; OnPropertyChanged(nameof(ImgIconUrl)); }
        }
        public bool HasCommunityVisibleStats
        {
            get => hasCommunityVisibleStats;
            set { hasCommunityVisibleStats = value; OnPropertyChanged(nameof(HasCommunityVisibleStats)); }
        }

        public GameDetailViewModel(GameModel game)
        {
            AppId = game.Appid.ToString();
            Name = game.Name;
            playtimeForever = game.Playtime_forever.ToString();
            imgIconUrl = game.Img_icon_url;
            hasCommunityVisibleStats = game.Has_community_visible_stats;
        }
    }
}
