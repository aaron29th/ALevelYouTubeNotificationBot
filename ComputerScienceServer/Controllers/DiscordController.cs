using System.Threading.Tasks;
using ComputerScienceServer.Models;
using ComputerScienceServer.Models.DiscordWebhook;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

	    /// <summary>
	    /// Add new webhook
	    /// </summary>
	    /// <param name="id">webhook id</param>
	    /// <param name="token">Webhook token</param>
	    /// <returns></returns>
	    [HttpPost("AddWebhook/{id}")]
        public async Task<ActionResult> AddWebhook(ulong id, [FromForm] string token)
        {
			var webhook = new Webhook()
			{
				Id = id,
				Token = token
			};
			//Check webhook exists
	        if (webhook.VerifyExistence() == false) return BadRequest();

	        await _context.Webhooks.AddAsync(webhook);
	        await _context.SaveChangesAsync();
	        return NoContent();
        }

        [HttpPost("SetMessageTemplate")]
        public async Task<ActionResult> SetMessageTemplate(ulong id, string messageTemplate, string embedTemplate)
        {
			//Check webhook exists
	        if (await _context.Webhooks.AnyAsync(x => x.Id == id)) return BadRequest();

			//Get webhook
	        var webhook = await _context.Webhooks.FirstAsync(x => x.Id == id);
			//Set templates
	        webhook.MessageTemplate = messageTemplate;
	        webhook.EmbedTemplate = embedTemplate;
	        await _context.SaveChangesAsync();
	        return NoContent();
		}

        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
	        var webhooks = await _context.Webhooks.ToArrayAsync();
	        return Ok(webhooks);
        }

		[HttpDelete("{id}")]
        public async Task<ActionResult> DeleteWebhook(ulong id)
        {
			//Check webhook exists
	        if (await _context.Webhooks.AnyAsync(x => x.Id == id)) return BadRequest();

			//Get webhook
	        var webhook = await _context.Webhooks.FirstAsync(x => x.Id == id);
			//Delete the webhook
	        _context.Remove(webhook);
	        await _context.SaveChangesAsync();
	        return NoContent();
		}
	}
}
