﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Net.Http;
using System.Threading.Tasks;
using ComputerScienceServer.Models.DiscordWebhook;
using ComputerScienceServer.Models.Twitter;
using Newtonsoft.Json;

namespace ComputerScienceServer.Models.Youtube
{
	public class YoutubeSubscription
	{
		[Key]
		public string ChannelId { get; set; }
		[JsonIgnore]
		public string VerifyToken { get; set; }
		[JsonIgnore]
		public string HmacSecret { get; set; }
		[JsonIgnore]
		public DateTime Expires { get; set; }
		[JsonIgnore]
		public bool Verified { get; set; }

		public ICollection<WebhookYoutubeSubscription> WebhookYoutubeSubscriptions { get; set; }
		public ICollection<TwitterYoutubeSubscription> TwitterYoutubeSubscriptions { get; set; }

		private static readonly HttpClient _client = new HttpClient();

		/// <summary>
		/// Creates a new YouTube subscription 
		/// </summary>
		/// <param name="channelId">The id of the youtube channel</param>
		/// <returns></returns>
		public static async Task<YoutubeSubscription> Subscribe(string channelId)
		{
			var subscription = new YoutubeSubscription()
			{
				ChannelId = channelId,
				VerifyToken = TextFormatter.SecureRandomString(64),
				HmacSecret = TextFormatter.SecureRandomString(64),
				Expires = DateTime.Now.AddSeconds(432000),
				Verified = false
			};

			var values = new Dictionary<string, string>
			{
				{ "hub.callback", $"https://socialmediabot.azurewebsites.net/api/YoutubePubSub/{channelId}" },
				{ "hub.topic", $"https://www.youtube.com/xml/feeds/videos.xml?channel_id={channelId}" },
				{ "hub.verify", "sync" },
				{ "hub.mode", "subscribe" },
				{ "hub.verify_tokens", subscription.VerifyToken },
				{ "hub.secret", subscription.HmacSecret },
				{ "hub.lease_seconds", "432000" }
			};

			var content = new FormUrlEncodedContent(values);

			var response = await _client.PostAsync("https://pubsubhubbub.appspot.com/subscribe", 
				content);

			return response.IsSuccessStatusCode ? subscription : null;
		}

		public async Task<bool> Renew()
		{
			var values = new Dictionary<string, string>
			{
				{ "hub.callback", $"https://socialmediabot.azurewebsites.net/api/YoutubePubSub/{ChannelId}" },
				{ "hub.topic", $"https://www.youtube.com/xml/feeds/videos.xml?channel_id={ChannelId}" },
				{ "hub.verify", "sync" },
				{ "hub.mode", "subscribe" },
				{ "hub.verify_tokens", VerifyToken },
				{ "hub.secret", HmacSecret },
				{ "hub.lease_seconds", "432000" }
			};

			var content = new FormUrlEncodedContent(values);

			var response = await _client.PostAsync("https://pubsubhubbub.appspot.com/subscribe",
				content);

			return response.IsSuccessStatusCode;
		}

		public async Task<bool> Unsubscribe()
		{
			var values = new Dictionary<string, string>
			{
				{ "hub.callback", $"https://socialmediabot.azurewebsites.net/api/YoutubePubSub/{ChannelId}" },
				{ "hub.topic", $"https://www.youtube.com/xml/feeds/videos.xml?channel_id={ChannelId}" },
				{ "hub.verify", "sync" },
				{ "hub.mode", "unsubscribe" },
				{ "hub.verify_tokens", VerifyToken },
				{ "hub.secret", HmacSecret }
			};

			var content = new FormUrlEncodedContent(values);

			var response = await _client.PostAsync("https://pubsubhubbub.appspot.com/subscribe",
				content);

			return response.IsSuccessStatusCode;
		}
	}
}