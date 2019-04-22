using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Linq;
using System;
using CompanyProjectModel;
using System.Collections.Generic;

namespace CompanyProjectHelper
{
   public class Setup 
    {
        //private startprojectEntities db = new startprojectEntities();

        public static List<T_TEAM> GetDataTeam()
        {
            List<T_TEAM> lTeam = new List<T_TEAM>();
            using (startprojectEntities db = new startprojectEntities())
            {
                lTeam = db.T_TEAM.ToList();
            }
            

            return lTeam;
        }

        public static List<T_SERVICE> GetDataService()
        {

            List<T_SERVICE> lService = new List<T_SERVICE>();
            using (startprojectEntities db = new startprojectEntities())
            {
                lService = db.T_SERVICE.ToList();
            }

            return lService;
        }

        public static List<T_PORTFOLIO> GetDataPortfolio()
        {
            List<T_PORTFOLIO> lPortfolio = new List<T_PORTFOLIO>();
            using (startprojectEntities db = new startprojectEntities())
            {
                lPortfolio = db.T_PORTFOLIO.ToList();
            }

            return lPortfolio;
        }

        public static List<T_ABOUT> GetDataAbout()
        {

            List<T_ABOUT> lAbout = new List<T_ABOUT>();
            using (startprojectEntities db = new startprojectEntities())
            {
                lAbout = db.T_ABOUT.ToList();
            }
            
            return lAbout;
        }

        public static List<T_CLIENT> GetDataClient()
        {

            List<T_CLIENT> lClient = new List<T_CLIENT>();
            using (startprojectEntities db = new startprojectEntities())
            {
                lClient = db.T_CLIENT.ToList();
            }

            return lClient;
        }
    }
}
