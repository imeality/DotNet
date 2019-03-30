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
    public class PrescriptionsController : ApiController
    {
        private HealthPlusContext dbContext = new HealthPlusContext();

        // GET: 
        [HttpGet]
        public IQueryable<Prescription> GetAllPrescriptions()
        {
            dbContext = new HealthPlusContext();
            return dbContext.Prescriptions;
        }

        // GET: 
        [HttpGet]  
        public IHttpActionResult GetPrescriptionById(int id)
        {
            dbContext = new HealthPlusContext();
            Prescription prescription = dbContext.Prescriptions.Find(id);
            if (prescription == null)
            {
                return NotFound();
            }

            return Ok(prescription);
        }

        // PUT: 
        [HttpPut]
        public IHttpActionResult EditPrescription(int id, Prescription prescription)
        {
            dbContext = new HealthPlusContext();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != prescription.Prescription_Id)
            {
                return BadRequest();
            }

            dbContext.Entry(prescription).State = EntityState.Modified;

            try
            {
                dbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrescriptionExists(id))
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
        public IHttpActionResult AddPrescription(Prescription prescription)
        {
            dbContext = new HealthPlusContext();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            dbContext.Prescriptions.Add(prescription);
            dbContext.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = prescription.Prescription_Id }, prescription);
        }

        // DELETE: 
        [HttpDelete]      
        public IHttpActionResult DeletePrescription(int id)
        {
            dbContext = new HealthPlusContext();
            Prescription prescription = dbContext.Prescriptions.Find(id);
            if (prescription == null)
            {
                return NotFound();
            }

            dbContext.Prescriptions.Remove(prescription);
            dbContext.SaveChanges();

            return Ok(prescription);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dbContext.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PrescriptionExists(int id)
        {
            return dbContext.Prescriptions.Count(e => e.Prescription_Id == id) > 0;
        }
    }
}