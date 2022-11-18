using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehiculosAspNetC.DAL.DbContext
{
    using Microsoft.EntityFrameworkCore;
    using VehiculosAspNetC.DAL.Entities;

    public class VehiculosDbContext : DbContext
    {
        //Construction
        public VehiculosDbContext(DbContextOptions<VehiculosDbContext> options):
            base(options)
        {

        }

        //Inyección de dependencia por tipo (Clases virtuales)
        public virtual DbSet<Matriculas> Matriculas { get; set; }
        public virtual DbSet<Conductor> Conductor { get; set; }
        public virtual DbSet<Sanciones> Sanciones { get; set; }
    }
}
