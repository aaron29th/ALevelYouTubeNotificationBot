using YoutubeNotifyBot.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace YoutubeNotifyBot
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
			//Initialize the security key for signing tokens
			var symmetricSecurityKey = new SymmetricSecurityKey(Config.JwtSecurityKey);
			//Add the authentication service
			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				.AddJwtBearer(options =>
				{
					options.TokenValidationParameters = new TokenValidationParameters
					{
						//Configure the service to require the tokens issuer and audience are correct
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
				//Require authorization by default
				var policy = new AuthorizationPolicyBuilder()
					.RequireAuthenticatedUser()
					.Build();
				//Add the authentication middleware
				options.Filters.Add(new AuthorizeFilter(policy));

				//Allow xml deserialization of post requests
				options.InputFormatters.Add(new XmlSerializerInputFormatter(options));
			});

			//Initialise web api context class with connection to the azure postgres database
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

			//Enable the authentication middleware
			app.UseAuthentication();
			app.UseMvc();
		}
	}
}
