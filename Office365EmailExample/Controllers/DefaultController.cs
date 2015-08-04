using Office365EmailExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Office365EmailExample.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        [ActionName("Index")]
        [HttpGet]
        public ActionResult IndexGet()
        {
            return View();
        }

        [ActionName("Index")]
        [HttpPost]
        public ActionResult IndexPost(EmailMessage model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Success = SendMail(model);
                return View(model);
            }
            else return View(model);
        }

        private bool SendMail(EmailMessage model)
        {
            var result = false;

            using (MailMessage msg = new MailMessage())
            {
                // Configure the message.
                msg.To.Add(new MailAddress(model.RecipientAddress, "Recipient"));
                msg.From = new MailAddress(model.CredentialsUsername, model.CredentialsFullName); // Must EXACTLY match the account you're sending from! Easy way to find this is send an email to an external address and see the displayed name.
                msg.Subject = model.Subject;
                msg.Body = model.Body;
                msg.IsBodyHtml = false; // Modify as necessary, unimportant to getting email working.

                // Attempt to send.
                using (SmtpClient client = new SmtpClient())
                {
                    client.UseDefaultCredentials = false;
                    client.Credentials = new System.Net.NetworkCredential(model.CredentialsUsername, model.CredentialsPassword);
                    client.Port = 587; // You can use Port 25 if 587 is blocked, but SSL may not work, and that's baaaad, m'kay?
                    client.Host = "smtp.office365.com";
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.EnableSsl = true;
                    try
                    {
                        client.Send(msg);
                        result = true;
                    }
                    catch (Exception ex)
                    {
                        ViewBag.ErrorMessage = ex.Message;
                        result = false;
                    }
                }
            }

            return result;
        }
    }
}