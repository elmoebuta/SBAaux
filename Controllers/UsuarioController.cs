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
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioCTX _context;
        public UsuarioController(UsuarioCTX context)
        {
            _context =context;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuario()
        {
            return await _context.Usuario.ToListAsync();
        }
        [HttpGet("{id}")]

        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario =await _context.Usuario.FindAsync(id);
            if (usuario ==null)
            {
                return NotFound();
            }
            return usuario;
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> PutUsuario(int id,Usuario usuario)
        {
            
            
            if (id !=usuario.Id)
            {
                return BadRequest();
            }

            _context.Entry(usuario).State =EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }

            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
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
         public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
         {
             _context.Usuario.Add(usuario);
             await _context.SaveChangesAsync();
             return CreatedAtAction("GetUsuario", new {id=usuario.Id},usuario);
         }
         
         [HttpDelete("{id}")]
         public async Task<ActionResult<Usuario>> DeleteUsuario(int id)
         {
             var usuario =await _context.Usuario.FindAsync(id);
            if (usuario ==null)
            {
                return NotFound();
            }
             _context.Usuario.Remove(usuario);
             await _context.SaveChangesAsync();
             return usuario;

         }

         private bool UsuarioExists(int id)
         {
             return _context.Usuario.Any(e => e.Id ==id);
         }
         





    }
}