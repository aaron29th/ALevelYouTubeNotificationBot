using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace ComputerScienceServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
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
