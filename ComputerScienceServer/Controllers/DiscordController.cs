using System.Threading.Tasks;
using YoutubeNotifyBot.Models;
using YoutubeNotifyBot.Models.DiscordWebhook;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace YoutubeNotifyBot.Controllers
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
	    [HttpPost("AddWebhook")]
        public async Task<ActionResult> AddWebhook([FromForm] ulong webhookId, [FromForm] string token)
        {
			var webhook = new Webhook()
			{
				WebhookId = webhookId,
				Token = token
			};
			//Check webhook exists
	        if (webhook.VerifyExistence() == false) return BadRequest();

	        await _context.Webhooks.AddAsync(webhook);
	        await _context.SaveChangesAsync();
	        return NoContent();
        }

        [HttpPost("{id}/SetMessageTemplate")]
        public async Task<ActionResult> SetMessageTemplate(ulong id, [FromForm] string messageTemplate, [FromForm] string embedTemplate)
        {
			//Check webhook exists
	        if (!await _context.Webhooks.AnyAsync(x => x.WebhookId == id)) return BadRequest();

			//Get webhook
	        var webhook = await _context.Webhooks.FirstAsync(x => x.WebhookId == id);
			//Set templates
	        webhook.MessageTemplate = messageTemplate;
	        webhook.EmbedTemplate = embedTemplate;
	        await _context.SaveChangesAsync();
	        return NoContent();
		}

        [HttpGet("GetAllWebhooks")]
        public async Task<ActionResult> GetAll()
        {
	        var webhooks = await _context.Webhooks.ToArrayAsync();
	        return Ok(webhooks);
        }

		[HttpDelete("{id}")]
        public async Task<ActionResult> DeleteWebhook(ulong id)
        {
			//Check webhook exists
	        if (await _context.Webhooks.AnyAsync(x => x.WebhookId == id)) return BadRequest();

			//Get webhook
	        var webhook = await _context.Webhooks.FirstAsync(x => x.WebhookId == id);
			//Delete the webhook
	        _context.Remove(webhook);
	        await _context.SaveChangesAsync();
	        return NoContent();
		}
	}
}
