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
    public class EventhclassesController : ControllerBase
    {
        private readonly horsesContext _context;

        public EventhclassesController(horsesContext context)
        {
            _context = context;
        }

        // GET: api/Eventhclasses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Eventhclass>>> GetEventhclass()
        {
            return await _context.Eventhclass.ToListAsync();
        }

        // GET: api/Eventhclasses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Eventhclass>> GetEventhclass(int id)
        {
            var eventhclass = await _context.Eventhclass.FindAsync(id);

            if (eventhclass == null)
            {
                return NotFound();
            }

            return eventhclass;
        }

        // PUT: api/Eventhclasses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventhclass(int id, Eventhclass eventhclass)
        {
            if (id != eventhclass.Eventclassid)
            {
                return BadRequest();
            }

            _context.Entry(eventhclass).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventhclassExists(id))
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

        // POST: api/Eventhclasses
        [HttpPost]
        public async Task<ActionResult<Eventhclass>> PostEventhclass(Eventhclass eventhclass)
        {
            _context.Eventhclass.Add(eventhclass);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEventhclass", new { id = eventhclass.Eventclassid }, eventhclass);
        }

        // DELETE: api/Eventhclasses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Eventhclass>> DeleteEventhclass(int id)
        {
            var eventhclass = await _context.Eventhclass.FindAsync(id);
            if (eventhclass == null)
            {
                return NotFound();
            }

            _context.Eventhclass.Remove(eventhclass);
            await _context.SaveChangesAsync();

            return eventhclass;
        }

        private bool EventhclassExists(int id)
        {
            return _context.Eventhclass.Any(e => e.Eventclassid == id);
        }
    }
}
