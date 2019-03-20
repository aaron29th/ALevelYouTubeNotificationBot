using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComputerScienceServer.Models.DiscordWebhook;
using ComputerScienceServer.Models.Twitter;
using ComputerScienceServer.Models.Youtube;
using Microsoft.EntityFrameworkCore;

namespace ComputerScienceServer.Models
{
	public class WebApiContext : DbContext
	{
		public WebApiContext(DbContextOptions<WebApiContext> options) : base(options)
		{
		}

		public DbSet<Webhook> Webhooks { get; set; }
		public DbSet<WebhookYoutubeSubscription> WebhookYoutubeSubscriptions { get; set; }

		public DbSet<TwitterUser> TwitterUsers { get; set; }
		public DbSet<TwitterYoutubeSubscription> TwitterYoutubeSubscriptions { get; set; }

		public DbSet<YoutubeSubscription> YoutubeSubscriptions { get; set; }
		
		public DbSet<ErrorLog> ErrorLog { get; set; }

		public DbSet<User> Users { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//Configure composite key for linking tale
			modelBuilder.Entity<WebhookYoutubeSubscription>().HasKey(
				webhookYoutube => new { webhookYoutube.Id, webhookYoutube.ChannelId });

			//Configure composite key for linking tale
			modelBuilder.Entity<TwitterYoutubeSubscription>().HasKey(
				twitterYoutube => new { twitterYoutube.Id, twitterYoutube.ChannelId });
		}
	}
}