using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VehiculosAspNetC.DAL.Entities
{
    public class Conductor
    {
        [Key]
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
        [ForeignKey("MatriculaId")]

        public virtual Matriculas Matriculas { get; set; }
    }
}
