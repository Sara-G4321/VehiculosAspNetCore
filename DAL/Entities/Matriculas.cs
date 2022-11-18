using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VehiculosAspNetC.DAL.Entities
{
    public class Matriculas
    {
        [Key]
        //public int Id { get; set; }
        public String Numero { get; set; }
        public DateTime FechaExpedicion { get; set; }
        public DateTime FechaVencimiento { get; set; }

        public bool? Estado { get; set; }

        public virtual ICollection<Conductor> Conductor { get; set; }

    }
}
