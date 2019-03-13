using System;
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
		public async Task<ActionResult> AddNew([FromBody] YoutubeSubscription subscription)
	    {
		    await _context.YoutubeSubscriptions.AddAsync(subscription);
		    await _context.SaveChangesAsync();
		    return NoContent();
	    }

		[HttpPost("AddWebhook")]
		[Consumes("application/json")]
		public async Task<ActionResult> AddWebhook(
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

		[HttpPost("AddTwitter")]
		[Consumes("application/json")]
		public async Task<ActionResult> AddTwitter(
			[FromBody] TwitterYoutubeSubscription twitterYoutube)
		{
			if (!_context.TwitterUsers.All(user => user.Token == twitterYoutube.Token) ||
			    !_context.YoutubeSubscriptions.All(
				    youtubeSub => youtubeSub.ChannelId == twitterYoutube.ChannelId))
			{
				return BadRequest();
			}
			await _context.TwitterYoutubeSubscriptions.AddAsync(twitterYoutube);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		//Verify pubsub subscription
	    [HttpGet("{id}")]
	    public async Task<ActionResult> Get(string id, [FromQuery] ulong hub_challenge, [FromQuery] ulong lease)
	    {
			//Check subscription exists
		    if (_context.YoutubeSubscriptions.All(sub => sub.ChannelId == id))
		    {
			    return BadRequest();
		    }

		    YoutubeSubscription subscription = await _context.YoutubeSubscriptions.FirstAsync(sub => sub.ChannelId == id);
		    subscription.Verified = true;
			//ulong lease = Request.
		    subscription.Expires = DateTime.Now.AddSeconds(lease);
		    await _context.SaveChangesAsync();

			return Ok(hub_challenge);
	    }

		//Receive post notification for video upload / change
		[HttpPost("{id}")]
		[Consumes("application/xml")]
		public async Task<ActionResult> Post(string id, [FromQuery] string verifyToken,
			[FromBody] PubSubFeed pubSubFeed)
		{
			//Checks channel subscription exists
			if (!_context.YoutubeSubscriptions.Any(sub => sub.ChannelId == id))
			{
				return NotFound();
			}

			//Gets corresponding youtube subscription
			var youtubeSubscription = _context.YoutubeSubscriptions.Find(id);

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
					await _context.SaveChangesAsync();
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
					await _context.SaveChangesAsync();
				}
			}

			return NoContent();
		}
    }
}
