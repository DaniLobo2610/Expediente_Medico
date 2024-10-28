using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_Expediente.Models
{
    public class Cita
    {
        public int Id { get; set; }
        public int PacienteId { get; set; }
        public string NombrePaciente { get; set; }
        public string ApellidoPaciente { get; set; }
        public int DoctorId { get; set; }
        public string NombreDoctor { get; set; }
        public string Especialidad { get; set; }
        public DateTime FechaHora { get; set; }
        public string Motivo { get; set; }

        
    }

  
}