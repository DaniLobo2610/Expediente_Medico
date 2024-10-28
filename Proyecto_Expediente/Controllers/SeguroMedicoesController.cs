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
    public class SeguroMedicoesController : ApiController
    {
        private DBContextProject db = new DBContextProject();

        // GET: api/SeguroMedicoes
        public IQueryable<SeguroMedico> GetSeguroSocial()
        {
            return db.SeguroSocial;
        }

        // GET: api/SeguroMedicoes/5
        [ResponseType(typeof(SeguroMedico))]
        public IHttpActionResult GetSeguroMedico(int id)
        {
            SeguroMedico seguroMedico = db.SeguroSocial.Find(id);
            if (seguroMedico == null)
            {
                return NotFound();
            }

            return Ok(seguroMedico);
        }


       


        // PUT: api/SeguroMedicoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSeguroMedico(int id, SeguroMedico seguroMedico)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != seguroMedico.Id)
            {
                return BadRequest();
            }

            db.Entry(seguroMedico).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeguroMedicoExists(id))
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

        // POST: api/SeguroMedicoes
        [ResponseType(typeof(SeguroMedico))]
        public IHttpActionResult PostSeguroMedico(SeguroMedico seguroMedico)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SeguroSocial.Add(seguroMedico);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = seguroMedico.Id }, seguroMedico);
        }

        // DELETE: api/SeguroMedicoes/5
        [ResponseType(typeof(SeguroMedico))]
        public IHttpActionResult DeleteSeguroMedico(int id)
        {
            SeguroMedico seguroMedico = db.SeguroSocial.Find(id);
            if (seguroMedico == null)
            {
                return NotFound();
            }

            db.SeguroSocial.Remove(seguroMedico);
            db.SaveChanges();

            return Ok(seguroMedico);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SeguroMedicoExists(int id)
        {
            return db.SeguroSocial.Count(e => e.Id == id) > 0;
        }
    }
}