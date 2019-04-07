using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CodeFirstApi.Models;

namespace CodeFirstApi.Controllers
{
    public class UsersController : ApiController
    {
        private HealthPlusContext dbContext = new HealthPlusContext();

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