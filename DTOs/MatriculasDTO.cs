using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehiculosAspNetC.DTOs
{
    public class MatriculasDTO
    {
        //public int Id { get; set; }
        public String Numero { get; set; }
        public DateTime FechaExpedicion { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public bool? Estado { get; set; }
    }
}
