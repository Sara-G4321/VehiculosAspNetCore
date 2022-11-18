using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using VehiculosAspNetC.DAL.DbContext;
using VehiculosAspNetC.DAL.Entities;
using VehiculosAspNetC.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VehiculosAspNetC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConductorController : ControllerBase
    {
        #region propiedades
        private readonly VehiculosDbContext _context;
        #endregion propiedades

        #region constructor
        public ConductorController(VehiculosDbContext context)
        {
            _context = context;
        }
        #endregion constructor

        #region metodos

        #region metodoGet
        // GET: api/<ConductorController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConductorDTO>>> Get()
        {
            try
            {
                var conductor = await _context.Conductor.Select(x =>
                new ConductorDTO
                {
                    //Id = x.Id,
                    Identificacion = x.Identificacion,
                    Nombre = x.Nombre,
                    Apellido = x.Apellido,
                    Direccion = x.Direccion,
                    Telefono = x.Telefono,
                    Email = x.Email,
                    FechaNacimiento = x.FechaNacimiento,
                    Estado = x.Estado,
                    MatriculaId = x.MatriculaId,
                    FechaExpedicion = x.Matriculas.FechaExpedicion,
                    FechaVencimiento = x.Matriculas.FechaVencimiento
                }).ToListAsync();
                if (conductor == null)
                {
                    return NotFound();
                }
                else
                {
                    return conductor;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion metodoGet

        #region metodoGetId

        // GET api/<ConductorController>/5
        [HttpGet("{Identificacion}")]
        public async Task<ActionResult<ConductorDTO>> Get(String Identificacion)
        {
            try
            {
                var conductor = await _context.Conductor.Select(x =>
                new ConductorDTO
                {
                    //Id = x.Id,
                    Identificacion = x.Identificacion,
                    Nombre = x.Nombre,
                    Apellido = x.Apellido,
                    Direccion = x.Direccion,
                    Telefono = x.Telefono,
                    Email = x.Email,
                    FechaNacimiento = x.FechaNacimiento,
                    Estado = x.Estado,
                    MatriculaId = x.MatriculaId,
                    FechaExpedicion = x.Matriculas.FechaExpedicion,
                    FechaVencimiento = x.Matriculas.FechaVencimiento,
                }).FirstOrDefaultAsync(x => x.Identificacion == Identificacion);
                if (conductor == null)
                {
                    return NotFound();
                }
                else
                {
                    return conductor;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        #endregion metodoGetId

        #region metodoPost

        // POST api/<MatriculasController>
        [HttpPost]
        public async Task<HttpStatusCode> Post(ConductorDTO conductor)
        {
            try
            {
                var entity = new Conductor()
                {
                    //Id = conductor.Id,
                    Identificacion = conductor.Identificacion,
                    Nombre = conductor.Nombre,
                    Apellido = conductor.Apellido,
                    Direccion = conductor.Direccion,
                    Telefono = conductor.Telefono,
                    Email = conductor.Email,
                    FechaNacimiento = conductor.FechaNacimiento,
                    Estado = conductor.Estado,
                    MatriculaId = conductor.MatriculaId
                };
                _context.Conductor.Add(entity);
                await _context.SaveChangesAsync();
                return HttpStatusCode.Created;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion metodoPost

        #region metodoPut

        // PUT api/<ConductorController>/5
        [HttpPut("{Nombre}")]
        public async Task<HttpStatusCode> Put(ConductorDTO conductor)
        {
            try
            {
                var entity = await _context.Conductor.FirstOrDefaultAsync(v => v.Identificacion == conductor.Identificacion);
                //entity.Id = matriculas.Id;
                entity.Identificacion = conductor.Identificacion;
                entity.Nombre = conductor.Nombre;
                entity.Apellido = conductor.Apellido;
                entity.Direccion = conductor.Direccion;
                entity.Telefono = conductor.Telefono;
                entity.Email = conductor.Email;
                entity.FechaNacimiento = conductor.FechaNacimiento;
                entity.Estado = conductor.Estado;
                entity.MatriculaId = conductor.MatriculaId;

                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return HttpStatusCode.Accepted;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion metodoPut

        #region metodoDelete
        // DELETE api/<ConductorController>/5
        [HttpDelete("{Identificacion}")]

        public async Task<HttpStatusCode> Delete(String Identificacion)
        {
            try
            {
                var conductor = _context.Conductor.Find(Identificacion);
                if (conductor.Estado == false)
                {
                    return HttpStatusCode.BadRequest;
                }
                else
                {
                    var entity = await _context.Conductor.FirstOrDefaultAsync(v => v.Identificacion == Identificacion);
                    entity.Estado = false;
                    _context.Entry(entity).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    //_context.Entry(matricula).State = EntityState.Deleted;
                    //_context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return HttpStatusCode.OK;
        }
        #endregion metodoDelete

            #endregion metodos
     
    }//Final clase ConductorController
}
