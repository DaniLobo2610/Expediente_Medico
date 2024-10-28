using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_Expediente.Models
{
    public class HistorialClinico
    {
        public int Id { get; set; }
        public int PacienteId { get; set; }
        public string NombrePaciente { get; set; }
        public string ApellidoPaciente { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaNacimi { get; set; }
        public string Descripcion { get; set; }
    }
}