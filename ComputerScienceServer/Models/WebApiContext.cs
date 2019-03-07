using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ComputerScienceServer.Models
{
	public class WebApiContext : DbContext
	{
		public WebApiContext(DbContextOptions<WebApiContext> options) : base(options)
		{
		}

		public DbSet<DiscordWebhook> Webhooks { get; set; }
		public DbSet<TwitterUser> TwitterUsers { get; set; }
	}
}