using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VehiculosAspNetC.DAL.Entities
{
    public class Sanciones
    {
        public int Id { get; set; }
        public DateTime FechaActual { get; set; }

        public String? Sancion { get; set; }
        public String? Observacion { get; set; }

        public Decimal Valor { get; set; }

        public String ConductorId { get; set; }
        [ForeignKey("ConductorId")]

        public virtual Conductor Conductor { get; set; }

    }
}
