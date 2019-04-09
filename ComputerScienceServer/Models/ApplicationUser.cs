using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace YoutubeNotifyBot.Models
{
	public class ApplicationUser
	{
		//Auto increment id
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		[Index(IsUnique = true)]
		public string Username { get; set; }
		public string PasswordHash { get; set; }
		public DateTime Registered { get; set; }
		public string Role { get; set; }

		public ApplicationUser()
		{
			
		}

		public ApplicationUser(string username, string password)
		{
			Username = username;
			PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(this, password);
			Registered = DateTime.Now;
			Role = "StandardUser";
		}

		public string GetToken(string password)
		{
			//Verify the password is correct
			var result = new PasswordHasher<ApplicationUser>().VerifyHashedPassword(this,
				PasswordHash, password);

			if (result == PasswordVerificationResult.Failed) return null;

			var claims = new[]
			{
				new Claim(ClaimTypes.Name, Id.ToString()),
				new Claim(ClaimTypes.Role, Role)
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

		public bool ChangePassword(string currentPassword, string newPassword)
		{
			//Verify the password is correct
			var result = new PasswordHasher<ApplicationUser>().VerifyHashedPassword(this, PasswordHash, currentPassword);

			//Password is incorrect
			if (result == PasswordVerificationResult.Failed) return false;

			//Set new password
			PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(this, newPassword);
			return true;
		}
	}
}
