using HelloWorld.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;

namespace HelloWorld.Api
{
    public class MyTrackingActionFilter : System.Web.Http.Filters.ActionFilterAttribute
    {
        private IMetrics _metrics;

        private Stopwatch _stopWatch;

        public MyTrackingActionFilter()
        {
            _metrics = GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IMetrics)) as IMetrics;
        }

        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            _stopWatch = new Stopwatch();
            _stopWatch.Start();
            base.OnActionExecuting(actionContext);
        }

        public override void OnActionExecuted(System.Web.Http.Filters.HttpActionExecutedContext actionExecutedContext)
        {
            _stopWatch.Stop();

            var controller = actionExecutedContext.ActionContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            var action = actionExecutedContext.ActionContext.ActionDescriptor.ActionName;

            _metrics.Insert(new Core.Metrics { Controller = controller, Action = action, Miliseconds = _stopWatch.ElapsedMilliseconds });

            base.OnActionExecuted(actionExecutedContext);
        }
    }
}