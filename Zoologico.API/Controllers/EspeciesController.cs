using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zoologicos.Modelos;

namespace Zoologico.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspeciesController : ControllerBase
    {
        private readonly ZoologicoAPIContext _context;

        public EspeciesController(ZoologicoAPIContext context)
        {
            _context = context;
        }

        // GET: api/Especies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Especie>>> GetEspecie()
        {
            return await _context.Especie.ToListAsync();
        }

        // GET: api/Especies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResult<Especie>>> GetEspecie(int id)
        {
            try
            {
                var especie = await _context
                    .Especie
                    .Include(e => e.Animals)
                    .FirstOrDefaultAsync(e => e.Codigo == id);

                if (especie == null)
                {
                    return ApiResult<Especie>.Fail("Datos no encontrados");
                }

                return ApiResult<Especie>.Ok(especie);
            }
            catch (Exception ex)
            {
                return ApiResult<Especie>.Fail(ex.Message);
            }
        }

        // PUT: api/Especies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResult<Especie>>> PutEspecie(int id, Especie especie)
        {
            if (id != especie.Codigo)
            {
                return ApiResult<Especie>.Fail("No coinciden los identificadores");
            }

            _context.Entry(especie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!EspecieExists(id))
                {
                    return ApiResult<Especie>.Fail("Datos no encontrados");
                }
                else
                {
                    return ApiResult<Especie>.Fail(ex.Message);
                }
            }

            return ApiResult<Especie>.Ok(null);
        }

        // POST: api/Especies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ApiResult<Especie>>> PostEspecie(Especie especie)
        {
            try
            {
                _context.Especie.Add(especie);
                await _context.SaveChangesAsync();

                return ApiResult<Especie>.Ok(especie);
            }
            catch (Exception ex)
            {
                return ApiResult<Especie>.Fail(ex.Message);
            }
        }

        // DELETE: api/Especies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResult<Especie>>> DeleteEspecie(int id)
        {
            try
            {
                var especie = await _context.Especie.FindAsync(id);
                if (especie == null)
                {
                    return ApiResult<Especie>.Fail("datos no encontrados");
                }

                _context.Especie.Remove(especie);
                await _context.SaveChangesAsync();

                return ApiResult<Especie>.Ok(null);
            }
            catch (Exception ex)
            {
                return ApiResult<Especie>.Fail(ex.Message);
            }
        }

        private bool EspecieExists(int id)
        {
            return _context.Especie.Any(e => e.Codigo == id);
        }
    }
}
