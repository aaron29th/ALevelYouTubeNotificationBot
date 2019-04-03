using System.Collections.Generic;
using System.Xml.Serialization;

namespace YoutubeNotifyBot.Models.Youtube
{
	[XmlRoot(ElementName="feed", Namespace="http://www.w3.org/2005/Atom")]
	public class PubSubFeed {
		[XmlElement(ElementName="link", Namespace="http://www.w3.org/2005/Atom")]
		public List<PubSubLink> Link { get; set; }
		[XmlElement(ElementName="title", Namespace="http://www.w3.org/2005/Atom")]
		public string Title { get; set; }
		[XmlElement(ElementName="updated", Namespace="http://www.w3.org/2005/Atom")]
		public string Updated { get; set; }
		[XmlElement(ElementName="entry", Namespace="http://www.w3.org/2005/Atom")]
		public PubSubEntry PubSubEntry { get; set; }
		[XmlAttribute(AttributeName="yt", Namespace="http://www.w3.org/2000/xmlns/")]
		public string Yt { get; set; }
		[XmlAttribute(AttributeName="xmlns")]
		public string Xmlns { get; set; }

		public string FormatTemplateString(string templateString)
		{
			//Check format string exists
			if (templateString == null) return null;

			//Format the videos title
			string formattedText = templateString.Replace("{{VideoTitle}}", PubSubEntry.Title);
			//Add the channel name
			formattedText = formattedText.Replace("{{ChannelName}}", PubSubEntry.Author.Name);
			//Add the channel link
			formattedText = formattedText.Replace("{{ChannelLink}}", PubSubEntry.Author.Uri);
			//Add the video link
			formattedText = formattedText.Replace("{{VideoLink}}", PubSubEntry.Link.Href);
			return formattedText;
		}
	}
}