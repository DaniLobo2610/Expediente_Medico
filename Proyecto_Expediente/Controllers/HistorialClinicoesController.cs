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
    public class HistorialClinicoesController : ApiController
    {
        private DBContextProject db = new DBContextProject();

        // GET: api/HistorialClinicoes
        public IQueryable<HistorialClinico> GetHistorialClinico()
        {
            return db.HistorialClinico;
        }

        // GET: api/HistorialClinicoes/5
        [ResponseType(typeof(HistorialClinico))]
        public IHttpActionResult GetHistorialClinico(int id)
        {
            HistorialClinico historialClinico = db.HistorialClinico.Find(id);
            if (historialClinico == null)
            {
                return NotFound();
            }

            return Ok(historialClinico);
        }

       



        // PUT: api/HistorialClinicoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHistorialClinico(int id, HistorialClinico historialClinico)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != historialClinico.Id)
            {
                return BadRequest();
            }

            db.Entry(historialClinico).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistorialClinicoExists(id))
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

        // POST: api/HistorialClinicoes
        [ResponseType(typeof(HistorialClinico))]
        public IHttpActionResult PostHistorialClinico(HistorialClinico historialClinico)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HistorialClinico.Add(historialClinico);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = historialClinico.Id }, historialClinico);
        }

        // DELETE: api/HistorialClinicoes/5
        [ResponseType(typeof(HistorialClinico))]
        public IHttpActionResult DeleteHistorialClinico(int id)
        {
            HistorialClinico historialClinico = db.HistorialClinico.Find(id);
            if (historialClinico == null)
            {
                return NotFound();
            }

            db.HistorialClinico.Remove(historialClinico);
            db.SaveChanges();

            return Ok(historialClinico);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HistorialClinicoExists(int id)
        {
            return db.HistorialClinico.Count(e => e.Id == id) > 0;
        }
    }
}