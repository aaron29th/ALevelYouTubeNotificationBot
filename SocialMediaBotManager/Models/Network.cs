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
		//Initializes the applications http client
		private static readonly HttpClient _client = new HttpClient();

		public static void Init()
		{
			//Sets the web address of the web server
			_client.BaseAddress = new Uri("https://youtubenotifybot.azurewebsites.net/api/");
		}

		/// <summary>
		/// Sends a get request to the given path and returns the response
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		public static async Task<HttpResponseMessage> GetAsync(string path)
		{
			//Send the get request and await the response
			var response = await _client.GetAsync(path);

			//Show an error message if authentication fails
			if (response.StatusCode == HttpStatusCode.Unauthorized)
			{
				MessageBox.Show("Authentication failed", "Authentication failed",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			//Return the response
			return response;
		}

		/// <summary>
		/// Sends a post request with the given form data and returns the response
		/// </summary>
		/// <param name="path"></param>
		/// <param name="values"></param>
		/// <returns></returns>
		public static async Task<HttpResponseMessage> PostFormAsync(string path,
			Dictionary<string, string> values)
		{
			//Encode the post request's form parameters
			var content = new FormUrlEncodedContent(values);

			//Send the request and await its response
			var response = await _client.PostAsync(path, content);

			//Show an error message if authentication fails
			if (response.StatusCode == HttpStatusCode.Unauthorized)
			{
				MessageBox.Show("Authentication failed", "Authentication failed",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			//Return the response
			return response;
		}

		/// <summary>
		/// Sends a delete request to the given path and returns the response
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		public static async Task<HttpResponseMessage> DeleteAsync(string path)
		{
			//Send the delete request and await the response
			var response = await _client.DeleteAsync(path);

			//Show an error message if authentication fails
			if (response.StatusCode == HttpStatusCode.Unauthorized)
			{
				MessageBox.Show("Authentication failed", "Authentication failed",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			//Return the requests response
			return response;
		}

		/// <summary>
		/// Sets the authentication token as a default header
		/// </summary>
		/// <param name="token">Bearer token</param>
		public static void SetAuthHeader(string token)
		{
			//Set the http clients bearer token header
			_client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
		}
	}
}
