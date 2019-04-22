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
    public class ServiceController : Controller
    {
        private startprojectEntities db = new startprojectEntities();

        [CAuthorize()]
        public ActionResult Index()
        {
            ViewBag.msgSuccess = TempData["msgSuccess"];
            ViewBag.msgError = TempData["msgError"];
            List<T_SERVICE> service = db.T_SERVICE.ToList();
            return PartialView(service);
        }

        [CAuthorize()]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_SERVICE service = db.T_SERVICE.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return PartialView("Details", service);
        }

        [CAuthorize()]
        public ActionResult Create()
        {
            ViewBag.msgSuccess = TempData["msgSuccess"];
            ViewBag.msgError = TempData["msgError"];
            return PartialView("Create");
        }

        [CAuthorize()]
        public ActionResult ActionCreate(T_SERVICE service)
        {
            ResultStatus rs = new ResultStatus();

            if (ModelState.IsValid)
            {
                try
                {
                    service.created_by = CurrentUser.GetCurrentUserId();
                    service.created_dt = CurrentUser.GetCurrentDateTime();
                    db.T_SERVICE.Add(service);
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
            T_SERVICE service = db.T_SERVICE.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return PartialView("Edit", service);
        }

        [CAuthorize()]
        public ActionResult ActionEdit(T_SERVICE service)
        {
            ResultStatus rs = new ResultStatus();

            if (ModelState.IsValid)
            {
                try
                {
                    service.last_modified_by = CurrentUser.GetCurrentUserId();
                    service.last_modified_dt = CurrentUser.GetCurrentDateTime();
                    db.Entry(service).State = EntityState.Modified;
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
            T_SERVICE service = db.T_SERVICE.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return PartialView("Delete", service);
        }

        [CAuthorize()]
        public ActionResult ActionDelete(int id)
        {
            ResultStatus rs = new ResultStatus();

            try
            {
                T_SERVICE service = db.T_SERVICE.Find(id);
                db.T_SERVICE.Remove(service);
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
