using System.Web;
using System.Web.Mvc;
using Test1.Filters;

namespace Test1
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new LogFilter());
        }
    }
}
