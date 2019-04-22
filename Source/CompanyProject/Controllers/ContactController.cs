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
using System.Net.Mail;
using CompanyProjectModel.CustomObject;

namespace MVCProject.Controllers
{
    public class ContactController : Controller
    {
        private startprojectEntities db = new startprojectEntities();

        public ActionResult SendEmail(CustomMail customMail, string attachment)
        {
            ResultStatus rs = new ResultStatus();
            MailMessage mail = new MailMessage();
            try
            {
                Email email = new Email();
                mail = email.MappingEmail(customMail);                
                rs = email.SendEmail(mail, attachment);
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
