using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ComputerScienceServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebSockets.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;

namespace ComputerScienceServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
	    private readonly WebApiContext _context;

		public UserController(WebApiContext context)
	    {
			_context = context;
	    }

		[AllowAnonymous]
	    [HttpPost("GetToken")]
	    public async Task<ActionResult> GetToken([FromForm] string username, [FromForm] string password)
	    {
		    if (!await _context.Users.AnyAsync(x => x.Username == username))
		    {
				return BadRequest(new Dictionary<string, string>
				{
					{ "Error", "Username doesn't exist" }
				});
			}

			var user = await _context.Users.FirstAsync(x => x.Username == username);

			string token = user.GetToken(password);
			if (token == null) return Unauthorized();

			Response.Headers.Add("token", token);
		    return NoContent();
	    }

	    [Authorize(Roles = "Admin")]
		[HttpPost("Add")]
	    public async Task<ActionResult> AddUser([FromForm] string username, [FromForm] string password)
	    {
		    if (await _context.Users.AnyAsync(user => user.Username == username))
		    {
				return BadRequest(new Dictionary<string, string>
				{
					{ "Error", "Username already exists" }
				});
		    }

			await _context.Users.AddAsync(new ApplicationUser(username, password));
			await _context.SaveChangesAsync();
			return Ok();
	    }

		[Authorize(Roles = "Admin")]
		[HttpPost("Delete/{id}")]
	    public async Task<ActionResult> DeleteUser(int id)
	    {
		    if (await _context.Users.AnyAsync(user => user.Id == id)) return BadRequest();

		    var userToBeDeleted = await _context.Users.FirstAsync(x => x.Id == id);
		    _context.Users.Remove(userToBeDeleted);
		    await _context.SaveChangesAsync();
		    return Ok();
	    }
	}
}
