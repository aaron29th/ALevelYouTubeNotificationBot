using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComputerScienceServer.Models;
using ComputerScienceServer.Models.DiscordWebhook;
using ComputerScienceServer.Models.Twitter;
using ComputerScienceServer.Models.Youtube;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
	    [Consumes("application/json")]
		public async Task<ActionResult> AddNewSubscription([FromBody] string channelId)
		{
			var subscription = await YoutubeSubscription.SubscribeAsync(channelId);
			if (subscription == null) return BadRequest();

			await _context.YoutubeSubscriptions.AddAsync(subscription);
		    await _context.SaveChangesAsync();
		    return NoContent();
	    }

		public async Task<ActionResult> DeleteSubscription()
		{
			return Ok();
		}

		[HttpPost("LinkWebhook")]
		[Consumes("application/json")]
		public async Task<ActionResult> LinkWebhookToSubscription(
			[FromBody] WebhookYoutubeSubscription webhookYoutube)
		{
			if (!_context.Webhooks.All(webhook => webhook.Id == webhookYoutube.Id) ||
			    !_context.YoutubeSubscriptions.All(
				    youtubeSub => youtubeSub.ChannelId == webhookYoutube.ChannelId))
			{
				return BadRequest();
			}
			await _context.WebhookYoutubeSubscriptions.AddAsync(webhookYoutube);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		public async Task<ActionResult> UnlinkWebhookFromSubscription()
		{
			return Ok();
		}

		[HttpPost("LinkTwitter")]
		[Consumes("application/json")]
		public async Task<ActionResult> LinkTwitterUser(
			[FromBody] TwitterYoutubeSubscription twitterYoutube)
		{
			//Check that both the twitter account and youtube subscription exists in the database
			if (!_context.TwitterUsers.All(user => user.Id == twitterYoutube.Id) ||
			    !_context.YoutubeSubscriptions.All(
				    youtubeSub => youtubeSub.ChannelId == twitterYoutube.ChannelId))
			{
				return BadRequest();
			}
			await _context.TwitterYoutubeSubscriptions.AddAsync(twitterYoutube);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		public async Task<ActionResult> UnlinkTwitterFromSubscription()
		{
			return Ok();
		}

		/// <summary>
		/// Verify the YouTube subscription
		/// </summary>
		/// <param name="id">Channel id</param>
		[HttpGet("{id}")]
	    public async Task<ActionResult> VerifySubscription(string id, [FromQuery] ulong hub_challenge, 
			[FromQuery] ulong lease)
	    {
			//Check subscription exists
		    if (_context.YoutubeSubscriptions.All(sub => sub.ChannelId == id))
		    {
			    return BadRequest();
		    }

		    YoutubeSubscription subscription = await _context.YoutubeSubscriptions.FirstAsync(sub => sub.ChannelId == id);
		    subscription.Verified = true;
		    subscription.Expires = DateTime.Now.AddSeconds(lease);
		    await _context.SaveChangesAsync();

			return Ok(hub_challenge);
	    }

		/// <summary>
		/// Sends discord messages and tweets to notify users of a newly uploaded YouTube video
		/// </summary>
		[HttpPost("{id}")]
		[Consumes("application/xml")]
		public async Task<ActionResult> SendNotifications(string id, [FromQuery] string verifyToken,
			[FromBody] PubSubFeed pubSubFeed)
		{
			//Checks channel subscription exists
			if (!_context.YoutubeSubscriptions.Any(sub => sub.ChannelId == id))
			{
				return NotFound();
			}

			//Gets corresponding youtube subscription
			var youtubeSubscription = await _context.YoutubeSubscriptions.FindAsync(id);

			//Loop through all twitter users and send a tweet from each
			foreach (var user in youtubeSubscription.TwitterYoutubeSubscriptions)
			{
				try
				{
					user.TwitterUser.SendTweet(pubSubFeed);
				}
				catch (Exception e)
				{
					//Log error
					await _context.ErrorLog.AddAsync(new ErrorLog()
					{
						Location = "YoutubePubSubController_Send_Tweet",
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
					//Log error
					await _context.ErrorLog.AddAsync(new ErrorLog()
					{
						Location = "YoutubePubSubController_Send_Discord",
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
					Location = $"YoutubePubSubController ChannelId={subscriptions.ElementAt(i).ChannelId}"
				});
			}

			await _context.SaveChangesAsync();
			return NoContent();
		}
    }
}
