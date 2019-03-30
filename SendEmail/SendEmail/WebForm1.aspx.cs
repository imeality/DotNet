using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;

namespace SendEmail
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(txtFrom.Text);
            msg.To.Add(txtTo.Text);
            msg.Subject = txtSubject.Text;
            msg.Body = txtBody.Text;
            msg.IsBodyHtml = true;


            if (FileUpload1.HasFile)
            {
                msg.Attachments.Add(new Attachment(FileUpload1.PostedFile.InputStream, FileUpload1.FileName));
            }

            SmtpClient smt = new SmtpClient();
            smt.Host = "smtp.gmail.com";
            System.Net.NetworkCredential ntwd = new NetworkCredential();
            ntwd.UserName = txtFrom.Text; //Your Email ID   
            ntwd.Password = txtPassword.Text; // Your Password   
            smt.UseDefaultCredentials = true;
            smt.Credentials = ntwd;
            smt.Port = 587;
            smt.EnableSsl = true;
            smt.Send(msg);
            lbmsg.Text = "Email Sent Successfully";
            lbmsg.ForeColor = System.Drawing.Color.ForestGreen;

        }
    }
}