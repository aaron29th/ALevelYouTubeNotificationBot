using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaBotManager.Models
{
	class Network
	{
		public static readonly HttpClient Client = new HttpClient();

		public static void Init()
		{
			Client.BaseAddress = new Uri(
				"https://socialmediabot.azurewebsites.net/api/");
			
		}
	}
}
