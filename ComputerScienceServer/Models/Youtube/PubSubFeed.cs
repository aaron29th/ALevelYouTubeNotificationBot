﻿using System.Collections.Generic;
using System.Xml.Serialization;

namespace ComputerScienceServer.Models.Youtube
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
			if (templateString == null) return null;

			string formattedText = templateString.Replace("{{VideoTitle}}", Title);
			formattedText = formattedText.Replace("{{AuthorName}}", PubSubEntry.Author.Name);
			return formattedText;
		}
	}
}