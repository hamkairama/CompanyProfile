using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Linq;
using System;

namespace CompanyProjectHelper
{
   public class CurrentUser : AuthorizeAttribute
    {
       public static string GetCurrentUserId()
        {
            if (HttpContext.Current.Session["userId"] != null)
            {
                return HttpContext.Current.Session["userId"].ToString();
            }
            else
            {
                return null;
            }
            
        }

        public static bool IsAdmin()
        {
            if (HttpContext.Current.Session["admin"] != null)
            {
                return (bool)HttpContext.Current.Session["admin"];
            }
            else
            {
                return false;
            }

        }

        public static DateTime GetCurrentDateTime()
        {
            return DateTime.Now;
        }
    }
}
