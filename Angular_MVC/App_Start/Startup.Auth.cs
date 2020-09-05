using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Notifications;
using Microsoft.Owin.Security.OpenIdConnect;
using Owin;

namespace Angular_MVC.App_Start
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            if (!WebApiConfiguration.AuthEnabled)
            {
                return;
            }

            try
            {
                Microsoft.IdentityModel.Logging.IdentityModelEventSource.ShowPII = true;

                app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);
                string cookiesFolder = GetCookiesFolder();
                //DevFxLogger.Instance.Log("Folder: " + cookiesFolder);

                app.UseCookieAuthentication(new CookieAuthenticationOptions()
                {
                    AuthenticationType = CookieAuthenticationDefaults.AuthenticationType,
                    //CookiePath = cookiesFolder
                });

                app.UseOpenIdConnectAuthentication(ConfigurePolicyOptions(WebApiConfiguration.B2CResetPasswordPolicy));
                app.UseOpenIdConnectAuthentication(ConfigurePolicyOptions(WebApiConfiguration.B2CSignInPolicy));
            }
            catch (Exception ex)
            {
                //DevFxLogger.Instance.Log(ex);
                throw new Exception("ConfigureAuth Failed");
            }
        }

        private OpenIdConnectAuthenticationOptions ConfigurePolicyOptions(string policyName)
        {
            string authority = string.Format(WebApiConfiguration.B2CAuthorityUrl, policyName);

            var options = new OpenIdConnectAuthenticationOptions
            {
                Authority = authority,
                AuthenticationType = policyName,

                ClientId = WebApiConfiguration.B2CAuthClientId,
                RedirectUri = WebApiConfiguration.B2CAuthReturnUrl,
                PostLogoutRedirectUri = WebApiConfiguration.B2CAuthReturnUrl,

                Notifications = new OpenIdConnectAuthenticationNotifications
                {
                    //RedirectToIdentityProvider = OnRedirectToIdentityProvider,
                    //AuthorizationCodeReceived = OnAuthorizationCodeReceived,
                    AuthenticationFailed = OnAuthenticationFailed,
                },

                TokenValidationParameters = new TokenValidationParameters
                {
                    NameClaimType = "name",
                    ValidateIssuer = false
                },

                Scope = $"openid profile offline_access"
            };

            return options;
        }

        private async Task OnRedirectToIdentityProvider(RedirectToIdentityProviderNotification<OpenIdConnectMessage, OpenIdConnectAuthenticationOptions> notification)
        {
            var policy = notification.OwinContext.Get<string>("Policy");

            if (!string.IsNullOrEmpty(policy) && !policy.Equals(WebApiConfiguration.B2CSignInPolicy))
            {
                notification.ProtocolMessage.Scope = OpenIdConnectScope.OpenId;
                notification.ProtocolMessage.ResponseType = OpenIdConnectResponseType.IdToken;
                notification.ProtocolMessage.IssuerAddress = notification.ProtocolMessage.IssuerAddress.ToLower().Replace(WebApiConfiguration.B2CSignInPolicy.ToLower(), policy.ToLower());
            }

            await Task.FromResult(0);
        }

        private async Task OnAuthenticationFailed(AuthenticationFailedNotification<OpenIdConnectMessage, OpenIdConnectAuthenticationOptions> notification)
        {
            if (notification.Exception.Message.Contains("IDX21323"))
            {
                notification.HandleResponse();
                notification.OwinContext.Authentication.Challenge();
            }
            else if (notification.ProtocolMessage.ErrorDescription != null && notification.ProtocolMessage.ErrorDescription.Contains("AADB2C90118"))
            {
                notification.HandleResponse();

                string passwordPolicy = WebApiConfiguration.B2CResetPasswordPolicy;
                string redirectUri = WebApiConfiguration.B2CAuthReturnUrl;
                notification.OwinContext.Authentication.Challenge(new AuthenticationProperties() { RedirectUri = redirectUri }, passwordPolicy);
            }
            else if (notification.Exception.Message == "access_denied")
            {
                notification.HandleResponse();
                notification.Response.Redirect("/");
            }

            await Task.FromResult(0);
        }

        private string GetCookiesFolder()
        {
            // Find virtual directory folder:
            string root = WebApiConfiguration.SiteRoot;

            if (root.Count(x => x == '/') < 4)
            {
                return "/";
            }

            int lastSlash = root.LastIndexOf('/');
            int prevSlash = root.Substring(0, lastSlash).LastIndexOf('/');
            string folder = root.Substring(prevSlash, lastSlash - prevSlash + 1);
            return folder;
        }
    }
}