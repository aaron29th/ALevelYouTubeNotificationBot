using System.Xml.Serialization;

namespace YoutubeNotifyBot.Models.Youtube
{
	[XmlRoot(ElementName="entry", Namespace="http://www.w3.org/2005/Atom")]
	public class PubSubEntry {
		[XmlElement(ElementName="id", Namespace="http://www.w3.org/2005/Atom")]
		public string Id { get; set; }
		[XmlElement(ElementName="videoId", Namespace="http://www.youtube.com/xml/schemas/2015")]
		public string VideoId { get; set; }
		[XmlElement(ElementName="channelId", Namespace="http://www.youtube.com/xml/schemas/2015")]
		public string ChannelId { get; set; }
		[XmlElement(ElementName="title", Namespace="http://www.w3.org/2005/Atom")]
		public string Title { get; set; }
		[XmlElement(ElementName="link", Namespace="http://www.w3.org/2005/Atom")]
		public PubSubLink Link { get; set; }
		[XmlElement(ElementName="author", Namespace="http://www.w3.org/2005/Atom")]
		public PubSubAuthor Author { get; set; }
		[XmlElement(ElementName="published", Namespace="http://www.w3.org/2005/Atom")]
		public string Published { get; set; }
		[XmlElement(ElementName="updated", Namespace="http://www.w3.org/2005/Atom")]
		public string Updated { get; set; }
	}
}