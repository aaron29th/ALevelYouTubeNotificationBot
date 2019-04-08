using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using YoutubeNotifyBot.Models;
using YoutubeNotifyBot.Models.DiscordWebhook;
using YoutubeNotifyBot.Models.Twitter;
using YoutubeNotifyBot.Models.Youtube;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;

namespace YoutubeNotifyBot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YoutubePubSubController : ControllerBase
    {
	    private readonly WebApiContext _context;

	    public YoutubePubSubController(WebApiContext context)
	    {
		    _context = context;
	    }

		/// <summary>
		/// Adds a new subscription to a YouTube channel
		/// </summary>
		/// <param name="channelId"></param>
		/// <returns></returns>
		
		[HttpPost("AddNew")]
		public async Task<ActionResult> AddNewSubscription([Required][FromForm] string channelId)
		{
			var subscription = await YoutubeSubscription.SubscribeAsync(channelId);
			if (subscription == null) return BadRequest();

			await _context.YoutubeSubscriptions.AddAsync(subscription);
			await _context.SaveChangesAsync();

		    return NoContent();
	    }

		/// <summary>
		/// Returns all YouTube subscriptions in the database
		/// </summary>
		/// <returns></returns>
		[HttpGet("GetAll")]
		[Produces("application/json")]
		public async Task<ActionResult> GetAllSubscriptions()
		{
			var subscriptions = await _context.YoutubeSubscriptions
				.Include(sub => sub.TwitterYoutubeSubscriptions)
				.Include(sub => sub.WebhookYoutubeSubscriptions)
				.ToArrayAsync();

			return Ok(subscriptions);
		}

		/// <summary>
		/// Deletes the given YouTube subscription
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>	
		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteSubscription(string id)
		{
			//Check subscription exists
			if (!await _context.YoutubeSubscriptions.AnyAsync(sub => sub.YoutubeChannelId == id)) return BadRequest();

			//Get the youtube subscription
			var subscription = await _context.YoutubeSubscriptions.FirstAsync(sub => sub.YoutubeChannelId == id);
			//Check that the subscription was successfully dleeted
			if (!await subscription.UnsubscribeAsync()) return Conflict();

			//Delete the subscription from the database
			_context.YoutubeSubscriptions.Remove(subscription);
			await _context.SaveChangesAsync();
			return NoContent();
		}

		/// <summary>
		/// Links an existing webhook to an existing subscription
		/// </summary>
		/// <param name="id">YouTube channel id</param>
		/// <param name="webhookId">Webhook id</param>
		/// <returns></returns>
		[HttpPost("{id}/LinkWebhook")]
		public async Task<ActionResult> LinkWebhookToSubscription(string id,
			[Required][FromForm] ulong webhookId)
		{
			//Check that the subscription and the webhook exists
			if (!await _context.YoutubeSubscriptions.AnyAsync(subscription => subscription.YoutubeChannelId == id) ||
			    !await _context.Webhooks.AnyAsync(webhook => webhook.WebhookId == webhookId))
			{
				return BadRequest();
			}

			//Check that a link between the subscription and the webhook does not already exist
			if (await _context.WebhookYoutubeSubscriptions.AnyAsync(
				webhookSub => webhookSub.WebhookId == webhookId && webhookSub.YoutubeChannelId == id))
			{
				return Conflict();
			}

			//Create a new link between the subscription and the webhook
			var webhookSubscription = new WebhookYoutubeSubscription()
			{
				YoutubeChannelId = id,
				WebhookId = webhookId
			};
			//Add the link to the database
			await _context.WebhookYoutubeSubscriptions.AddAsync(webhookSubscription);
			//Save the changes to the database
			await _context.SaveChangesAsync();

			return NoContent();
		}

		/// <summary>
		/// Unlinks a webhook from a subscription
		/// </summary>
		/// <param name="id">YouTube channel id</param>
		/// <param name="webhookId">Webhook id</param>
		/// <returns></returns>
		[HttpPost("{id}/UnlinkWebhook")]
		public async Task<ActionResult> UnlinkWebhookFromSubscription(string id,
			[Required][FromForm] ulong webhookId)
		{
			//Check link between the subscription and webhook exists
			if (!await _context.WebhookYoutubeSubscriptions.AnyAsync(
				webhookSub => webhookSub.WebhookId == webhookId && webhookSub.YoutubeChannelId == id))
			{
				return BadRequest();
			}

			//Get the link
			var webhookSubscription = await _context.WebhookYoutubeSubscriptions.FirstAsync(
				webhookSub => webhookSub.WebhookId == webhookId && webhookSub.YoutubeChannelId == id);
			//Delete the link between the webhook and the subscription
			_context.WebhookYoutubeSubscriptions.Remove(webhookSubscription);
			//Save the changes to the database
			await _context.SaveChangesAsync();
			return NoContent();
		}

		/// <summary>
		/// Links an existing twitter user to an existing subscription
		/// </summary>
		/// <param name="id">YouTube channel id</param>
		/// <param name="twitterId">Twitter user id</param>
		/// <returns></returns>
		[HttpPost("{id}/LinkTwitter")]
		public async Task<ActionResult> LinkTwitterUser(string id,
			[Required][FromForm] long twitterId)
		{
			//Check that both the twitter account and youtube subscription exists in the database
			if (!await _context.YoutubeSubscriptions.AnyAsync(sub => sub.YoutubeChannelId == id) ||
			    !await _context.TwitterUsers.AnyAsync(user => user.TwitterUserId == twitterId))
			{
				return BadRequest();
			}
			var twitterSubscription = new TwitterUserYoutubeSubscription()
			{
				YoutubeChannelId = id,
				TwitterUserId = twitterId
			};
			await _context.TwitterYoutubeSubscriptions.AddAsync(twitterSubscription);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		/// <summary>
		/// Unlinks a twitter user from a subscription
		/// </summary>
		/// <param name="id">YouTube channel id</param>
		/// <param name="twitterId">Twitter user id</param>
		/// <returns></returns>
		[HttpPost("{id}/UnlinkTwitter")]
		public async Task<ActionResult> UnlinkTwitterFromSubscription(string id, [Required][FromForm]long twitterId)
		{
			//Check link exists
			if (!await _context.TwitterYoutubeSubscriptions.AnyAsync(
				twitterSub => twitterSub.TwitterUserId == twitterId && twitterSub.YoutubeChannelId == id))
			{
				return BadRequest();
			}

			//Find and delete link
			var twitterSubscription = await _context.TwitterYoutubeSubscriptions.FirstAsync(
				twitterSub => twitterSub.TwitterUserId == twitterId && twitterSub.YoutubeChannelId == id);
			_context.TwitterYoutubeSubscriptions.Remove(twitterSubscription);
			await _context.SaveChangesAsync();
			return NoContent();
		}

		/// <summary>
		/// Verifies the YouTube subscription (No auth token required)
		/// </summary>
		/// <param name="id">Channel id</param>
		[AllowAnonymous]
		[HttpGet("{id}")]
		[Produces("text/plain")]
	    public ActionResult VerifySubscription(string id)
	    {
		    Request.Query.TryGetValue("hub.challenge", out var challenge);
			return Ok(challenge.First());
	    }

		/// <summary>
		/// Sends discord messages and tweets to notify users of newly uploaded YouTube videos (No auth token required)
		/// </summary>
		/// <param name="id">The youtube channel's id</param>
		/// <param name="verifyToken">Token to verify the sender</param>
		/// <param name="pubSubFeed">Xml feed about the youtube video</param>
		/// <returns></returns>
		[AllowAnonymous]
		[HttpPost("{id}")]
		public async Task<ActionResult> SendNotifications(string id, [Required][FromQuery] string verifyToken,
			[Required][FromBody] PubSubFeed pubSubFeed)
		{
			//Checks channel subscription exists
			if (!await _context.YoutubeSubscriptions.AnyAsync(sub => sub.YoutubeChannelId == id))
			{
				return NotFound();
			}

			//Gets corresponding youtube subscription and all related discord webhooks and twitter users
			var youtubeSubscription = await _context.YoutubeSubscriptions
				.Include(sub => sub.TwitterYoutubeSubscriptions)
					.ThenInclude(twitterYoutube => twitterYoutube.TwitterUser)
				.Include(sub => sub.WebhookYoutubeSubscriptions)
					.ThenInclude(webhookYoutube => webhookYoutube.Webhook)
				.FirstAsync(sub => sub.YoutubeChannelId == id);

			//Checks verify token is correct
			if (youtubeSubscription.VerifyToken != verifyToken) return Forbid();

			//Loop through all twitter users and send a tweet from each
			foreach (var twitterUserYoutube in youtubeSubscription.TwitterYoutubeSubscriptions)
			{
				try
				{
					twitterUserYoutube.TwitterUser.SendTweet(pubSubFeed);
				}
				catch (Exception e)
				{
					//Log error with twitter user id
					await _context.ErrorLog.AddAsync(new ErrorLog()
					{
						Location = $"YoutubePubSubController_Send_Tweet_Id={twitterUserYoutube.TwitterUserId}",
						ExceptionMessage = e.Message
					});
				}
			}

			//Loop through all associated discord webhooks and send a message from each
			foreach (var webhookYoutube in youtubeSubscription.WebhookYoutubeSubscriptions)
			{
				try
				{
					webhookYoutube.Webhook.SendMessage(pubSubFeed);
				}
				catch (Exception e)
				{
					//Log error with discord webhook id
					await _context.ErrorLog.AddAsync(new ErrorLog()
					{
						Location = $"YoutubePubSubController_Send_Discord_Id={webhookYoutube.WebhookId}",
						ExceptionMessage = e.Message
					});
				}
			}
			await _context.SaveChangesAsync();
			return NoContent();
		}

		/// <summary>
		/// Renews all YouTube subscriptions that expire within 25 hours
		/// </summary>
		[HttpGet("RenewSubscriptions")]
		public async Task<ActionResult> RenewSubscriptions()
		{
			//Get all subscription which expire within 25 hours
			var subscriptions = _context.YoutubeSubscriptions.Where(
				sub => sub.Expires < DateTime.Now.AddHours(25));

			//List for sent requests
			List<Task<bool>> resultTasks = new List<Task<bool>>();
			//Send the renew request for each subscription and add the awaiting response to the list
			foreach (var subscription in subscriptions)
			{
				resultTasks.Add(subscription.RenewAsync());
			}

			//Wait for all the responses to be received
			bool[] results = await Task.WhenAll(resultTasks);
			//Loop through all the responses
			for (int i = 0; i < results.Length; i++)
			{
				//Skip successful renews
				if (results[i]) continue;
				//Log failed renews
				await _context.ErrorLog.AddAsync(new ErrorLog()
				{
					ExceptionMessage = "Youtube pub sub renew failed",
					Location = $"YoutubePubSubController YoutubeChannelId={subscriptions.ElementAt(i).YoutubeChannelId}"
				});
			}

			await _context.SaveChangesAsync();
			return NoContent();
		}
    }
}
