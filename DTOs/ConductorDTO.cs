using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehiculosAspNetC.DTOs
{
    public class ConductorDTO
    {
        //public int Id { get; set; }
        public String Identificacion { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public String? Direccion { get; set; }
        public String? Telefono { get; set; }
        public String? Email { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public bool? Estado { get; set; }
        public String MatriculaId { get; set; }
        public DateTime FechaExpedicion { get; set; }
        public DateTime FechaVencimiento { get; set; }
    }
}
