using Bussiness;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace Presentation.Utility
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public string UsersConfigKey { get; set; }
        public string RolesConfigKey { get; set; }

        protected virtual CustomPrincipal CurrentUser
        {
            get { return HttpContext.Current.User as CustomPrincipal; }
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAuthenticated)
            {

                var authorizedUsers = ConfigurationManager.AppSettings[UsersConfigKey];
                var authorizedRoles = ConfigurationManager.AppSettings[RolesConfigKey];

                Users = String.IsNullOrEmpty(Users) ? authorizedUsers : Users;
                Roles = String.IsNullOrEmpty(Roles) ? authorizedRoles : Roles;
                RolesConfigKey = String.IsNullOrEmpty(Roles) ? authorizedRoles : RolesConfigKey;

                string ActiveTraning = WebConfigurationManager.AppSettings["ActiveTraning"];
                if (ActiveTraning == "true")
                {
                    filterContext.Result = new RedirectToRouteResult(new
                            RouteValueDictionary(new { controller = "Login", action = "PageNotFound" }));

                }

                if (!String.IsNullOrEmpty(Roles))
                {
                    if (!CurrentUser.IsInRole(Roles))
                    {
                        filterContext.Result = new RedirectToRouteResult(new
                        RouteValueDictionary(new { controller = "Home", action = "PageNotFound" }));
                        // base.OnAuthorization(filterContext); //returns to login url
                    }

                    if (!string.IsNullOrEmpty(RolesConfigKey))
                    {
                        if (!CurrentUser.IsInRolesConfigKey(RolesConfigKey))
                        {
                            filterContext.Result = new RedirectToRouteResult(new
                            RouteValueDictionary(new { controller = "Home", action = "PageNotFound" }));

                            // base.OnAuthorization(filterContext); //returns to login url
                        }
                    }
                    
                }
                if (!String.IsNullOrEmpty(Users))
                {
                    if (!Users.Contains(CurrentUser.UserId.ToString()))
                    {
                        filterContext.Result = new RedirectToRouteResult(new
                        RouteValueDictionary(new { controller = "Error", action = "AccessDenied" }));

                        // base.OnAuthorization(filterContext); //returns to login url
                    }
                }
            }
            else
            filterContext.Result = new RedirectToRouteResult(new
                        RouteValueDictionary(new { controller = "Login", action = "Index" }));
        }

        public  List<string> GetAccessMenu()
        {
            List<string> accessmenu = new List<string>();
            
            string[] tokens = CurrentUser.AccessMenu.Split(',');
                
            foreach (string item in tokens)
            {
                accessmenu.Add(item);
            }
            return accessmenu;
        }

        public string GetUserName()
        {
            return CurrentUser.FirstName+" "+CurrentUser.LastName;
        }

        public string GetPersiaDate(string format)
        {
            General _General = new General();
            return _General.PersianDate(format);
        }

        public int UserId()
        {
            return CurrentUser.UserId;
        }
    }
}