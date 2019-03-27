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
			var values = new Dictionary<string, string>
			{
				{ "username", username },
				{ "password", password }
			};

			var response = await Network.PostFormAsync("User/GetToken", values);

			if (!response.IsSuccessStatusCode) return false;

			try
			{
				string token = response.Headers.GetValues("token").First();

				//Set the token as a default header
				Network.SetAuthHeader(token);

				return true;
			}
			catch
			{
				return false;
			}
		}
	}
}
