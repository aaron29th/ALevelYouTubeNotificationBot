using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SocialMediaBotManager.Models
{
	class Auth
	{
		public static async Task<bool> Login(string username, string password)
		{
			var values = new Dictionary<string, string>
			{
				{ "username", username },
				{ "password", password }
			};

			var response = await Network.PostFormAsync("User/GetToken", values);

			if (!response.IsSuccessStatusCode) return false;

			try
			{
				string responseStr = await response.Content.ReadAsStringAsync();
				var responseContent = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseStr);

				if (!responseContent.ContainsKey("token")) return false;

				//Set the token as a default header
				Network.SetAuthHeader(responseContent["token"]);

				return true;
			}
			catch
			{
				return false;
			}
		}
	}
}
