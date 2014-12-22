using System;
using System.Net.Http.Headers;
using System.Web.Http;
using log4net;
using MicroService.WebApi.Filters;
using Newtonsoft.Json.Serialization;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Owin;
using Topshelf.Ninject;

namespace MicroService.WebApi
{
    public class WebPipeline
    {
        public void Configuration(IAppBuilder application)
        {
            try
            {
                var kernel = NinjectBuilderConfigurator.Kernel;
                application.UseNinjectMiddleware(() => kernel);
                application.UseNinjectWebApi(GetConfiguration());
            }
            catch (Exception ex)
            {
                LogManager.GetLogger("Default").Error("Unhandled Exception occured.", ex);
                throw;
            }
        }

        private static HttpConfiguration GetConfiguration()
        {
            var config = new HttpConfiguration();
            
            //format Json response to be camel case indented and serve Json in web browser get
            config.Formatters.JsonFormatter.Indent = true;
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver =
                new CamelCasePropertyNamesContractResolver();
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            
            //add filter to log unhandled exceptions
            config.Filters.Add(new OwinRequestExceptionLoggerAttribute());

            //routing
            config.MapHttpAttributeRoutes();

            return config;
        }
    }
}
