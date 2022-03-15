using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TEKenable.ProjectTemplate.Web.Models;
using TEKenable.ProjectTemplate.Services;
using System.IO;
using log4net;
using TEKenable.ProjectTemplate.Web.Infrastructure;
using TEKenable.ProjectTemplate.Web.Controllers;

namespace TEKenable.ProjectTemplate.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            //Log4Net
            Log4NetManager.InitializeLog4Net();

            //IoC initializer
            UnityConfig.RegisterComponents();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            var logger = LogManager.GetLogger(this.GetType());
            logger.Info("Application_Start executed");
        }

        protected void Application_PostAuthenticateRequest(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                var identity = new AppIdentity(HttpContext.Current.User.Identity);
                var principal = new AppPrincipal(identity);
                Thread.CurrentPrincipal = HttpContext.Current.User = principal;
            }
        }

        //protected void Application_Error(object sender, EventArgs e)
        //{
        //    var exception = Server.GetLastError();
        //    //Log the error
        //    var logger = LogManager.GetLogger(this.GetType());
        //    logger.Error("Application_Error", exception);

        //    var httpContext = ((MvcApplication)sender).Context;
        //    var currentController = " ";
        //    var currentAction = " ";
        //    RouteData currentRouteData = null;
        //    try
        //    {
        //        currentRouteData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(httpContext));
        //    }
        //    catch{}
            
        //    if (currentRouteData != null)
        //    {
        //        if (currentRouteData.Values["controller"] != null && !String.IsNullOrEmpty(currentRouteData.Values["controller"].ToString()))
        //        {
        //            currentController = currentRouteData.Values["controller"].ToString();
        //        }

        //        if (currentRouteData.Values["action"] != null && !String.IsNullOrEmpty(currentRouteData.Values["action"].ToString()))
        //        {
        //            currentAction = currentRouteData.Values["action"].ToString();
        //        }
        //    }

        //    var controller = new ErrorController();
        //    var routeData = new RouteData();
        //    var action = "Index";

        //    if (exception is HttpException)
        //    {
        //        var httpEx = exception as HttpException;
        //        if(httpEx.GetHttpCode() == 404)
        //        {
        //                action = "NotFound";
                    
        //        }
        //        if (httpEx.GetHttpCode() == 404 && httpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
        //        {
        //            action = "NotFoundAjax";
        //        }
        //        // others if any
        //    }

        //    httpContext.ClearError();
        //    httpContext.Response.Clear();
        //    httpContext.Response.StatusCode = exception is HttpException ? ((HttpException)exception).GetHttpCode() : 500;
        //    httpContext.Response.TrySkipIisCustomErrors = true;

        //    routeData.Values["controller"] = "Error";
        //    routeData.Values["action"] = action;

        //    controller.ViewData.Model = new HandleErrorInfo(exception, currentController, currentAction);
        //    ((IController)controller).Execute(new RequestContext(new HttpContextWrapper(httpContext), routeData));
        //}
    }
}