using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GameDatabaseFiller.ClassesM
{
    public class GameConverter
    {
		[XmlRoot(ElementName = "message")]
		public class Message
		{

			[XmlElement(ElementName = "appid")]
			public int Appid { get; set; }

			[XmlElement(ElementName = "name")]
			public string Name { get; set; }

			[XmlElement(ElementName = "playtime_forever")]
			public int PlaytimeForever { get; set; }

			[XmlElement(ElementName = "img_icon_url")]
			public string ImgIconUrl { get; set; }

			[XmlElement(ElementName = "has_community_visible_stats")]
			public bool HasCommunityVisibleStats { get; set; }

			[XmlElement(ElementName = "playtime_windows_forever")]
			public int PlaytimeWindowsForever { get; set; }

			[XmlElement(ElementName = "playtime_mac_forever")]
			public int PlaytimeMacForever { get; set; }

			[XmlElement(ElementName = "playtime_linux_forever")]
			public int PlaytimeLinuxForever { get; set; }
		}

		[XmlRoot(ElementName = "games")]
		public class Games
		{

			[XmlElement(ElementName = "message")]
			public List<Message> Message { get; set; }
		}

		[XmlRoot(ElementName = "response")]
		public class Response
		{

			[XmlElement(ElementName = "game_count")]
			public int GameCount { get; set; }

			[XmlElement(ElementName = "games")]
			public Games Games { get; set; }
		}
	}
}
