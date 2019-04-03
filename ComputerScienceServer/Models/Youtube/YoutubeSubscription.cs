﻿using System;
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
			var subscription = new YoutubeSubscription()
			{
				YoutubeChannelId = channelId,
				VerifyToken = SecureRandom.GetString(64),
				HmacSecret = SecureRandom.GetString(64),
				Expires = DateTime.Now.AddSeconds(Config.YoutubeSubscriptionLease)
			};

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

			var response = await _client.PostAsync("https://pubsubhubbub.appspot.com/subscribe", content);

			return response.IsSuccessStatusCode ? subscription : null;
		}

		public async Task<bool> RenewAsync()
		{
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

			var response = await _client.PostAsync("https://pubsubhubbub.appspot.com/subscribe",
				content);

			return response.IsSuccessStatusCode;
		}

		public async Task<bool> UnsubscribeAsync()
		{
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

			return response.IsSuccessStatusCode;
		}
	}
}
