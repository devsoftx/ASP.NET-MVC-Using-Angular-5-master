using Microsoft.Owin.Cors;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Cors;

namespace Angular_MVC.App_Start
{
    public class CorsConfig
    {
        public static void ConfigureCors(IAppBuilder app)
        {
            //app.UseCors(CorsOptions.AllowAll);

            var policy = new CorsPolicy();

            foreach (string origin in WebApiConfiguration.CorsAccessControlAllowOrigin)
            {
                policy.Origins.Add(origin.Trim());
            }

            foreach (string header in WebApiConfiguration.CorsAccessControllAllowHeaders)
            {
                policy.Headers.Add(header.Trim());
            }

            foreach (string method in WebApiConfiguration.CorsAccessControllAllowMethods)
            {
                policy.Methods.Add(method.Trim());
            }

            //policy.ExposedHeaders.Add(Constants.HttpHeaders.SystemDown);

            app.UseCors(new CorsOptions()
            {
                PolicyProvider = new CorsPolicyProvider()
                {
                    PolicyResolver = context => Task.FromResult(policy)
                }
            });
        }
    }
}