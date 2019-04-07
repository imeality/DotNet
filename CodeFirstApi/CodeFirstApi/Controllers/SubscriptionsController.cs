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
    public class SubscriptionsController : ApiController
    {
        private HealthPlusContext db = new HealthPlusContext();

        // GET: 
        [HttpGet]
        public IQueryable<Subscription> GetAllSubscriptions()
        {
            return db.Subscriptions;
        }

        // GET: 
        [HttpGet]
        public IHttpActionResult GetSubscriptionById(int id)
        {
            Subscription subscription = db.Subscriptions.Find(id);
            if (subscription == null)
            {
                return NotFound();
            }

            return Ok(subscription);
        }

        // PUT:   
        [HttpPut]
        public IHttpActionResult EditSubscription(int id, Subscription subscription)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != subscription.Subscription_Id)
            {
                return BadRequest();
            }

            db.Entry(subscription).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubscriptionExists(id))
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
        public IHttpActionResult AddSubscription(Subscription subscription)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Subscriptions.Add(subscription);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = subscription.Subscription_Id }, subscription);
        }

        // DELETE: 
       [HttpDelete]
        public IHttpActionResult DeleteSubscription(int id)
        {
            Subscription subscription = db.Subscriptions.Find(id);
            if (subscription == null)
            {
                return NotFound();
            }

            db.Subscriptions.Remove(subscription);
            db.SaveChanges();

            return Ok(subscription);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SubscriptionExists(int id)
        {
            return db.Subscriptions.Count(e => e.Subscription_Id == id) > 0;
        }
    }
}