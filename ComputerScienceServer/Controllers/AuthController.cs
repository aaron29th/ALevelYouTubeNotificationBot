using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ComputerScienceServer.Models;
using ComputerScienceServer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;

namespace ComputerScienceServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
	    private readonly WebApiContext _context;
	    private readonly IUserService _userService;

		public AuthController(WebApiContext context, IUserService userService)
	    {
			_context = context;
			_userService = userService;
	    }

		[AllowAnonymous]
	    [HttpPost("GetToken")]
	    public async Task<ActionResult> GetToken([FromForm] string username, [FromForm] string password)
	    {
			var user = await _context.Users.FirstAsync(x => x.Username == username
			                                                && x.Password == password);

			// return null if user not found
			if (user == null)
				return null;

			var claims = new[]
			{
				new Claim(ClaimTypes.Name, username)
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

			Response.Headers.Add("token", new JwtSecurityTokenHandler().WriteToken(token));
		    return NoContent();
	    }

	    [AllowAnonymous]
		[HttpGet("AddUser")]
	    public async Task<ActionResult> AddUser([FromForm] string username, [FromForm] string password)
	    {
			//Hash password
			await _context.Users.AddAsync(new User()
			{
				Username = username,
				Password = password,
				Registered = DateTime.Now
			});
			await _context.SaveChangesAsync();
			return Ok();
	    }
	}
}
