using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web.Mvc;
using TEKenable.ProjectTemplate.Services;
using TEKenable.ProjectTemplate.Services.Entities;

namespace TEKenable.ProjectTemplate.Web.Infrastructure
{
    public class AppPrincipal : IPrincipal
    {
        #region Implementation of IPrincipal

        /// <summary>
        /// Determines whether the current principal belongs to the specified role.
        /// </summary>
        /// <returns>
        /// true if the current principal is a member of the specified role; otherwise, false.
        /// </returns>
        /// <param name="role">The name of the role for which to check membership. </param>
        public bool IsInRole(string role)
        {
            return Identity is AppIdentity &&
                   ((AppIdentity)Identity).IsRoleExists(role);
        }

        /// <summary>
        /// Gets the identity of the current principal.
        /// </summary>
        /// <returns>
        /// The <see cref="T:System.Security.Principal.IIdentity"/> object associated with the current principal.
        /// </returns>
        public IIdentity Identity { get; private set; }

        #endregion

        public AppIdentity AppIdentity { get { return (AppIdentity)Identity; } set { Identity = value; } }

        public AppPrincipal(AppIdentity identity)
        {
            Identity = identity;
        }
    }

    public class AppIdentity : IIdentity
    {
        #region Properties

        public IIdentity Identity { get; set; }

        public string first_name { get; set; }

        public string last_name { get; set; }

        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", first_name, last_name);
            }
        }

        public string user_name { get; set; }

        public List<Role> Roles { get; set; }

        public bool IsRoleExists(string role_name)
        {
            return Roles.Exists(r => String.Compare(r.role_name, role_name, StringComparison.OrdinalIgnoreCase) == 0);
        }
        #endregion

        #region Implementation of IIdentity

        /// <summary>
        /// Gets the name of the current user.
        /// </summary>
        /// <returns>
        /// The name of the user on whose behalf the code is running.
        /// </returns>
        public string Name
        {
            get { return Identity.Name; }
        }

        /// <summary>
        /// Gets the type of authentication used.
        /// </summary>
        /// <returns>
        /// The type of authentication used to identify the user.
        /// </returns>
        public string AuthenticationType
        {
            get { return Identity.AuthenticationType; }
        }

        /// <summary>
        /// Gets a value that indicates whether the user has been authenticated.
        /// </summary>
        /// <returns>
        /// true if the user was authenticated; otherwise, false.
        /// </returns>
        public bool IsAuthenticated { get { return Identity.IsAuthenticated; } }

        #endregion

        public AppIdentity(IIdentity identity)
        {
            Identity = identity;
            var service = DependencyResolver.Current.GetService<ISecurityService>();

            var user = service.GetUser(identity.Name);
            if (user != null)
            {
                first_name = user.first_name;
                last_name = user.last_name;
                user_name = user.user_name;
                
                Roles = user.Roles.ToList();
            }
        }
    }
}