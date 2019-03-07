using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Primitives;

namespace ComputerScienceServer.Authentication
{
    public class CustomAuthOptions : AuthenticationSchemeOptions
    {
        public const string DefaultScheme = "custom auth";
        public string Scheme => DefaultScheme;
        public StringValues SecureToken { get; set; }
    }
}