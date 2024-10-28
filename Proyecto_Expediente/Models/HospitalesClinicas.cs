using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_Expediente.Models
{
    public class HospitalesClinicas
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string UbicacionDepartamento { get; set; }
        public string UbicacionCiudad { get; set; }
        public bool EsPublico { get; set; }
    }
}