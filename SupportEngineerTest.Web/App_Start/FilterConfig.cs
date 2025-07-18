using System.Web;
using System.Web.Mvc;

namespace SupportEngineerTest.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new CacheControlFilter());
        }
    }

    public class CacheControlFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.AddHeader("Cache-Control", "no-cache");
            base.OnActionExecuting(filterContext);
        }
    }
}
