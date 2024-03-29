﻿using System.Xml.Serialization;

namespace YoutubeNotifyBot.Models.Youtube
{
	[XmlRoot(ElementName = "link", Namespace = "http://www.w3.org/2005/Atom")]
	public class PubSubLink
	{
		[XmlAttribute(AttributeName = "rel")]
		public string Rel { get; set; }
		[XmlAttribute(AttributeName = "href")]
		public string Href { get; set; }
	}
}
