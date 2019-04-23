using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using CodeFirstApi.Models;

namespace CodeFirstApi.Controllers
{
    public class UsersController : ApiController
    {
        private HealthPlusContext dbContext = new HealthPlusContext();
        private object scope;

        // GET: 
        [HttpGet]     
        public IQueryable<User> GetAllUsers()
        {
            return dbContext.Users;
        }

        // GET: 
        [HttpGet]        
        public IHttpActionResult GetUserById(int id)
        {
           

        User user = dbContext.Users.Find(id);
          if (user == null)
          {
              return NotFound();
          }

          return Ok(user);
         
    }

    // PUT: 
    [HttpPut]         
        public IHttpActionResult EditUser(int id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.User_Id)
            {
                return BadRequest();
            }

            dbContext.Entry(user).State = EntityState.Modified;

            try
            {
                dbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }
        // POST: 
        [HttpPost]      
        public IHttpActionResult AddUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            dbContext.Users.Add(user);
            dbContext.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = user.User_Id }, user);
        }
        // DELETE: 
        [HttpDelete]        
        public IHttpActionResult DeleteUser(int id)
        {
            User user = dbContext.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            dbContext.Users.Remove(user);
            dbContext.SaveChanges();
            return Ok(user);
        }
        //Email Notification After Registration
        [HttpPost]
        public IHttpActionResult SendMail(User user)
        {
            var uname = "cvaniporwal@gmail.com";
            var pwd = "25july1997";
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("cvaniporwal@gmail.com");
            msg.To.Add(user.Email);
            msg.Subject = "HealthPlus Registration";
            msg.Body = "Congratulations you are successfully registered in HealthPlus.Please login in our site and take our services.";
            msg.IsBodyHtml = true;
            SmtpClient smt = new SmtpClient();
            smt.Host = "smtp.gmail.com";
            System.Net.NetworkCredential ntwd = new NetworkCredential();
            ntwd.UserName = uname; //Your Email ID   
            ntwd.Password = pwd; // Your Password   
            smt.UseDefaultCredentials = true;
            smt.Credentials = ntwd;
            smt.Port = 587;
            smt.EnableSsl = true;
            smt.Send(msg);
            return Ok("Email Successfull");
          
        }
        //AfterLogin
        [HttpGet]
        public IHttpActionResult GetUserDashBoard()
        {
           var identity = (ClaimsIdentity)User.Identity;
          var roles = identity.Claims
                        .Where(c => c.Type == ClaimTypes.Role)
                        .Select(c => c.Value);

            var email = identity.Claims
                       .Where(c => c.Type == ClaimTypes.Email)
                       .Select(c => c.Value);
            var data = new ArrayList();
            data.Add(identity.Name);
            data.Add(roles);
            data.Add(email);


            return Ok(data);
            //  return Ok("Name: " + identity.Name + "&Mid:" + string.Join(",", roles.ToList()) + "&Email:" + string.Join(",", email.ToList()));


        }
        //GetByName
      [Route("api/Users/GetUserByName/{name}")]
        public IQueryable<User> GetUserByName(string name)
        {
            return dbContext.Users
                .Where(b => b.FirstName.Equals(name, StringComparison.OrdinalIgnoreCase));
              
        }
        
        //GetByEmail
        [Route("api/Users/GetUserByEmail/{email}")]
        public IQueryable<User> GetUserByEmail(string email)
        {
            return dbContext.Users
                .Where(b => b.Email.Equals(email, StringComparison.CurrentCulture));

        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dbContext.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(int id)
        {
            return dbContext.Users.Count(e => e.User_Id == id) > 0;
        }
    }
}
/*
    [HttpGet]
        public IHttpActionResult GetUserDashBoard()
        {
            var identity = User.Identity;
            string url = "http://localhost:53803/UserDashBoard.html";


            System.Uri uri = new System.Uri(url);

            return Redirect(uri);
        }
 */
 
