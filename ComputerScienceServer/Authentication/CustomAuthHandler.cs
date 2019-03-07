using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using Microsoft.Net.Http.Headers;

namespace ComputerScienceServer.Authentication
{
    public class CustomAuthHandler : AuthenticationHandler<CustomAuthOptions>
    {
        public CustomAuthHandler(IOptionsMonitor<CustomAuthOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) 
            : base(options, logger, encoder, clock)
        {
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            //Check for required values
            if (!Request.Headers.TryGetValue(HeaderNames.UserAgent, out var userAgent))
            {
                
                return Task.FromResult(AuthenticateResult.Fail("Missing useragent"));
            }
            if (!Request.Headers.TryGetValue("ros-SessionTicket", out var rosSessionTicket))
            {
                return Task.FromResult(AuthenticateResult.Fail("Missing session ticket"));
            }
            if (!Request.Headers.TryGetValue("Scs-Ticket", out var scsTicket) && !Request.Form.TryGetValue("ticket", out var formTicket))
            {
                return Task.FromResult(AuthenticateResult.Fail("Missing ticket"));
            }

            // The auth key from Authorization header check against the configured ones
            if (userAgent.Any(key => Options.SecureToken.All(ak => ak != key)))
            {
                return Task.FromResult(AuthenticateResult.Fail("Invalid useragent"));
            }


            // The auth key from Authorization header check against the configured ones
            if (rosSessionTicket.Any(key => Options.SecureToken.All(ak => ak != key)))
            {
                return Task.FromResult(AuthenticateResult.Fail("Invalid useragent"));
            }

            // The auth key from Authorization header check against the configured ones
            if (scsTicket.Any(key => Options.SecureToken.All(ak => ak != key)))
            {
                return Task.FromResult(AuthenticateResult.Fail("Invalid auth key."));
            }

            // Create authenticated user
            var identities = new List<ClaimsIdentity> {new ClaimsIdentity("custom auth type")};
            var ticket = new AuthenticationTicket(new ClaimsPrincipal(identities), Options.Scheme);

            return Task.FromResult(AuthenticateResult.Success(ticket));
        }

        //401 error
        protected override async Task HandleChallengeAsync(AuthenticationProperties properties)
        {
            Response.Headers["WWW-Authenticate"] = "Basic";
            await base.HandleChallengeAsync(properties);
        }

        //403 error
        protected override Task HandleForbiddenAsync(AuthenticationProperties properties)
        {
            return base.HandleForbiddenAsync(properties);
        }
    }
}