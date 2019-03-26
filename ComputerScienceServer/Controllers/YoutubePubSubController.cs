using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComputerScienceServer.Models;
using ComputerScienceServer.Models.DiscordWebhook;
using ComputerScienceServer.Models.Twitter;
using ComputerScienceServer.Models.Youtube;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;

namespace ComputerScienceServer.Controllers
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

	    [HttpPost("AddNew")]
		public async Task<ActionResult> AddNewSubscription([FromForm] string channelId)
		{
			var subscription = await YoutubeSubscription.SubscribeAsync(channelId);
			if (subscription == null) return BadRequest();

			await _context.YoutubeSubscriptions.AddAsync(subscription);
			await _context.SaveChangesAsync();

		    return NoContent();
	    }

		[HttpGet("GetAll")]
		public async Task<ActionResult> GetAllSubscriptions()
		{
			var subscriptions = await _context.YoutubeSubscriptions.ToArrayAsync();
			return Ok(subscriptions);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteSubscription(string id)
		{
			//Check subscription exists
			if (!await _context.YoutubeSubscriptions.AnyAsync(sub => sub.YoutubeChannelId == id)) return BadRequest();

			var subscription = await _context.YoutubeSubscriptions.FirstAsync(sub => sub.YoutubeChannelId == id);
			if (!await subscription.UnsubscribeAsync()) return Conflict();

			_context.YoutubeSubscriptions.Remove(subscription);
			await _context.SaveChangesAsync();
			return NoContent();
		}

		[HttpPost("LinkWebhook/{id}")]
		public async Task<ActionResult> LinkWebhookToSubscription(string id, 
			[FromForm] ulong webhookId)
		{
			if (!await _context.YoutubeSubscriptions.AnyAsync(subscription => subscription.YoutubeChannelId == id) ||
			    !await _context.Webhooks.AnyAsync(webhook => webhook.WebhookId == webhookId))
			{
				return BadRequest();
			}

			var webhookSubscription = new WebhookYoutubeSubscription()
			{
				YoutubeChannelId = id,
				WebhookId = webhookId
			};
			await _context.WebhookYoutubeSubscriptions.AddAsync(webhookSubscription);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		[HttpPost("UnlinkWebhook/{id}")]
		public async Task<ActionResult> UnlinkWebhookFromSubscription(string id,
			[FromForm] ulong webhookId)
		{
			//Check link exists
			if (!await _context.WebhookYoutubeSubscriptions.AnyAsync(
				webhookSub => webhookSub.WebhookId == webhookId && webhookSub.YoutubeChannelId == id))
			{
				return BadRequest();
			}

			var webhookSubscription = await _context.WebhookYoutubeSubscriptions.FirstAsync(
				webhookSub => webhookSub.WebhookId == webhookId && webhookSub.YoutubeChannelId == id);
			_context.WebhookYoutubeSubscriptions.Remove(webhookSubscription);
			await _context.SaveChangesAsync();
			return NoContent();
		}

		[HttpPost("LinkTwitter/{id}")]
		public async Task<ActionResult> LinkTwitterUser(string id,
			[FromForm] long twitterId)
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
		/// Unlink a twitter user from a youtube subscription
		/// </summary>
		/// <param name="id">YouTube channel id</param>
		/// <param name="twitterId">Twitter user id</param>
		/// <returns></returns>
		[HttpPost("UnlinkTwitter/{id}")]
		public async Task<ActionResult> UnlinkTwitterFromSubscription(string id, long twitterId)
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
		/// Verify the YouTube subscription
		/// </summary>
		/// <param name="id">Channel id</param>
		[HttpGet("{id}")]
		[AllowAnonymous]
	    public ActionResult VerifySubscription(string id)
	    {
		    Request.Query.TryGetValue("hub.challenge", out var challenge);
			return Ok(challenge.First());
	    }

		/// <summary>
		/// Sends discord messages and tweets to notify users of a newly uploaded YouTube video
		/// </summary>
		[HttpPost("{id}")]
		[AllowAnonymous]
		public async Task<ActionResult> SendNotifications(string id, [FromQuery] string verifyToken,
			[FromBody] PubSubFeed pubSubFeed)
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
		/// Renew all YouTube subscriptions that expire within 25 hours
		/// </summary>
		[HttpGet("RenewSubscriptions")]
		public async Task<ActionResult> RenewSubscriptions()
		{
			//Get all subscription which expire within 25 hours
			var subscriptions = _context.YoutubeSubscriptions.Where(
				sub => sub.Expires < DateTime.Now.AddHours(25));

			List<Task<bool>> resultTasks = new List<Task<bool>>();
			foreach (var subscription in subscriptions)
			{
				resultTasks.Add(subscription.RenewAsync());
			}

			bool[] results = await Task.WhenAll(resultTasks);
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
