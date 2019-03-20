using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using ComputerScienceServer.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
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
			Config.Init();

			var symmetricSecurityKey = new SymmetricSecurityKey(Config.JwtSecurityKey);

			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				.AddJwtBearer(options =>
				{
					options.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuer = true,
						ValidateAudience = true,
						ValidateIssuerSigningKey = true,
						ValidIssuer = Config.JwtIssuer,
						ValidAudience = Config.JwtAudience,
						IssuerSigningKey = symmetricSecurityKey
					};
				});

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

			services.AddMvc(options =>
			{
				options.InputFormatters.Add(new XmlSerializerInputFormatter(options));
			});

			services.AddEntityFrameworkNpgsql().AddDbContext<WebApiContext>(options =>
				options.UseNpgsql(Configuration.GetConnectionString("azurePostgres")));
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
