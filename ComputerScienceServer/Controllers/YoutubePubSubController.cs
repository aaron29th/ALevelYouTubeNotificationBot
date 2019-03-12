﻿using System;
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
using Microsoft.EntityFrameworkCore;
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
		public async Task<ActionResult> Post(string id, [FromBody] PubSubFeed pubSubFeed)
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
			foreach (var webhookYoutube in youtubeSubscription.DiscordWebhooksYoutubeSubscriptions)
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
