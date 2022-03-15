using System.Web.Mvc;
using TEKenable.ProjectTemplate.Web.Infrastructure;

namespace TEKenable.ProjectTemplate.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new CustomHandleErrorAttribute());
        }
    }
}