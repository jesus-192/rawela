using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.Web.Script.Serialization;

namespace Rawela.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(ViewModels.MailViewModel.SendMailViewModel viewModel)
        {
            if (ModelState.IsValid){
                MailMessage mail = new MailMessage();
                mail.To.Add(viewModel.To);
                mail.From = new MailAddress(viewModel.From);
                mail.Subject = viewModel.Subject;
                string Body = viewModel.Body;
                mail.Body = Body;
                mail.IsBodyHtml = true;

                SmtpClient smpt = new SmtpClient();
                smpt.Host = "smtp.gmail.com";
                smpt.Port = 587;
                smpt.UseDefaultCredentials = false;
                smpt.Credentials = new System.Net.NetworkCredential("vaz.jesus.92@gmail.com", "jesvaz-9");
                smpt.EnableSsl = false;
                smpt.Send(mail);
                return RedirectToAction("Index", "home");

                //var json = new JavaScriptSerializer().Serialize(viewModel);
                //return Content(json);
            }
            return RedirectToAction("Index", "home");

        }
    }
}