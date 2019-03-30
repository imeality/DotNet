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
    public class LiveDocsController : ApiController
    {
        private HealthPlusContext dbContext = new HealthPlusContext();

        // GET:
        [HttpGet]
        public IQueryable<LiveDoc> GetAllLiveDocs()
        {
            return dbContext.LiveDocs;
        }

        // GET:      
        public IHttpActionResult GetLiveDocById(int id)
        {
            LiveDoc liveDoc = dbContext.LiveDocs.Find(id);
            if (liveDoc == null)
            {
                return NotFound();
            }

            return Ok(liveDoc);
        }

        // PUT:
        public IHttpActionResult EditLiveDoc(int id, LiveDoc liveDoc)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != liveDoc.LiveDoc_Id)
            {
                return BadRequest();
            }

            dbContext.Entry(liveDoc).State = EntityState.Modified;

            try
            {
                dbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LiveDocExists(id))
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
        public IHttpActionResult AddLiveDoc(LiveDoc liveDoc)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            dbContext.LiveDocs.Add(liveDoc);
            dbContext.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = liveDoc.LiveDoc_Id }, liveDoc);
        }

        // DELETE:
        [HttpDelete]
        public IHttpActionResult DeleteLiveDoc(int id)
        {
            LiveDoc liveDoc = dbContext.LiveDocs.Find(id);
            if (liveDoc == null)
            {
                return NotFound();
            }

            dbContext.LiveDocs.Remove(liveDoc);
            dbContext.SaveChanges();

            return Ok(liveDoc);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dbContext.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LiveDocExists(int id)
        {
            return dbContext.LiveDocs.Count(e => e.LiveDoc_Id == id) > 0;
        }
    }
}