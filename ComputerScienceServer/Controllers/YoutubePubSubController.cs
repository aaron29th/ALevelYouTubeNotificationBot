using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ComputerScienceServer.Models;
using Discord;
using Discord.Webhook;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComputerScienceServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YoutubePubSubController : ControllerBase
    {
        [HttpPost]
        public string Post([FromBody] PubSubFeed pubSubFeed)
        {
	        ulong id = 467813391742926868;
	        string token = "***REMOVED***";

	        Embed embeded;

	        DiscordWebhookClient client = new DiscordWebhookClient(id, token);
	        client.SendMessageAsync();

			return pubSubFeed.Title;
        }
    }
}
