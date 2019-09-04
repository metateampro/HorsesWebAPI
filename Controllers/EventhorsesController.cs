using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HorsesWebAPI;
using HorsesWebAPI.Models;

namespace HorsesWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventhorsesController : ControllerBase
    {
        private readonly horsesContext _context;

        public EventhorsesController(horsesContext context)
        {
            _context = context;
        }

        // GET: api/Eventhorses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Eventhorse>>> GetEventhorse()
        {
            return await _context.Eventhorse.ToListAsync();
        }

        // GET: api/Eventhorses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Eventhorse>> GetEventhorse(int id)
        {
            var eventhorse = await _context.Eventhorse.FindAsync(id);

            if (eventhorse == null)
            {
                return NotFound();
            }

            return eventhorse;
        }

        // PUT: api/Eventhorses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventhorse(int id, Eventhorse eventhorse)
        {
            if (id != eventhorse.Eventhorseid)
            {
                return BadRequest();
            }

            _context.Entry(eventhorse).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventhorseExists(id))
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

        // POST: api/Eventhorses
        [HttpPost]
        public async Task<ActionResult<Eventhorse>> PostEventhorse(Eventhorse eventhorse)
        {
            _context.Eventhorse.Add(eventhorse);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEventhorse", new { id = eventhorse.Eventhorseid }, eventhorse);
        }

        // DELETE: api/Eventhorses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Eventhorse>> DeleteEventhorse(int id)
        {
            var eventhorse = await _context.Eventhorse.FindAsync(id);
            if (eventhorse == null)
            {
                return NotFound();
            }

            _context.Eventhorse.Remove(eventhorse);
            await _context.SaveChangesAsync();

            return eventhorse;
        }

        private bool EventhorseExists(int id)
        {
            return _context.Eventhorse.Any(e => e.Eventhorseid == id);
        }
    }
}
