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
    public class EventsController : ControllerBase
    {
        private readonly horsesContext _context;

        public EventsController(horsesContext context)
        {
            _context = context;
            foreach(var _event in _context.Event)
            {
                _context.Entry(_event)
                    .Collection(_e => _e.Characteristics)
                    .Load();
                _context.Entry(_event)
                    .Collection(_e => _e.Horses)
                    .Load();
                _context.Entry(_event)
                    .Collection(_e => _e.Hclasses)
                    .Load();
            }
        }

        // GET: api/Events
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> GetEvent()
        {

            return await _context.Event
                .ToListAsync();
        }

        // GET: api/Events/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetEvent(int id)
        {
            var @event = await _context.Event.FindAsync(id);

            if (@event == null)
            {
                return NotFound();
            }

            return @event;
        }

        // PUT: api/Events/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Event>> PutEvent(int id, [FromBody] Event @event)
        {
            if (id != @event.Eventid)
            {
                return BadRequest();
            }
            var existingEvent = _context.Event.Find(@event.Eventid);
            if (existingEvent != null)
                _context.Entry(existingEvent).CurrentValues.SetValues(@event);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return existingEvent;
        }

        // POST: api/Events
        [HttpPost]
        public async Task<ActionResult<Event>> PostEvent([FromBody] Event @event)
        {
            _context.Event.Add(@event);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEvent", new { id = @event.Eventid }, @event);
        }

        // DELETE: api/Events/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Event>> DeleteEvent(int id)
        {
            var @event = await _context.Event.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }

            _context.Event.Remove(@event);
            await _context.SaveChangesAsync();

            return @event;
        }

        private bool EventExists(int id)
        {
            return _context.Event.Any(e => e.Eventid == id);
        }
    }
}
