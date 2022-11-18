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
    public class SancionesController : ControllerBase
    {
        #region propiedades
        private readonly VehiculosDbContext _context;
        #endregion propiedades

        #region constructor
        public SancionesController(VehiculosDbContext context)
        {
            _context = context;
        }
        #endregion constructor

        #region metodos

        #region metodoGet

        // GET: api/<SancionesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SancionesDTO>>> Get()
        {
            try
            {
                var sancion = await _context.Sanciones.Select(x =>
                new SancionesDTO
                {
                    Id = x.Id,
                    FechaActual = x.FechaActual,
                    Sancion = x.Sancion,
                    Observacion = x.Observacion,
                    Valor = x.Valor,
                    ConductorId = x.ConductorId,
                    Nombre = x.Conductor.Nombre,
                    Apellido = x.Conductor.Apellido
                }).ToListAsync();
                if (sancion == null)
                {
                    return NotFound();
                }
                else
                {
                    return sancion;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        #endregion metodoGet

        #region metodoGetId
        // GET api/<SancionesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SancionesDTO>> Get(int id)
        {
            try
            {
                var sancion = await _context.Sanciones.Select(x =>
                new SancionesDTO
                {
                    Id = x.Id,
                    FechaActual = x.FechaActual,
                    Sancion = x.Sancion,
                    Observacion = x.Observacion,
                    Valor = x.Valor,
                    ConductorId = x.ConductorId,
                    Nombre = x.Conductor.Nombre,
                    Apellido = x.Conductor.Apellido
                }).FirstOrDefaultAsync(x => x.Id == id);
                if (sancion == null)
                {
                    return NotFound();
                }
                else
                {
                    return sancion;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        #endregion metodoGetId

        #region metodoPost
        
        // POST api/<SancionesController>
        [HttpPost]
        public async Task<HttpStatusCode> Post(SancionesDTO sancion)
        {
            try
            {
                var entity = new Sanciones()
                {
                    Id = sancion.Id,
                    FechaActual = DateTime.Now,
                    Sancion = sancion.Sancion,
                    Observacion = sancion.Observacion,
                    Valor = sancion.Valor,
                    ConductorId = sancion.ConductorId
                };
                _context.Sanciones.Add(entity);
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
        // PUT api/<SancionesController>/5
        [HttpPut("{id}")]
        public async Task<HttpStatusCode> Put(SancionesDTO sancion)
        {
            try
            {
                var entity = await _context.Sanciones.FirstOrDefaultAsync(v => v.Id == sancion.Id);
                entity.Id = sancion.Id;
                entity.FechaActual = sancion.FechaActual;
                entity.Sancion = sancion.Sancion;
                entity.Observacion = sancion.Observacion;
                entity.Valor = sancion.Valor;
                entity.ConductorId = sancion.ConductorId;
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return HttpStatusCode.NoContent;
        }

        #endregion metodoPut

        #region metodoDelete
        // DELETE api/<SancionesController>/5
        [HttpDelete("{id}")]
        public async Task<HttpStatusCode> Delete(int id)
        {
            try
            {
                var entity = new Sanciones()
                {
                    Id = id
                };
                _context.Sanciones.Attach(entity);
                _context.Sanciones.Remove(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return HttpStatusCode.OK;
        }

        #endregion metodoDelete

        #endregion metodos
    }//Final clase SancionesController
}
