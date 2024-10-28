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
using Swashbuckle.Swagger.Annotations;

namespace Proyecto_Expediente.Controllers
{
    public class EnfermedadsController : ApiController
    {
        private DBContextProject db = new DBContextProject();

        // GET: api/Enfermedads
        public IQueryable<Enfermedad> GetEnfermedad()
        {
            return db.Enfermedad;
        }

        // GET: api/Enfermedads/5
        [ResponseType(typeof(Enfermedad))]
        public IHttpActionResult GetEnfermedad(int id)
        {
            Enfermedad enfermedad = db.Enfermedad.Find(id);
            if (enfermedad == null)
            {
                return NotFound();
            }

            return Ok(enfermedad);
        }


        // PUT: api/Enfermedads/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEnfermedad(int id, Enfermedad enfermedad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           if (id != enfermedad.Id)
            {
                return BadRequest();
            }

            db.Entry(enfermedad).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnfermedadExists(id))
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

        // POST: api/Enfermedads
        [ResponseType(typeof(Enfermedad))]
        public IHttpActionResult PostEnfermedad(Enfermedad enfermedad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Enfermedad.Add(enfermedad);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = enfermedad.Id }, enfermedad);
        }

        // DELETE: api/Enfermedads/5
        [ResponseType(typeof(Enfermedad))]
        public IHttpActionResult DeleteEnfermedad(int id)
        {
            Enfermedad enfermedad = db.Enfermedad.Find(id);
            if (enfermedad == null)
            {
                return NotFound();
            }

            db.Enfermedad.Remove(enfermedad);
            db.SaveChanges();

            return Ok(enfermedad);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EnfermedadExists(int id)
        {
            return db.Enfermedad.Count(e => e.Id == id) > 0;
        }
    }
}