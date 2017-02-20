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
using GeneDemoApp.Models;

namespace GeneDemoApp.Controllers
{
    public class Samples1Controller : ApiController
    {
        private GeneModel db = new GeneModel();

        // GET: api/Samples1
        public IQueryable<Sample> GetSamples()
        {
            return db.Samples;
        }

        // GET: api/Samples1/5
        [ResponseType(typeof(Sample))]
        public IHttpActionResult GetSample(int id)
        {
            Sample sample = db.Samples.Find(id);
            if (sample == null)
            {
                return NotFound();
            }

            return Ok(sample);
        }

        // PUT: api/Samples1/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSample(int id, Sample sample)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sample.SampleId)
            {
                return BadRequest();
            }

            db.Entry(sample).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SampleExists(id))
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

        // POST: api/Samples1
        [ResponseType(typeof(Sample))]
        public IHttpActionResult PostSample(Sample sample)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Samples.Add(sample);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (SampleExists(sample.SampleId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = sample.SampleId }, sample);
        }

        // DELETE: api/Samples1/5
        [ResponseType(typeof(Sample))]
        public IHttpActionResult DeleteSample(int id)
        {
            Sample sample = db.Samples.Find(id);
            if (sample == null)
            {
                return NotFound();
            }

            db.Samples.Remove(sample);
            db.SaveChanges();

            return Ok(sample);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SampleExists(int id)
        {
            return db.Samples.Count(e => e.SampleId == id) > 0;
        }
    }
}