using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComputerScienceServer.Models.PubSub;

namespace ComputerScienceServer.Models
{
	public class TextFormatter
	{
		public static string Format(PubSubFeed youtubeFeed, string templateString)
		{
			if (templateString == null) return null;

			string formattedText = templateString.Replace("{{VideoTitle}}", youtubeFeed.Title);
			formattedText = formattedText.Replace("{{AuthorName}}", 
				youtubeFeed.PubSubEntry.Author.Name);
			return formattedText;
		}
	}
}
