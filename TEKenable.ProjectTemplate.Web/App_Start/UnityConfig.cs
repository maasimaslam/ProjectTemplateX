using Microsoft.Practices.Unity;
using System.Web.Mvc;
using TEKenable.ProjectTemplate.Services;
using Unity.Mvc5;
using UnityLog4NetExtension.Log4Net;

namespace TEKenable.ProjectTemplate.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            //https://github.com/roblevine/UnityLog4NetExtension
            container.AddNewExtension<Log4NetExtension>();

            // e.g. container.RegisterType<ITestService, TestService>();

            //container.RegisterType<ProjectTemplate_Context, ProjectTemplate_Context>();
            container.RegisterType<ISecurityService, SecurityService>();
            container.RegisterType<IAdminService, AdminService>();
            //container.RegisterType<IMyService2, MyService2>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}