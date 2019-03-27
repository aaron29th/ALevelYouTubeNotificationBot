using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocialMediaBotManager.Models
{
	class Network
	{
		private static readonly HttpClient _client = new HttpClient();

		public static void Init()
		{
			_client.BaseAddress = new Uri("https://socialmediabot.azurewebsites.net/api/");
			//_client.BaseAddress = new Uri("http://localhost:27744/api/");
		}

		public static async Task<HttpResponseMessage> GetAsync(string path)
		{
			var response = await _client.GetAsync(path);

			if (response.StatusCode == HttpStatusCode.Unauthorized)
			{
				MessageBox.Show("Authentication failed");
			}

			return response;
		}

		public static async Task<HttpResponseMessage> PostFormAsync(string path,
			Dictionary<string, string> values)
		{
			var content = new FormUrlEncodedContent(values);

			var response = await _client.PostAsync(path, content);

			if (response.StatusCode == HttpStatusCode.Unauthorized)
			{
				MessageBox.Show("Authentication failed");
			}

			return response;
		}

		public static async Task<HttpResponseMessage> DeleteAsync(string path)
		{
			var response = await _client.DeleteAsync(path);

			if (response.StatusCode == HttpStatusCode.Unauthorized)
			{
				MessageBox.Show("Authentication failed");
			}

			return response;
		}

		/// <summary>
		/// Sets the authentication token as a default header
		/// </summary>
		/// <param name="param"></param>
		public static void SetAuthHeader(string token)
		{
			_client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
				"Bearer", token); ;
		}
	}
}
