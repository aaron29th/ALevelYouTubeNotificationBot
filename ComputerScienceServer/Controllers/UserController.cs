using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using YoutubeNotifyBot.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;

namespace YoutubeNotifyBot.Controllers
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

		/// <summary>
		/// Returns a bearer authentication token (No auth token required)
		/// </summary>
		/// <param name="username">The users username</param>
		/// <param name="password">The users password</param>
		/// <returns></returns>
		[AllowAnonymous]
		[Produces("application/json")]
		[HttpPost("GetToken")]
	    public async Task<ActionResult> GetToken([Required][FromForm] string username, 
			[Required][FromForm] string password)
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

		    return Ok(new Dictionary<string, string>()
		    {
			    { "token", token }
		    });
	    }

		/// <summary>
		/// Adds a new user (Requires admin role)
		/// </summary>
		/// <param name="username"></param>
		/// <param name="password"></param>
		/// <returns></returns>
	    [Authorize(Roles = "Admin")]
	    [ProducesResponseType((int)HttpStatusCode.NoContent)]
		[HttpPost("Add")]
	    public async Task<ActionResult> AddUser([Required][FromForm] string username, 
			[Required][FromForm] string password)
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
			return NoContent();
	    }

		/// <summary>
		/// Deletes the given user (Requires admin role)
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Authorize(Roles = "Admin")]
		[ProducesResponseType((int)HttpStatusCode.NoContent)]
		[HttpPost("Delete/{id}")]
	    public async Task<ActionResult> DeleteUser(int id)
	    {
		    if (await _context.Users.AnyAsync(user => user.Id == id)) return BadRequest();

		    var userToBeDeleted = await _context.Users.FirstAsync(x => x.Id == id);
		    _context.Users.Remove(userToBeDeleted);
		    await _context.SaveChangesAsync();
		    return NoContent();
	    }
	}
}
