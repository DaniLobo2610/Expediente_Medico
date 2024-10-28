using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_Expediente.Models
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string NumeroSeguroSocial { get; set; }
    }
}