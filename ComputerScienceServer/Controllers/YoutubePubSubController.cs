using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ComputerScienceServer.Models;
using ComputerScienceServer.Models.PubSub;
using Discord;
using Discord.Webhook;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TweetSharp;

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
		    return Ok();
	    }

		[HttpPost("{id}")]
		[Consumes("application/xml")]
		public ActionResult Post(string id, [FromBody] PubSubFeed pubSubFeed)
		{
			foreach (var user in _context.TwitterUsers)
			{
				try
				{
					user.SendTweet(pubSubFeed);
				}
				catch (Exception e)
				{
					//Log error
					_context.ErrorLog.AddAsync(new ErrorLog()
					{
						Location = "YoutubePubSubController_Send_Tweet",
						ExceptionMessage = e.Message
					});
				}
				
			}

			foreach (var webhook in _context.Webhooks)
			{
				try
				{
					webhook.SendMessage(pubSubFeed);
				}
				catch (Exception e)
				{
					//Log error
					_context.ErrorLog.AddAsync(new ErrorLog()
					{
						Location = "YoutubePubSubController_Send_Discord",
						ExceptionMessage = e.Message
					});
				}
			}

			return NoContent();
		}
    }
}
