using System.Threading.Tasks;
using ComputerScienceServer.Models;
using ComputerScienceServer.Models.DiscordWebhook;
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
        public async Task<ActionResult> AddWebhook([FromBody] Webhook webhook)
        {
	        if (webhook.VerifyExistence() == false) return BadRequest();

	        await _context.Webhooks.AddAsync(webhook);
	        await _context.SaveChangesAsync();
	        return NoContent();
        }

        public async Task<ActionResult> DeleteWebhook()
        {
	        return Ok();
        }
	}
}
