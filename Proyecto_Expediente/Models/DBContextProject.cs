using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Proyecto_Expediente.Models
{
    public class DBContextProject : DbContext
    {
      

        public DBContextProject() : base("MyDbConnectionString")
        {
        }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Consulta> Consulta { get; set; }
        public DbSet<Cita> Cita { get; set; }

         public DbSet<Doctor> Doctor { get; set; }
         public DbSet<Enfermedad> Enfermedad { get; set; }
         public DbSet<EspecialidadMedica> EspecialidadMedica { get; set; }
        
         public DbSet<HistorialClinico> HistorialClinico { get; set; }

         public DbSet<HospitalesClinicas> HospitalesClinicas { get; set; }
         public DbSet<Medicamento> Medicamento { get; set; }
         public DbSet<Proveedor> Proveedor { get; set; }
         public DbSet<SeguroMedico> SeguroSocial { get; set; }
         public DbSet<Sintoma> Sintoma { get; set; }
         public DbSet<Tratamiento> Tratamiento { get; set; }
         public DbSet<Usuario> Usuario { get; set; }

        
    }
}