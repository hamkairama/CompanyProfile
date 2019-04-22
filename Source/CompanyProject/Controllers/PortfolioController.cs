using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CompanyProjectModel;
using CompanyProjectHelper;

namespace MVCProject.Controllers
{
    public class PortfolioController : Controller
    {
        private startprojectEntities db = new startprojectEntities();

        [CAuthorize()]
        public ActionResult Index()
        {
            ViewBag.msgSuccess = TempData["msgSuccess"];
            ViewBag.msgError = TempData["msgError"];
            List<T_PORTFOLIO> portfolio = db.T_PORTFOLIO.ToList();
            return PartialView(portfolio);
        }

        [CAuthorize()]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_PORTFOLIO portfolio = db.T_PORTFOLIO.Find(id);
            if (portfolio == null)
            {
                return HttpNotFound();
            }
            return PartialView("Details", portfolio);
        }

        [CAuthorize()]
        public ActionResult Create()
        {
            ViewBag.msgSuccess = TempData["msgSuccess"];
            ViewBag.msgError = TempData["msgError"];
            return PartialView("Create");
        }

        [CAuthorize()]
        public ActionResult ActionCreate(T_PORTFOLIO portfolio)
        {
            ResultStatus rs = new ResultStatus();

            if (ModelState.IsValid)
            {
                try
                {
                    portfolio.created_by = CurrentUser.GetCurrentUserId();
                    portfolio.created_dt = CurrentUser.GetCurrentDateTime();
                    db.T_PORTFOLIO.Add(portfolio);
                    db.SaveChanges();
                    rs.SetSuccessStatus("Data has been created successfully");
                    TempData["msgSuccess"] = rs.MessageText;
                }
                catch (DataException ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    rs.SetErrorStatus("Data failed to created");
                    TempData["msgError"] = rs.MessageText;
                }
            }
            else
            {
                rs.SetErrorStatus("Asteric (*) field is mandatory");
                TempData["msgError"] = rs.MessageText;
            }

            return Json(rs);
        }

        [CAuthorize()]
        public ActionResult Edit(int? id)
        {
            ViewBag.msgSuccess = TempData["msgSuccess"];
            ViewBag.msgError = TempData["msgError"];

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_PORTFOLIO portfolio = db.T_PORTFOLIO.Find(id);
            if (portfolio == null)
            {
                return HttpNotFound();
            }
            return PartialView("Edit", portfolio);
        }

        [CAuthorize()]
        public ActionResult ActionEdit(T_PORTFOLIO portfolio)
        {
            ResultStatus rs = new ResultStatus();

            if (ModelState.IsValid)
            {
                try
                {
                    portfolio.last_modified_by = CurrentUser.GetCurrentUserId();
                    portfolio.last_modified_dt = CurrentUser.GetCurrentDateTime();
                    db.Entry(portfolio).State = EntityState.Modified;
                    db.SaveChanges();
                    rs.SetSuccessStatus("Data has been edited successfully");
                    TempData["msgSuccess"] = rs.MessageText;
                }
                catch (DataException ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    rs.SetErrorStatus("Data failed to edited");
                    TempData["msgError"] = rs.MessageText;
                }
            }
            else
            {
                rs.SetErrorStatus("Asteric (*) field is mandatory");
                TempData["msgError"] = rs.MessageText;
            }

            return Json(rs);
        }

        [CAuthorize()]
        public ActionResult Delete(int? id)
        {
            ViewBag.msgSuccess = TempData["msgSuccess"];
            ViewBag.msgError = TempData["msgError"];

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_PORTFOLIO portfolio = db.T_PORTFOLIO.Find(id);
            if (portfolio == null)
            {
                return HttpNotFound();
            }
            return PartialView("Delete", portfolio);
        }

        [CAuthorize()]
        public ActionResult ActionDelete(int id)
        {
            ResultStatus rs = new ResultStatus();

            try
            {
                T_PORTFOLIO portfolio = db.T_PORTFOLIO.Find(id);
                db.T_PORTFOLIO.Remove(portfolio);
                db.SaveChanges();
                rs.SetSuccessStatus("Data has been deleted successfully");
                TempData["msgSuccess"] = rs.MessageText;
            }
            catch (DataException ex)
            {
                ModelState.AddModelError("", ex.Message);
                rs.SetErrorStatus("Data failed to deleted");
                TempData["msgError"] = rs.MessageText;
            }

            return Json(rs);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
