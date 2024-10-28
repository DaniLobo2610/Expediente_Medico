﻿using System;
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
    public class CitasController : ApiController
    {
        private DBContextProject db = new DBContextProject();

        // GET: api/Citas
        public IQueryable<Cita> GetCita()
        {
            return db.Cita;
        }

        // GET: api/Citas1/5
        [ResponseType(typeof(Cita))]
        public IHttpActionResult GetCita(int id)
        {
            Cita cita = db.Cita.Find(id);
            if (cita == null)
            {
                return NotFound();
            }

            return Ok(cita);
        }




        // PUT: api/Citas1/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCitas(int id, Cita cita)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cita.Id)
            {
                return BadRequest();
            }

            db.Entry(cita).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CitaExists(id))
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



        // POST: api/Citas
        [ResponseType(typeof(Cita))]
        public IHttpActionResult PostCita(Cita cita)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cita.Add(cita);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cita.Id }, cita);
        }

        // DELETE: api/Citas/5
        [ResponseType(typeof(Cita))]
        public IHttpActionResult DeleteCita(int id)
        {
            Cita cita = db.Cita.Find(id);
            if (cita == null)
            {
                return NotFound();
            }

            db.Cita.Remove(cita);
            db.SaveChanges();

            return Ok(cita);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CitaExists(int id)
        {
            return db.Cita.Count(e => e.Id == id) > 0;
        }
    }
}