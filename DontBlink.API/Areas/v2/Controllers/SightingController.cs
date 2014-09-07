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
using DontBlink.API.Models;

namespace DontBlink.API.Areas.v2.Controllers
{
    public class SightingController : ApiController
    {
        private DontBlinkAPIContext db = new DontBlinkAPIContext();

        // GET: api/Sighting
        public IQueryable<SightingModel> GetSightingModels()
        {
            return db.SightingModels;
        }

        // GET: api/Sighting/5
        [ResponseType(typeof(SightingModel))]
        public IHttpActionResult GetSightingModel(Guid id)
        {
            SightingModel sightingModel = db.SightingModels.Find(id);
            if (sightingModel == null)
            {
                return NotFound();
            }

            return Ok(sightingModel);
        }

        // PUT: api/Sighting/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSightingModel(Guid id, SightingModel sightingModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sightingModel.Id)
            {
                return BadRequest();
            }

            db.Entry(sightingModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SightingModelExists(id))
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

        // POST: api/Sighting
        [ResponseType(typeof(SightingModel))]
        public IHttpActionResult PostSightingModel(SightingModel sightingModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            db.SightingModels.Add(sightingModel);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (SightingModelExists(sightingModel.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = sightingModel.Id }, sightingModel);
        }

        // DELETE: api/Sighting/5
        [ResponseType(typeof(SightingModel))]
        public IHttpActionResult DeleteSightingModel(Guid id)
        {
            SightingModel sightingModel = db.SightingModels.Find(id);
            if (sightingModel == null)
            {
                return NotFound();
            }

            db.SightingModels.Remove(sightingModel);
            db.SaveChanges();

            return Ok(sightingModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SightingModelExists(Guid id)
        {
            return db.SightingModels.Count(e => e.Id == id) > 0;
        }
    }
}