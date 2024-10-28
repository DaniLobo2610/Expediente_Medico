using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_Expediente.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Especialidad { get; set; }
    }
}