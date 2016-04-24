using HelloWorld.Core;
using HelloWorld.Core.Abstract;
using System.Collections.Generic;
using System.Web.Http;

namespace HelloWorld.Api.Controllers
{
    public class MetricsController : ApiController
    {
        private IMetrics _metrics;

        public MetricsController(IMetrics metrics)
        {
            _metrics = metrics;
        }

        [HttpGet, Route("metrics")]
        public List<Metrics> Get()
        {
           return _metrics.GetAll();
        }
    }
}