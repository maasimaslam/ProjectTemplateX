using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using TEKenable.ProjectTemplate.Services.Entities;

namespace TEKenable.ProjectTemplate.Web.Infrastructure
{
    public class AuthorizedAttribute : System.Web.Mvc.AuthorizeAttribute
    {
        public AuthorizedAttribute() { }

        public AuthorizedAttribute(params Roles[] roles)
        {
            Roles = string.Join(",", roles.Select(r => r.ToString()));
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(new { controller = "Error", action = "AccessDenied" }));
            }
        }
    }
}