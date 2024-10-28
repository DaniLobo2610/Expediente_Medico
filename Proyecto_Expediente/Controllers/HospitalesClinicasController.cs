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
using Proyecto_Expediente.Models;

namespace Proyecto_Expediente.Controllers
{
    public class HospitalesClinicasController : ApiController
    {
        private DBContextProject db = new DBContextProject();

        // GET: api/HospitalesClinicas
        public IQueryable<HospitalesClinicas> GetHospitalesClinicas()
        {
            return db.HospitalesClinicas;
        }

        // GET: api/HospitalesClinicas/5
        [ResponseType(typeof(HospitalesClinicas))]
        public IHttpActionResult GetHospitalesClinicas(int id)
        {
            HospitalesClinicas hospitalesClinicas = db.HospitalesClinicas.Find(id);
            if (hospitalesClinicas == null)
            {
                return NotFound();
            }

            return Ok(hospitalesClinicas);
        }

        // PUT: api/HospitalesClinicas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHospitalesClinicas(int id, HospitalesClinicas hospitalesClinicas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hospitalesClinicas.Id)
            {
                return BadRequest();
            }

            db.Entry(hospitalesClinicas).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalesClinicasExists(id))
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

        // POST: api/HospitalesClinicas
        [ResponseType(typeof(HospitalesClinicas))]
        public IHttpActionResult PostHospitalesClinicas(HospitalesClinicas hospitalesClinicas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HospitalesClinicas.Add(hospitalesClinicas);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = hospitalesClinicas.Id }, hospitalesClinicas);
        }



        // DELETE: api/HospitalesClinicas/5
        [ResponseType(typeof(HospitalesClinicas))]
        public IHttpActionResult DeleteHospitalesClinicas(int id)
        {
            HospitalesClinicas hospitalesClinicas = db.HospitalesClinicas.Find(id);
            if (hospitalesClinicas == null)
            {
                return NotFound();
            }

            db.HospitalesClinicas.Remove(hospitalesClinicas);
            db.SaveChanges();

            return Ok(hospitalesClinicas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HospitalesClinicasExists(int id)
        {
            return db.HospitalesClinicas.Count(e => e.Id == id) > 0;
        }
    }
}