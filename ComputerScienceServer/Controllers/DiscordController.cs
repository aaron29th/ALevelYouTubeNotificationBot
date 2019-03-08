using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComputerScienceServer.Models;
using Discord.Webhook;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComputerScienceServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscordController : ControllerBase
    {
	    private readonly WebApiContext _context;

	    public DiscordController(WebApiContext context)
	    {
		    _context = context;
	    }

		//Add webhook
		[HttpPost("AddWebhook")]
		[Consumes("application/json")]
        public async Task<ActionResult> Post([FromBody] DiscordWebhook webhook)
        {
	        if (webhook.VerifyExistence() == false) return BadRequest();

	        await _context.Webhooks.AddAsync(webhook);
	        await _context.SaveChangesAsync();
	        return NoContent();
        }
    }
}
