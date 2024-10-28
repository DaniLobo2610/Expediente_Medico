using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_Expediente.Models
{
    public class Tratamiento
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Medicamentos { get; set; }
    }
}