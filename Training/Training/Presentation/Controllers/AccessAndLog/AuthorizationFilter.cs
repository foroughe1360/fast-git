using Presentation.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Presentation.Controllers.AccessAndLog
{
    [CustomAuthorize(Roles = "Admin")]
    public class AuthorizationFilter: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //if (HttpContext.Current.Session["UserName"] != null)
            //{
                filterContext.Result = new RedirectToRouteResult(
                       new RouteValueDictionary{{ "controller", "MainPage" },
                                      { "action", "Default" }

                                         });
            //}
            //base.OnActionExecuting(filterContext);
        }
    }
}