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
    public class TeamController : Controller
    {
        private startprojectEntities db = new startprojectEntities();

        [CAuthorize()]
        public ActionResult Index()
        {
            ViewBag.msgSuccess = TempData["msgSuccess"];
            ViewBag.msgError = TempData["msgError"];
            List<T_TEAM> team = db.T_TEAM.ToList();
            return PartialView(team);
        }

        [CAuthorize()]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_TEAM team = db.T_TEAM.Find(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return PartialView("Details", team);
        }

        [CAuthorize()]
        public ActionResult Create()
        {
            ViewBag.msgSuccess = TempData["msgSuccess"];
            ViewBag.msgError = TempData["msgError"]; 

            return PartialView("Create");
        }

        [CAuthorize()]
        public ActionResult ActionCreate(T_TEAM team)
        {
            ResultStatus rs = new ResultStatus();

            if (ModelState.IsValid)
            {
                try
                {
                    team.created_by = CurrentUser.GetCurrentUserId();
                    team.created_dt = CurrentUser.GetCurrentDateTime();
                    db.T_TEAM.Add(team);
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
            T_TEAM team = db.T_TEAM.Find(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return PartialView("Edit", team);
        }

        [CAuthorize()]
        public ActionResult ActionEdit(T_TEAM team)
        {
            ResultStatus rs = new ResultStatus();

            if (ModelState.IsValid)
            {
                try
                {
                    team.last_modified_by = CurrentUser.GetCurrentUserId();
                    team.last_modified_dt = CurrentUser.GetCurrentDateTime();
                    db.Entry(team).State = EntityState.Modified;
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
            T_TEAM team = db.T_TEAM.Find(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return PartialView("Delete", team);
        }

        [CAuthorize()]
        public ActionResult ActionDelete(int id)
        {
            ResultStatus rs = new ResultStatus();
            
            try
            {
                T_TEAM team = db.T_TEAM.Find(id);
                db.T_TEAM.Remove(team);
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
