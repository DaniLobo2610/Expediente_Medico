using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_Expediente.Models
{
    public class SeguroMedico
    {
        public int Id { get; set; }
        public int IdPaciente { get; set; }
        public string NombrePaciente { get; set; }
        public string ApellidoPaciente { get; set; }
        public string Cobertura { get; set; }
        public string Telefono { get; set; }
    }
}