using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace AvisFormations.WebUi.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EnvoyerMail(string nom,string email,string message)
        {
            try
            {
                string mymail = "rabia.elgouail@gmail.com";
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress(email);
                msg.To.Add(new MailAddress(mymail));
                msg.Subject = "Contact-Avis Formation";
                msg.Body = message + "\n Send By " + nom;
                var client = new SmtpClient()
                {
                    Host = "Webmail.avisFormation.com",
                    Port = 587,
                    EnableSsl = false,
                    UseDefaultCredentials = false,
                    Timeout = 30 * 1000,
                    Credentials = new NetworkCredential("Admin@AvisFormation.com", "AdminPassword")
                };
                client.Send(msg);
                return View("Merci");
            }
            catch
            {
                return View("EchecEnvoi");
            }



           
        }
    }
    
}