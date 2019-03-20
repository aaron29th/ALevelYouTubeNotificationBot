using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ComputerScienceServer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;

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

	    [HttpPost("GetToken")]
	    public async Task<ActionResult> GetToken([FromForm] string username, [FromForm] string password)
	    {
			var claims = new List<Claim>
			{
				new Claim(ClaimTypes.Role, "StandardUser")
			};

			var symmetricSecurityKey = new SymmetricSecurityKey(Config.JwtSecurityKey);

			var signingCredentials = new SigningCredentials(symmetricSecurityKey, 
				SecurityAlgorithms.HmacSha384Signature);

			var token = new JwtSecurityToken(
					issuer: Config.JwtIssuer, 
					audience: Config.JwtAudience,
					expires: DateTime.Now.AddDays(1),
					signingCredentials: signingCredentials,
					claims: claims
				);

			string tokenString = new JwtSecurityTokenHandler().WriteToken(token);
			Response.Headers.Add("token", tokenString);
		    return NoContent();
	    }
    }
}
