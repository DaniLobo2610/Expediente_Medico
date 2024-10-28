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
using Swashbuckle.Swagger.Annotations;

namespace Proyecto_Expediente.Controllers
{
    public class MedicamentoesController : ApiController
    {
        private DBContextProject db = new DBContextProject();

        // GET: api/Medicamentoes
        public IQueryable<Medicamento> GetMedicamento()
        {
            return db.Medicamento;
        }

        // GET: api/Medicamentoes/5
        [ResponseType(typeof(Medicamento))]
        public IHttpActionResult GetMedicamento(int id)
        {
            Medicamento medicamento = db.Medicamento.Find(id);
            if (medicamento == null)
            {
                return NotFound();
            }

            return Ok(medicamento);
        }


       


        // PUT: api/Medicamentoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMedicamento(int id, Medicamento medicamento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != medicamento.Id)
            {
                return BadRequest();
            }

            db.Entry(medicamento).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicamentoExists(id))
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

        // POST: api/Medicamentoes
        [ResponseType(typeof(Medicamento))]
        public IHttpActionResult PostMedicamento(Medicamento medicamento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Medicamento.Add(medicamento);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = medicamento.Id }, medicamento);
        }

        // DELETE: api/Medicamentoes/5
        [ResponseType(typeof(Medicamento))]
        public IHttpActionResult DeleteMedicamento(int id)
        {
            Medicamento medicamento = db.Medicamento.Find(id);
            if (medicamento == null)
            {
                return NotFound();
            }

            db.Medicamento.Remove(medicamento);
            db.SaveChanges();

            return Ok(medicamento);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MedicamentoExists(int id)
        {
            return db.Medicamento.Count(e => e.Id == id) > 0;
        }
    }
}