using System.Xml.Serialization;

namespace GameCheckerAPI.Models
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
}
