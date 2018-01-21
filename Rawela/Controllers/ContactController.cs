using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.Web.Script.Serialization;
using System.Configuration;
using System.Net.Configuration;
using System.Net;

namespace Rawela.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            return View("Contact");
        }

        [HttpPost]
        public ActionResult Contact(ViewModels.MailViewModel.SendMailViewModel viewModel)
        {
            if (ModelState.IsValid) {
                var smtpSection = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");
                string strHost = smtpSection.Network.Host;
                int port = smtpSection.Network.Port;
                string strUserName = smtpSection.Network.UserName;
                string strFromPass = smtpSection.Network.Password;
                SmtpClient smtp = new SmtpClient(strHost, port);
                NetworkCredential cert = new NetworkCredential(strUserName, strFromPass);
                smtp.Credentials = cert;
                smtp.EnableSsl = true;
                viewModel.To = "jesus-192@hotmail.com";// "carlos_hinojosc@hotmail.com";
                MailMessage msg = new MailMessage(smtpSection.From, viewModel.To);
                msg.Subject = viewModel.Subject;
                msg.IsBodyHtml = true;
                msg.Body ="Nombre: "+ viewModel.Name + " \r\nCorreo: " + viewModel.From+ "\r\nTeléfono: " + viewModel.Phone + "\r\nAsunto: " + viewModel.Subject+ "\r\nMensaje: " + viewModel.Body;
                //msg.Body += viewModel.Phone + " ";
                //msg.Body += viewModel.Body;
                smtp.Send(msg);
                //MailMessage mail = new MailMessage();
                //mail.To.Add(viewModel.To);
                //mail.From = new MailAddress(viewModel.From);
                //mail.Subject = viewModel.Subject;
                //string Body = viewModel.Body;
                //mail.Body = Body;
                //mail.IsBodyHtml = true;

                //SmtpClient smpt = new SmtpClient();
                //smpt.Host = "smtp.gmail.com";
                //smpt.Port = 587;
                //smpt.UseDefaultCredentials = false;
                //smpt.Credentials = new System.Net.NetworkCredential("vaz.jesus.92@gmail.com", "jesvaz-9");
                //smpt.EnableSsl = false;
                //smpt.Send(mail);
                return RedirectToAction("Index", "home");

                //var json = new JavaScriptSerializer().Serialize(viewModel);
                //return Content(json);
            }
            return RedirectToAction("Index", "home");

        }
    }
}