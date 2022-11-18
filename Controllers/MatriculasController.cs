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
    public class MatriculasController : ControllerBase
    {
        #region propiedades
        private readonly VehiculosDbContext _context;
        #endregion propiedades

        #region constructor
        public MatriculasController(VehiculosDbContext context)
        {
            _context = context;
        }
        #endregion constructor

        #region Métodos

        #region metodoGet
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MatriculasDTO>>> Get()
        {
            try
            {
                var matricula = await _context.Matriculas.Select(x =>
                new MatriculasDTO
                {
                    //Id = x.Id,
                    Numero = x.Numero,
                    FechaExpedicion = x.FechaExpedicion,
                    FechaVencimiento = x.FechaVencimiento,
                    Estado = x.Estado
                }).ToListAsync();
                if(matricula == null)
                {
                    return NotFound();
                }
                else
                {
                    return matricula;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        #endregion metodoGet

        #region metodoGetId
        // GET api/<MatriculasController>/5
        [HttpGet("{Numero}")]
        public async Task<ActionResult<MatriculasDTO>> Get(String Numero)
        {
            try
            {
                var matricula = await _context.Matriculas.Select(x =>
                new MatriculasDTO
                {
                    ///Id = x.Id,
                    Numero = x.Numero,
                    FechaExpedicion = x.FechaExpedicion,
                    FechaVencimiento = x.FechaVencimiento,
                    Estado = x.Estado
                }).FirstOrDefaultAsync(x => x.Numero == Numero);
                if (matricula == null)
                {
                    return NotFound();
                }
                else
                {
                    return matricula;
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
        public async Task<HttpStatusCode> Post(MatriculasDTO matriculas)
        {
            try
            {
                var entity = new Matriculas()
                {
                    //Id = matriculas.Id,
                    Numero = matriculas.Numero,
                    FechaExpedicion = matriculas.FechaExpedicion,
                    FechaVencimiento = matriculas.FechaVencimiento,
                    Estado = matriculas.Estado
                };
                _context.Matriculas.Add(entity);
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
        // PUT api/<MatriculasController>/5
        [HttpPut("{Nombre}")]
        public async Task<HttpStatusCode> Put(MatriculasDTO matriculas)
        {
            try
            {
                var entity = await _context.Matriculas.FirstOrDefaultAsync(v => v.Numero == matriculas.Numero);
                //entity.Id = matriculas.Id;
                entity.Numero = matriculas.Numero;
                entity.FechaExpedicion = matriculas.FechaExpedicion;
                entity.FechaVencimiento = matriculas.FechaVencimiento;
                entity.Estado = matriculas.Estado;

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

        // DELETE api/<MatriculasController>/5
        [HttpDelete("{Numero}")]

        public async Task<HttpStatusCode> Delete(String Numero)
        {
            try
            {
                var matricula = _context.Matriculas.Find(Numero);
                if (matricula.Estado == false)
                {
                    return HttpStatusCode.BadRequest;
                }
                else
                {
                    var entity = await _context.Matriculas.FirstOrDefaultAsync(v => v.Numero == Numero);
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

        #endregion Métodos
    }//Final clase MatriculasController
}
