using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Servidor_PANGEA.Models;
using Servidor_PANGEA.Models.Context;

namespace Servidor_PANGEA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly EventoContext _context;

        public EventoController(EventoContext context)
        {
            _context = context;
        }

        // GET: api/Evento
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Evento>>> GetEventoSet()
        {
            return await _context.EventoSet.ToListAsync();
        }

        // GET: api/Evento/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Evento>> GetEvento(int id)
        {
            var evento = await _context.EventoSet.FindAsync(id);

            if (evento == null)
            {
                return NotFound();
            }

            return evento;
        }

        // PUT: api/Evento/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvento(int id, Evento evento)
        {
            if (id != evento.Id)
            {
                return BadRequest();
            }

            _context.Entry(evento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventoExists(id))
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

        // POST: api/Evento
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Evento>> PostEvento(Evento evento)
        {
            _context.EventoSet.Add(evento);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEvento), new { id = evento.Id }, evento);
        }

        // DELETE: api/Evento/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Evento>> DeleteEvento(int id)
        {
            var evento = await _context.EventoSet.FindAsync(id);
            if (evento == null)
            {
                return NotFound();
            }

            _context.EventoSet.Remove(evento);
            await _context.SaveChangesAsync();

            return evento;
        }

        private bool EventoExists(int id)
        {
            return _context.EventoSet.Any(e => e.Id == id);
        }
    }
}
