using System;
using System.Security.Principal;
using System.Web;
using TEKenable.ProjectTemplate.Web.Infrastructure;

namespace TEKenable.ProjectTemplate.Web
{
    public static class HelperExtensions
    {
        public static String CurrentUserFullName(this IIdentity Identity)
        {
            return ((AppPrincipal)HttpContext.Current.User).AppIdentity.FullName;
        }
    }
}