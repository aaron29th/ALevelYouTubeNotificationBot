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

		[HttpPost]
		[Consumes("application/xml")]
		public ActionResult Post([FromBody] PubSubFeed pubSubFeed)
		{
			foreach (var user in _context.TwitterUsers)
			{
				//user.SendTweet(pubSubFeed);
			}

			foreach (var webhook in _context.Webhooks)
			{
				webhook.SendMessage(pubSubFeed);
			}

			return NoContent();
		}
    }
}
