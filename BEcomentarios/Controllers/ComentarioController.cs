using BEcomentarios.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BEcomentarios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentarioController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ComentarioController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<ComentarioController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try {
                var listComentarios = await _context.Comentario.ToListAsync();

                return Ok(listComentarios);

            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<ComentarioController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                var comentario = await _context.Comentario.FindAsync(id);

                if (comentario == null)
                {
                    return NotFound();
                }

                return Ok(comentario);

            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ComentarioController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Comentario comentario)
        {
            try {
                _context.Add(comentario);
                await _context.SaveChangesAsync();

                return Ok(comentario);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ComentarioController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Comentario comentario)
        {
            try
            {
                if(id != comentario.id) {
                    return BadRequest("el id no coincide");
                }

                _context.Update(comentario);
                await _context.SaveChangesAsync();

                return Ok(new { message = "Comentario acyualizado con exito" });


            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ComentarioController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var comentario = await _context.Comentario.FindAsync(id);

                if(comentario == null)
                {
                    return NotFound();
                }

                _context.Comentario.Remove(comentario);
                await _context.SaveChangesAsync();

                return Ok(new { message = "Comentario eleiminado con exito" });

            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
