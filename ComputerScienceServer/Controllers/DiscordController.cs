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

		//Add webhook
		[HttpPost("AddWebhook")]
		[Consumes("application/json")]
        public async Task<ActionResult> AddWebhook([FromBody] Webhook webhook)
        {
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
