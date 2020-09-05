using Autofac;
using Autofac.Integration.WebApi;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net.Http.Headers;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Cors;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Routing;

namespace Angular_MVC.App_Start
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes(new CentralizedPrefixProvider("api"));
            var corsPolicy = new EnableCorsAttribute(WebApiConfiguration.Origins, "*", "*");
            config.EnableCors(corsPolicy);
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
          );

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("multipart/form-data"));

            var formatters = config.Formatters;
            var jsonFormatter = formatters.JsonFormatter;
            var settings = jsonFormatter.SerializerSettings;
            settings.Formatting = Formatting.Indented;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            settings.DateFormatHandling = DateFormatHandling.IsoDateFormat;

            //config.SuppressDefaultHostAuthentication();

            IContainer container = RegisterServices(new ContainerBuilder());
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            //config.Services.Replace(typeof(IExceptionHandler), new ApsExceptionHandler());
            //config.Filters.Add(new DevFxApiLogFilterAttribute());
            //config.Filters.Add(new ApsExceptionFilter());
            //config.MessageHandlers.Add(new ApsMessageHandler());

            config.EnsureInitialized();
        }

        public static IContainer RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            //builder.Register(b => DevFxLogger.Instance).SingleInstance().As<System.Web.Http.Tracing.ITraceWriter>();
            //builder.Register(b => {
            //    var traceWriter = b.Resolve<System.Web.Http.Tracing.ITraceWriter>();
            //    var logger = (ILogger)traceWriter;
            //    ApsDbContext context = DbFactory.Create(logger);
            //    return context;
            //}).InstancePerRequest();

            IContainer container = builder.Build();

            return container;
        }

        public class CentralizedPrefixProvider : DefaultDirectRouteProvider
        {
            private readonly string _centralizedPrefix;

            public CentralizedPrefixProvider(string centralizedPrefix)
            {
                _centralizedPrefix = centralizedPrefix;
            }

            protected override string GetRoutePrefix(HttpControllerDescriptor controllerDescriptor)
            {
                var existingPrefix = base.GetRoutePrefix(controllerDescriptor);
                if (existingPrefix == null)
                    return _centralizedPrefix;

                return string.Format("{0}/{1}", _centralizedPrefix, existingPrefix);
            }
        }
    }
    
}