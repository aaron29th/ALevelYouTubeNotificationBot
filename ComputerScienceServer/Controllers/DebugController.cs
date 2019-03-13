using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComputerScienceServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace ComputerScienceServer.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DebugController : ControllerBase
	{
		private readonly WebApiContext _context;

		public DebugController(WebApiContext context)
		{
			_context = context;
		}

		[HttpGet("TestPage")]
		public ActionResult TestPage()
		{
			return Ok("Hello world");
		}

		[HttpGet("TestPage2")]
		public ActionResult TestPage2()
		{
			_context.ErrorLog.Add(new ErrorLog()
			{
				ExceptionMessage = "An error occured",
				Location = "Debug"
			});
			_context.SaveChanges();

			return Ok(_context.ErrorLog.First());
		}

		[HttpGet("{id}")]
		public async Task<ActionResult> Get(string id)
		{
			int result = 0;
			switch (id)
			{
				case "newTwitterUser":
					TwitterUser user = new TwitterUser()
					{
						Token = "***REMOVED***",
						TokenSecret = "***REMOVED***",
						TweetTemplate = "{{AuthorName}} published a new video {{VideoTitle}}"
					};
					await _context.TwitterUsers.AddAsync(user);
					result = await _context.SaveChangesAsync();
					return Ok($"Save changes {result}");

				case "newDiscordWebhook":
					Webhook webhookh = new Webhook()
					{
						Id = 467813391742926868,
						Token = "***REMOVED***",
						MessageTemplate = null,
						EmbedTemplate = "{\"content\":\"this `supports` __a__ **subset** *of* ~~markdown~~ 😃 ```js\\nfunction foo(bar) {\\n  console.log(bar);\\n}\\n\\nfoo(1);```\",\"embed\":{\"title\":\"title ~~(did you know you can have markdown here too?)~~\",\"description\":\"this supports [named links](https://discordapp.com) on top of the previously shown subset of markdown. ```\\nyes, even code blocks```\",\"url\":\"https://discordapp.com\",\"color\":437808,\"timestamp\":\"2019-03-07T22:22:01.330Z\",\"footer\":{\"icon_url\":\"https://cdn.discordapp.com/embed/avatars/0.png\",\"text\":\"footer text\"},\"thumbnail\":{\"url\":\"https://cdn.discordapp.com/embed/avatars/0.png\"},\"image\":{\"url\":\"https://cdn.discordapp.com/embed/avatars/0.png\"},\"author\":{\"name\":\"author name\",\"url\":\"https://discordapp.com\",\"icon_url\":\"https://cdn.discordapp.com/embed/avatars/0.png\"}}}"
					};
					await _context.Webhooks.AddAsync(webhookh);
					result = await _context.SaveChangesAsync();
					return Ok(result);
			}

			return Ok();
		}
	}
}
