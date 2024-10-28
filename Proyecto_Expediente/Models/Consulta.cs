using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_Expediente.Models
{
    public class Consulta
    {
        public int Id { get; set; }
        public int CitaId { get; set; }
        public string Motivo { get; set; }
        public string NombrePaciente { get; set; }
        public string ApellidoPaciente { get; set; }
        public int DoctorId { get; set; }
        public string NombreDoctor { get; set; }
        public string EspecialidadDoctor { get; set; }
        public DateTime FechaHora { get; set; }
        public int IdSintoma { get; set; }
        public string DescripcionSintoma { get; set; }
        public string Enfermedades { get; set; }
        public string Observaciones { get; set; }

        public int IdtTratamiento { get; set; }
        public string DescripcionTrata { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Medicamentos { get; set; }
    }
}