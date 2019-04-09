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
		/// <summary>
		/// Logs in to the web server and sets the returned bearer token
		/// </summary>
		/// <param name="username"></param>
		/// <param name="password"></param>
		/// <returns></returns>
		public static async Task<bool> Login(string username, string password)
		{
			//Create form parameters
			var values = new Dictionary<string, string>
			{
				{ "username", username },
				{ "password", password }
			};

			//Send the post request and await the response
			var response = await Network.PostFormAsync("User/GetToken", values);

			//If request fails return false
			if (!response.IsSuccessStatusCode) return false;

			try
			{
				//Read and deserialize the response body
				string responseStr = await response.Content.ReadAsStringAsync();
				var responseContent = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseStr);

				//If the body does not contain the token return false
				if (!responseContent.ContainsKey("token")) return false;

				//Set the bearer token as a default header
				Network.SetAuthHeader(responseContent["token"]);

				return true;
			}
			catch
			{
				return false;
			}
		}

		public static async Task<bool> ChangePassword(string oldPassword, string newPassword)
		{
			//Create form parameters
			var values = new Dictionary<string, string>
			{
				{ "oldPassword", oldPassword },
				{ "newPassword", newPassword }
			};

			//Send the post request and await the response
			var response = await Network.PostFormAsync("User/ChangePassword", values);

			return response.IsSuccessStatusCode;
		}
	}
}
