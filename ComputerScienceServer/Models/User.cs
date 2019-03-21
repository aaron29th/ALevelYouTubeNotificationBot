using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using ComputerScienceServer.Models.DiscordWebhook;
using ComputerScienceServer.Models.Twitter;
using ComputerScienceServer.Models.Youtube;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace ComputerScienceServer.Models
{
	public class User
	{
		//Auto increment id
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		[Index(IsUnique = true)]
		public string Username { get; set; }
		public string PasswordHash { get; set; }
		public DateTime Registered { get; set; }
		public string Role { get; set; }

		public User()
		{
			
		}

		public User(string username, string password)
		{
			Username = username;
			PasswordHash = new PasswordHasher<User>().HashPassword(this, password);
			Registered = DateTime.Now;
			Role = "StandardUser";
		}

		public string GetToken(string password)
		{
			//Verify the password is correct
			var result = new PasswordHasher<User>().VerifyHashedPassword(this,
				PasswordHash, password);

			if (result == PasswordVerificationResult.Failed) return null;

			var claims = new[]
			{
				new Claim(ClaimTypes.Name, Id.ToString())
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

		public bool ChangePassword(string oldPassword, string newPassword)
		{
			return false;
		}
	}
}
