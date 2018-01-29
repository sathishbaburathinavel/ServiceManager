using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Addon.ServiceManager
{
    public class MyAuthenticationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            if (context.UserName == "admin" && context.Password == "admin")
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, "admin"));
                identity.AddClaim(new Claim("userName", "admin"));
                identity.AddClaim(new Claim(ClaimTypes.Name, "Addon Technology"));
                context.Validated(identity);
            }
            else
            {
                context.SetError("Invalid Authentication", "Provide proper credential!");
            }
        }
    }
}