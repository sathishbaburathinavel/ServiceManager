using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Addon.ServiceManager
{
    public class MyAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task GrantClientCredentials(OAuthGrantClientCredentialsContext context)
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