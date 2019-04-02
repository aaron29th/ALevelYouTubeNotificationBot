using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;
using YoutubeNotifyBot.Models;
using YoutubeNotifyBot.Models.DiscordWebhook;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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
	    /// Adds a new webhook to the database
	    /// </summary>
	    /// <param name="webhookId">Webhook id</param>
	    /// <param name="token">Webhook token</param>
	    /// <returns></returns>
	    [ProducesResponseType((int)HttpStatusCode.NoContent)]
	    [HttpPost("AddWebhook")]
        public async Task<ActionResult> AddWebhook([Required][FromForm] ulong webhookId, 
		    [Required][FromForm] string token)
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
		/// <summary>
		/// Sets the message templates for a discord webhook
		/// </summary>
		/// <param name="id">The webhook id</param>
		/// <param name="messageTemplate">Template for a discord message</param>
		/// <param name="embedTemplate">Template for a discord embedded message</param>
		/// <returns></returns>
		[HttpPost("{id}/SetMessageTemplate")]
        public async Task<ActionResult> SetMessageTemplate(ulong id, [Required][FromForm] string messageTemplate, 
			[FromForm] string embedTemplate)
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

		/// <summary>
		/// Returns all the webhooks in the database
		/// </summary>
		/// <returns></returns>
		[Produces("application/json")]
		[HttpGet("GetAllWebhooks")]
        public async Task<ActionResult> GetAll()
        {
	        var webhooks = await _context.Webhooks.ToArrayAsync();
	        return Ok(webhooks);
        }

		/// <summary>
		/// Deletes the given webhook from the database
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[ProducesResponseType((int)HttpStatusCode.NoContent)]
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
