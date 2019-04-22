using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CompanyProjectHelper
{
    class AuthorizeLogin : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool isValid = false;
            if (CurrentUser.IsAdmin())
            {
                isValid = true;
            }
            return isValid;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(new
                RouteValueDictionary(new { controller = "Home", action = "Index" }));
        }
    }
}
