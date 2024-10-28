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
    public class SintomasController : ApiController
    {
        private DBContextProject db = new DBContextProject();

        // GET: api/Sintomas
        public IQueryable<Sintoma> GetSintoma()
        {
            return db.Sintoma;
        }

        // GET: api/Sintomas/5
        [ResponseType(typeof(Sintoma))]
        public IHttpActionResult GetSintoma(int id)
        {
            Sintoma sintoma = db.Sintoma.Find(id);
            if (sintoma == null)
            {
                return NotFound();
            }

            return Ok(sintoma);
        }

       



        // PUT: api/Sintomas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSintoma(int id, Sintoma sintoma)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sintoma.Id)
            {
                return BadRequest();
            }

            db.Entry(sintoma).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SintomaExists(id))
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

        // POST: api/Sintomas
        [ResponseType(typeof(Sintoma))]
        public IHttpActionResult PostSintoma(Sintoma sintoma)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sintoma.Add(sintoma);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sintoma.Id }, sintoma);
        }

        // DELETE: api/Sintomas/5
        [ResponseType(typeof(Sintoma))]
        public IHttpActionResult DeleteSintoma(int id)
        {
            Sintoma sintoma = db.Sintoma.Find(id);
            if (sintoma == null)
            {
                return NotFound();
            }

            db.Sintoma.Remove(sintoma);
            db.SaveChanges();

            return Ok(sintoma);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SintomaExists(int id)
        {
            return db.Sintoma.Count(e => e.Id == id) > 0;
        }
    }
}