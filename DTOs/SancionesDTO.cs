using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehiculosAspNetC.DTOs
{
    public class SancionesDTO
    {
        public int Id { get; set; }
        public DateTime FechaActual { get; set; }

        public String? Sancion { get; set; }
        public String? Observacion { get; set; }

        public Decimal Valor { get; set; }

        public String ConductorId { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }
    }
}
