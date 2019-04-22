using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompanyProjectHelper;

namespace CompanyProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.DataTeam = Setup.GetDataTeam();
            ViewBag.DataAbout = Setup.GetDataAbout();
            ViewBag.DataPortfolio = Setup.GetDataPortfolio();
            ViewBag.DataService = Setup.GetDataService();
            ViewBag.Dataclient = Setup.GetDataClient();

            return View();
        }

        public ActionResult TableAce()
        {
            return PartialView("TableAce");
        }

    }
}