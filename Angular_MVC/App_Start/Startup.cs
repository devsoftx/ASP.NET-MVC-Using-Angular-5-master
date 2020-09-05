using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Angular_MVC.App_Start.Startup))]
namespace Angular_MVC.App_Start
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            CorsConfig.ConfigureCors(app);

            ConfigureAuth(app);

            HttpConfiguration config = new HttpConfiguration();

            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            app.UseAutofacWebApi(config);
        }
    }
}