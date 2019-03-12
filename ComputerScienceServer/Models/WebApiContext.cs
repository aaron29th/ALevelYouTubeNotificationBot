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
		public DbSet<DiscordWebhookYoutubeSubscription> WebhookYoutubeSubscriptions { get; set; }

		public DbSet<TwitterUser> TwitterUsers { get; set; }
		public DbSet<TwitterYoutubeSubscription> TwitterYoutubeSubscriptions { get; set; }

		public DbSet<YoutubeSubscription> YoutubeSubscriptions { get; set; }
		
		public DbSet<ErrorLog> ErrorLog { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//Configure composite key for linking tale
			modelBuilder.Entity<DiscordWebhookYoutubeSubscription>().HasKey(
				webhookYoutube => new { webhookYoutube.Token, webhookYoutube.ChannelId });

			//Configure composite key for linking tale
			modelBuilder.Entity<TwitterYoutubeSubscription>().HasKey(
				twitterYoutube => new { twitterYoutube.Token, twitterYoutube.ChannelId });
		}
	}
}