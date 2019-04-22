using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompanyProjectHelper;

namespace MVCProject.Controllers
{
    public class LoginController : Controller
    {
        // GET: About
        public ActionResult ActionLogin(string userId, string password)
        {
            ResultStatus rs = new ResultStatus();
            if (userId == "hamkair" && password == "4426552iR")
            {
                Session["admin"] = true;
                Session["userId"] = userId;
                rs.SetSuccessStatus();
            }
            return Json(rs);
        }
    }
}
