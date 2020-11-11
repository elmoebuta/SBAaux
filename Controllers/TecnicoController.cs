using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [ApiController] /*ira abajo?*/
    [Route("api/[controller]")]
    public class TecnicoController : ControllerBase
    {
        private readonly TecnicoCTX _context;
        public TecnicoController(TecnicoCTX context)
        {
            _context =context;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<Tecnico>>> GetTecnico()
        {
            return await _context.Tecnico.ToListAsync();
        }
        [HttpGet("{id}")]

        public async Task<ActionResult<Tecnico>> GetTecnico(int id)
        {
            var tecnico =await _context.Tecnico.FindAsync(id);
            if (tecnico ==null)
            {
                return NotFound();
            }
            return tecnico;
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> PutTecnico(int id,Tecnico tecnico)
        {
            
            
            if (id !=tecnico.Id)
            {
                return BadRequest();
            }

            _context.Entry(tecnico).State =EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }

            catch (DbUpdateConcurrencyException)
            {
                if (!TecnicoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;

                }
            }

            return NoContent();
        }

        [HttpPost]
         public async Task<ActionResult<Tecnico>> PostTecnico(Tecnico tecnico)
         {
             _context.Tecnico.Add(tecnico);
             await _context.SaveChangesAsync();
             return CreatedAtAction("GetTecnico", new {id=tecnico.Id},tecnico);
         }
         
         [HttpDelete("{id}")]
         public async Task<ActionResult<Tecnico>> DeleteUsuario(int id)
         {
             var tecnico =await _context.Tecnico.FindAsync(id);
            if (tecnico ==null)
            {
                return NotFound();
            }
             _context.Tecnico.Remove(tecnico);
             await _context.SaveChangesAsync();
             return tecnico;

         }

         private bool TecnicoExists(int id)
         {
             return _context.Tecnico.Any(e => e.Id ==id);
         }
         





    }
}