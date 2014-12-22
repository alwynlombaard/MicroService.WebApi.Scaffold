using System.Net.Http;
using System.Web.Http.Filters;
using log4net;

namespace MicroService.WebApi.Filters
{
    public class OwinRequestExceptionLoggerAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            var owinContext = actionExecutedContext.ActionContext.Request.GetOwinContext();
            owinContext.Set("webapi.exception", actionExecutedContext.Exception);

            LogManager.GetLogger("Default").Error("Unhandled Exception occured.", actionExecutedContext.Exception);
        }
    }
}
