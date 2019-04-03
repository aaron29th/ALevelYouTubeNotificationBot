using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Http;
using System.Threading.Tasks;
using YoutubeNotifyBot.Models.DiscordWebhook;
using YoutubeNotifyBot.Models.Twitter;
using Newtonsoft.Json;

namespace YoutubeNotifyBot.Models.Youtube
{
	public class YoutubeSubscription
	{
		[Key]
		public string YoutubeChannelId { get; set; }

		[JsonIgnore]
		public string VerifyToken { get; set; }
		[JsonIgnore]
		public string HmacSecret { get; set; }
		[JsonIgnore]
		public DateTime Expires { get; set; }

		public virtual ICollection<WebhookYoutubeSubscription> WebhookYoutubeSubscriptions { get; set; }
		public virtual ICollection<TwitterUserYoutubeSubscription> TwitterYoutubeSubscriptions { get; set; }

		private static readonly HttpClient _client = new HttpClient();

		/// <summary>
		/// Creates a new YouTube subscription 
		/// </summary>
		/// <param name="channelId">The id of the youtube channel</param>
		/// <returns></returns>
		public static async Task<YoutubeSubscription> SubscribeAsync(string channelId)
		{
			//Create new youtube subscription instance
			var subscription = new YoutubeSubscription()
			{
				YoutubeChannelId = channelId,
				VerifyToken = SecureRandom.GetString(64),
				HmacSecret = SecureRandom.GetString(64),
				Expires = DateTime.Now.AddSeconds(Config.YoutubeSubscriptionLease)
			};

			//Create form parameters for post request
			var values = new Dictionary<string, string>
			{
				{ "hub.callback", $"{Config.PublicUri}/api/YoutubePubSub/" +
				                  $"{channelId}?verifyToken={subscription.VerifyToken}" },
				{ "hub.topic", $"https://www.youtube.com/xml/feeds/videos.xml?channel_id={channelId}" },
				{ "hub.verify", "sync" },
				{ "hub.mode", "subscribe" },
				{ "hub.secret", subscription.HmacSecret },
				{ "hub.lease_seconds", Config.YoutubeSubscriptionLease.ToString() }
			};
			var content = new FormUrlEncodedContent(values);

			//Send post request and get response
			var response = await _client.PostAsync("https://pubsubhubbub.appspot.com/subscribe", content);

			//Return subscription instance if successful or null if not
			return response.IsSuccessStatusCode ? subscription : null;
		}

		/// <summary>
		/// Renews a YouTube subscription so it does not expire
		/// </summary>
		/// <returns>Whether renewing the subscription was successful</returns>
		public async Task<bool> RenewAsync()
		{
			//Create form parameters for post request body
			var values = new Dictionary<string, string>
			{
				{ "hub.callback", $"{Config.PublicUri}/api/YoutubePubSub/" +
				                  $"{YoutubeChannelId}?verifyToken={VerifyToken}" },
				{ "hub.topic", $"https://www.youtube.com/xml/feeds/videos.xml?channel_id={YoutubeChannelId}" },
				{ "hub.verify", "sync" },
				{ "hub.mode", "subscribe" },
				{ "hub.secret", HmacSecret },
				{ "hub.lease_seconds", "432000" }
			};
			var content = new FormUrlEncodedContent(values);

			//Send request and get the response
			var response = await _client.PostAsync("https://pubsubhubbub.appspot.com/subscribe", content);

			return response.IsSuccessStatusCode;
		}

		/// <summary>
		/// Unsubscribes from a YouTube subscription
		/// </summary>
		/// <returns></returns>
		public async Task<bool> UnsubscribeAsync()
		{
			//Create form parameters for post request body
			var values = new Dictionary<string, string>
			{
				{ "hub.callback", $"{Config.PublicUri}/api/YoutubePubSub/"  +
				                  $"{YoutubeChannelId}?verifyToken={VerifyToken}" },
				{ "hub.topic", $"https://www.youtube.com/xml/feeds/videos.xml?channel_id={YoutubeChannelId}" },
				{ "hub.verify", "sync" },
				{ "hub.mode", "unsubscribe" },
				{ "hub.secret", HmacSecret }
			};
			var content = new FormUrlEncodedContent(values);

			var response = await _client.PostAsync("https://pubsubhubbub.appspot.com/subscribe",
				content);

			//Send request and get the response
			return response.IsSuccessStatusCode;
		}
	}
}
