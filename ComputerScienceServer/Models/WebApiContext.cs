using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YoutubeNotifyBot.Models.DiscordWebhook;
using YoutubeNotifyBot.Models.Twitter;
using YoutubeNotifyBot.Models.Youtube;
using Microsoft.EntityFrameworkCore;

namespace YoutubeNotifyBot.Models
{
	public class WebApiContext : DbContext
	{
		public WebApiContext(DbContextOptions<WebApiContext> options) : base(options)
		{
		}

		public DbSet<Webhook> Webhooks { get; set; }
		public DbSet<WebhookYoutubeSubscription> WebhookYoutubeSubscriptions { get; set; }

		public DbSet<TwitterUser> TwitterUsers { get; set; }
		public DbSet<TwitterUserYoutubeSubscription> TwitterYoutubeSubscriptions { get; set; }

		public DbSet<YoutubeSubscription> YoutubeSubscriptions { get; set; }
		
		public DbSet<ErrorLog> ErrorLog { get; set; }

		public DbSet<ApplicationUser> Users { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//Configure composite key for linking table
			modelBuilder.Entity<WebhookYoutubeSubscription>().HasKey(
				webhookYoutube => new
				{
					webhookYoutube.WebhookId,
					webhookYoutube.YoutubeChannelId
				});
			//Configure one WebhookYoutubeSubscription to one webhook link
			modelBuilder.Entity<WebhookYoutubeSubscription>()
				.HasOne(wys => wys.Webhook)
				.WithMany(webhook => webhook.WebhookYoutubeSubscriptions)
				.HasForeignKey(wys => wys.WebhookId);

			//Configure composite key for linking table
			modelBuilder.Entity<TwitterUserYoutubeSubscription>().HasKey(
				twitterYoutube => new
				{
					twitterYoutube.TwitterUserId,
					twitterYoutube.YoutubeChannelId
				});
			//Configure one TwitterUserYoutubeSubscription to one TwitterUser link
			modelBuilder.Entity<TwitterUserYoutubeSubscription>()
				.HasOne(tuys => tuys.TwitterUser)
				.WithMany(twitterUser => twitterUser.TwitterYoutubeSubscription)
				.HasForeignKey(tuys => tuys.TwitterUserId);
		}
	}
}