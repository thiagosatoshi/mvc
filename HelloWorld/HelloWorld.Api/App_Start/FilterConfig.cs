using HelloWorld.Core.Abstract;
using System.Web;
using System.Web.Mvc;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace HelloWorld.Api
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
