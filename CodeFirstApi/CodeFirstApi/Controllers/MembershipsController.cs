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
    public class MembershipsController : ApiController
    {
        private HealthPlusContext dbContext = new HealthPlusContext();

        // GET:
        [HttpGet]      
        public IQueryable<Membership> GetAllMemberships()
        {
            return dbContext.Memberships;
        }
        // GET: 
        [HttpGet]    
        public IHttpActionResult GetMembershipById(int id)
        {
            Membership membership = dbContext.Memberships.Find(id);
            if (membership == null)
            {
                return NotFound();
            }

            return Ok(membership);
        }

        // PUT: 
        [HttpPut]        
        public IHttpActionResult EditMembership(int id, Membership membership)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != membership.MembershipType_Id)
            {
                return BadRequest();
            }

            dbContext.Entry(membership).State = EntityState.Modified;

            try
            {
                dbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MembershipExists(id))
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
        public IHttpActionResult AddMembership(Membership membership)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            dbContext.Memberships.Add(membership);
            dbContext.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = membership.MembershipType_Id }, membership);
        }

        // DELETE:
        [HttpDelete]
        public IHttpActionResult DeleteMembership(int id)
        {
            Membership membership = dbContext.Memberships.Find(id);
            if (membership == null)
            {
                return NotFound();
            }

            dbContext.Memberships.Remove(membership);
            dbContext.SaveChanges();

            return Ok(membership);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dbContext.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MembershipExists(int id)
        {
            return dbContext.Memberships.Count(e => e.MembershipType_Id == id) > 0;
        }
    }
}