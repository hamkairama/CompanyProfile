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
    public class ClientController : Controller
    {
        private startprojectEntities db = new startprojectEntities();

        [CAuthorize()]
        public ActionResult Index()
        {
            ViewBag.msgSuccess = TempData["msgSuccess"];
            ViewBag.msgError = TempData["msgError"];
            List<T_CLIENT> client = db.T_CLIENT.ToList();
            return PartialView(client);
        }

        [CAuthorize()]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_CLIENT client = db.T_CLIENT.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return PartialView("Details", client);
        }

        [CAuthorize()]
        public ActionResult Create()
        {
            ViewBag.msgSuccess = TempData["msgSuccess"];
            ViewBag.msgError = TempData["msgError"];
            return PartialView("Create");
        }

        [CAuthorize()]
        public ActionResult ActionCreate(T_CLIENT client)
        {
            ResultStatus rs = new ResultStatus();

            if (ModelState.IsValid)
            {
                try
                {
                    client.created_by = CurrentUser.GetCurrentUserId();
                    client.created_dt = CurrentUser.GetCurrentDateTime();
                    db.T_CLIENT.Add(client);
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
            T_CLIENT client = db.T_CLIENT.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return PartialView("Edit", client);
        }

        [CAuthorize()]
        public ActionResult ActionEdit(T_CLIENT client)
        {
            ResultStatus rs = new ResultStatus();

            if (ModelState.IsValid)
            {
                try
                {
                    client.last_modified_by = CurrentUser.GetCurrentUserId();
                    client.last_modified_dt = CurrentUser.GetCurrentDateTime();
                    db.Entry(client).State = EntityState.Modified;
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
            T_CLIENT client = db.T_CLIENT.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return PartialView("Delete", client);
        }

        [CAuthorize()]
        public ActionResult ActionDelete(int id)
        {
            ResultStatus rs = new ResultStatus();

            try
            {
                T_CLIENT client = db.T_CLIENT.Find(id);
                db.T_CLIENT.Remove(client);
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
