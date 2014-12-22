using System;
using System.Web.Http;
using log4net;

namespace MicroService.WebApi.WebApi
{
    [RoutePrefix("")]
    public class HomeController : ApiController
    {
        private readonly ILog _log;

        public HomeController(ILog log)
        {
            _log = log;
        }

        [HttpGet]
        [Route("hello")]
        [Route("")]
        public IHttpActionResult Get()
        {
            _log.Info("Loading hello endpoint");
            return Ok(new
            {
                Message = "Hello world",
                Timestamp = DateTime.UtcNow.ToLongTimeString()
            });
        }
    }
}
