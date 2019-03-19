using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComputerScienceServer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace ComputerScienceServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
	    private readonly WebApiContext _context;

		public AuthController(WebApiContext context)
	    {
			_context = context;
		}

	    [HttpPost("Login")]
	    public async Task<ActionResult> Login([FromForm] string username)
	    {
		    StringValues password;
		    Request.Form.TryGetValue("password", out password);



			Response.Headers.Add("token", "");
		    return NoContent();
	    }
    }
}
