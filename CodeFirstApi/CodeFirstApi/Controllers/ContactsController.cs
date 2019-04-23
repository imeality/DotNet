using CodeFirstApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;

namespace CodeFirstApi.Controllers
{
    public class ContactsController : ApiController
    {

        //Contact
        [HttpPost]
        public IHttpActionResult GetContact(Contact contact)
        {

            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(contact.From_Contact);
            msg.To.Add("cvaniporwal@gmail.com");
            msg.Subject = "Prescription";
            msg.Body = contact.Message.ToString();
            msg.IsBodyHtml = true;
            SmtpClient smt = new SmtpClient();
            smt.Host = "smtp.gmail.com";
            System.Net.NetworkCredential ntwd = new NetworkCredential();
            ntwd.UserName = "cvaniporwal@gmail.com";
            ntwd.Password = "25july1997";
            smt.UseDefaultCredentials = true;
            smt.Credentials = ntwd;
            smt.Port = 587;

            smt.EnableSsl = true;
            smt.Send(msg);
            return Ok("Email Successfull");

        }
    }
}
