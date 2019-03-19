﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComputerScienceServer.Models;
using ComputerScienceServer.Models.DiscordWebhook;
using Microsoft.AspNetCore.Mvc;
using TweetSharp;
using TwitterUser = ComputerScienceServer.Models.Twitter.TwitterUser;

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

		[HttpGet("LogError")]
		public ActionResult TestPage2()
		{
			_context.ErrorLog.Add(new ErrorLog()
			{
				ExceptionMessage = "An error occured - test",
				Location = "Debug"
			});
			_context.SaveChanges();

			return Ok(_context.ErrorLog.First());
		}

		[HttpGet("SendHelloWorldTweet")]
		public string SendHelloWorldTweet()
		{
			string twitterToken = "***REMOVED***";
			string twitterSecret = "***REMOVED***";

			TwitterService service = new TwitterService(Config.TwitterConsumerKey, Config.TwitterConsumerSecret);

			service.AuthenticateWith(twitterToken, twitterSecret);
			service.SendTweet(new SendTweetOptions()
			{
				Status = "Hello world..."
			});
			return "";
		}
	}
}
