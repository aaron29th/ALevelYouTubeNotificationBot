using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaBotManager.Models
{
	class Auth
	{
		public static async Task<bool> Login(string username, string password)
		{
			var client = Network.Client;

			var values = new Dictionary<string, string>
			{
				{ "username", username },
				{ "password", password }
			};

			var content = new FormUrlEncodedContent(values);

			var response = await client.PostAsync("auth/login", content);

			string token = response.Headers.GetValues("token").First();

			//Add auth token to default headers
			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
				"Bearer", token); ;

			return response.IsSuccessStatusCode;
		}
	}
}
