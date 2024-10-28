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
    public class EspecialidadMedicasController : ApiController
    {
        private DBContextProject db = new DBContextProject();

        // GET: api/EspecialidadMedicas
        public IQueryable<EspecialidadMedica> GetEspecialidadMedica()
        {
            return db.EspecialidadMedica;
        }

        // GET: api/EspecialidadMedicas/5
        [ResponseType(typeof(EspecialidadMedica))]
        public IHttpActionResult GetEspecialidadMedica(int id)
        {
            EspecialidadMedica especialidadMedica = db.EspecialidadMedica.Find(id);
            if (especialidadMedica == null)
            {
                return NotFound();
            }

            return Ok(especialidadMedica);
        }






        // PUT: api/EspecialidadMedicas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEspecialidadMedica(int id, EspecialidadMedica especialidadMedica)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != especialidadMedica.Id)
            {
                return BadRequest();
            }  

            db.Entry(especialidadMedica).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EspecialidadMedicaExists(id))
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

        // POST: api/EspecialidadMedicas
        [ResponseType(typeof(EspecialidadMedica))]
        public IHttpActionResult PostEspecialidadMedica(EspecialidadMedica especialidadMedica)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EspecialidadMedica.Add(especialidadMedica);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = especialidadMedica.Id }, especialidadMedica);
        }

        // DELETE: api/EspecialidadMedicas/5
        [ResponseType(typeof(EspecialidadMedica))]
        public IHttpActionResult DeleteEspecialidadMedica(int id)
        {
            EspecialidadMedica especialidadMedica = db.EspecialidadMedica.Find(id);
            if (especialidadMedica == null)
            {
                return NotFound();
            }

            db.EspecialidadMedica.Remove(especialidadMedica);
            db.SaveChanges();

            return Ok(especialidadMedica);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EspecialidadMedicaExists(int id)
        {
            return db.EspecialidadMedica.Count(e => e.Id == id) > 0;
        }
    }
}