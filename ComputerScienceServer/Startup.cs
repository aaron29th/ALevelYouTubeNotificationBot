using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using ComputerScienceServer.Authentication;
using ComputerScienceServer.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TweetSharp;

namespace ComputerScienceServer
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{

			// Add authentication 
			services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = CustomAuthOptions.DefaultScheme;
				options.DefaultChallengeScheme = CustomAuthOptions.DefaultScheme;
			})
			.AddCustomAuth(options =>
			{
				options.SecureToken = "custom auth key";
			});

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

			services.AddMvc(options =>
			{
				options.InputFormatters.Add(new XmlSerializerInputFormatter(options));
			});

			services.AddEntityFrameworkNpgsql().AddDbContext<WebApiContext>(options =>
				options.UseNpgsql(Configuration.GetConnectionString("socialMediaPostgres")));
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			// Enable authentication
			app.UseAuthentication();
			app.UseMvc();
		}
	}
}
