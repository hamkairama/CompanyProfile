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
    public class AboutController : Controller
    {
        private startprojectEntities db = new startprojectEntities();

        [CAuthorize()]
        public ActionResult Index()
        {
            ViewBag.msgSuccess = TempData["msgSuccess"];
            ViewBag.msgError = TempData["msgError"];
            List<T_ABOUT> about = db.T_ABOUT.ToList();
            return PartialView(about);
        }

        [CAuthorize()]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_ABOUT about = db.T_ABOUT.Find(id);
            if (about == null)
            {
                return HttpNotFound();
            }
            return PartialView("Details", about);
        }

        [CAuthorize()]
        public ActionResult Create()
        {
            ViewBag.msgSuccess = TempData["msgSuccess"];
            ViewBag.msgError = TempData["msgError"];
            return PartialView("Create");
        }

        [CAuthorize()]
        public ActionResult ActionCreate(T_ABOUT about)
        {
            ResultStatus rs = new ResultStatus();

            if (ModelState.IsValid)
            {
                try
                {
                    about.created_by = CurrentUser.GetCurrentUserId();
                    about.created_dt = CurrentUser.GetCurrentDateTime();
                    db.T_ABOUT.Add(about);
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
            T_ABOUT about = db.T_ABOUT.Find(id);
            if (about == null)
            {
                return HttpNotFound();
            }
            return PartialView("Edit", about);
        }

        [CAuthorize()]
        public ActionResult ActionEdit(T_ABOUT about)
        {
            ResultStatus rs = new ResultStatus();

            if (ModelState.IsValid)
            {
                try
                {
                    about.last_modified_by = CurrentUser.GetCurrentUserId();
                    about.last_modified_dt = CurrentUser.GetCurrentDateTime();
                    db.Entry(about).State = EntityState.Modified;
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
            T_ABOUT about = db.T_ABOUT.Find(id);
            if (about == null)
            {
                return HttpNotFound();
            }
            return PartialView("Delete", about);
        }

        [CAuthorize()]
        public ActionResult ActionDelete(int id)
        {
            ResultStatus rs = new ResultStatus();

            try
            {
                T_ABOUT about = db.T_ABOUT.Find(id);
                db.T_ABOUT.Remove(about);
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
