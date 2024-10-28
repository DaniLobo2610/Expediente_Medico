using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_Expediente.Models
{
    public class Medicamento
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Dosis { get; set; }
    }
}