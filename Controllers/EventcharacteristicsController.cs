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
    public class EventcharacteristicsController : ControllerBase
    {
        private readonly horsesContext _context;

        public EventcharacteristicsController(horsesContext context)
        {
            _context = context;
        }

        // GET: api/Eventcharacteristics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Eventcharacteristic>>> GetEventcharacteristic()
        {
            return await _context.Eventcharacteristic.ToListAsync();
        }

        // GET: api/Eventcharacteristics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Eventcharacteristic>> GetEventcharacteristic(int id)
        {
            var eventcharacteristic = await _context.Eventcharacteristic.FindAsync(id);

            if (eventcharacteristic == null)
            {
                return NotFound();
            }

            return eventcharacteristic;
        }

        // PUT: api/Eventcharacteristics/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventcharacteristic(int id, Eventcharacteristic eventcharacteristic)
        {
            if (id != eventcharacteristic.Eventcharacteristic1)
            {
                return BadRequest();
            }

            _context.Entry(eventcharacteristic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventcharacteristicExists(id))
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

        // POST: api/Eventcharacteristics
        [HttpPost]
        public async Task<ActionResult<Eventcharacteristic>> PostEventcharacteristic(Eventcharacteristic eventcharacteristic)
        {
            _context.Eventcharacteristic.Add(eventcharacteristic);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEventcharacteristic", new { id = eventcharacteristic.Eventcharacteristic1 }, eventcharacteristic);
        }

        // DELETE: api/Eventcharacteristics/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Eventcharacteristic>> DeleteEventcharacteristic(int id)
        {
            var eventcharacteristic = await _context.Eventcharacteristic.FindAsync(id);
            if (eventcharacteristic == null)
            {
                return NotFound();
            }

            _context.Eventcharacteristic.Remove(eventcharacteristic);
            await _context.SaveChangesAsync();

            return eventcharacteristic;
        }

        private bool EventcharacteristicExists(int id)
        {
            return _context.Eventcharacteristic.Any(e => e.Eventcharacteristic1 == id);
        }
    }
}
