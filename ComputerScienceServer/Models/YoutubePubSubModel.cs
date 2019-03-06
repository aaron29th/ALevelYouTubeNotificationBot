using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace ComputerScienceServer.Models
{
	[XmlRoot(ElementName="link", Namespace="http://www.w3.org/2005/Atom")]
	public class PubSubLink {
		[XmlAttribute(AttributeName="rel")]
		public string Rel { get; set; }
		[XmlAttribute(AttributeName="href")]
		public string Href { get; set; }
	}

	[XmlRoot(ElementName="author", Namespace="http://www.w3.org/2005/Atom")]
	public class PubSubAuthor {
		[XmlElement(ElementName="name", Namespace="http://www.w3.org/2005/Atom")]
		public string Name { get; set; }
		[XmlElement(ElementName="uri", Namespace="http://www.w3.org/2005/Atom")]
		public string Uri { get; set; }
	}

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
	}

}
