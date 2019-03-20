﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ComputerScienceServer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace ComputerScienceServer.Services
{
	public interface IUserService
	{
		Task<string> Authenticate(string username, string password);
		Task AddUser(string username, string password);
	}

	public class UserService : IUserService
	{
		private readonly WebApiContext _context;

		public UserService(WebApiContext context)
		{
			_context = context;
		}

		public async Task<string> Authenticate(string username, string password)
		{
			//var hash = 

			var user = await _context.Users.FirstAsync(x => x.Username == username 
			                                                && x.Password == password);

			// return null if user not found
			if (user == null)
				return null;

			var claims = new []
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

			return new JwtSecurityTokenHandler().WriteToken(token);
		}

		public async Task AddUser(string username, string password)
		{
			await _context.Users.AddAsync(new User()
			{
				Username = username,
				Password = password,
				Registered = DateTime.Now
			});
			await _context.SaveChangesAsync();
		}
	}
}