using Lab.OAuthWeb.API.DataAccess;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Lab.OAuth.ServiceProviders
{
    public class SecureAuthorizationServiceProvider : OAuthAuthorizationServerProvider
    {
        // responsible for validating the “Client”, in our case we have only one client so we’ll always return that its validated successfullys
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        // responsible to validate the username and password sent to the authorization server’s token endpoint
        // If the credentials are valid we’ll create “ClaimsIdentity” class and pass the authentication type to it, in our case “bearer token”
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            // validate user
            using (IdentityRepository identityRepo = new IdentityRepository())
            {
                var user = identityRepo.FindUser(context.UserName, context.Password);
                if (user == null)
                {
                    context.SetError("invalid_grant", "The user name or password is incorrect.");
                    return;
                }
            }

            var identity = new System.Security.Claims.ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new System.Security.Claims.Claim("sub", context.UserName));
            identity.AddClaim(new System.Security.Claims.Claim("role", "user"));
            // token generation happens here
            context.Validated(identity);
        }
    }
}