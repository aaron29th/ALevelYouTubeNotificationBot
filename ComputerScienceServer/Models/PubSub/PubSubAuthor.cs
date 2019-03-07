using System.Xml.Serialization;

namespace ComputerScienceServer.Models.PubSub
{
	[XmlRoot(ElementName="author", Namespace="http://www.w3.org/2005/Atom")]
	public class PubSubAuthor {
		[XmlElement(ElementName="name", Namespace="http://www.w3.org/2005/Atom")]
		public string Name { get; set; }
		[XmlElement(ElementName="uri", Namespace="http://www.w3.org/2005/Atom")]
		public string Uri { get; set; }
	}
}