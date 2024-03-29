﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        }

        // GET: api/Events
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> GetEvent()
        {
            
            return await _context.Event.ToListAsync();
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
        public async Task<IActionResult> PutEvent(int id, Event @event)
        {
            if (id != @event.Eventid)
            {
                return BadRequest();
            }
            var curEC = _context.Eventcharacteristic
                                    .Where(_ec => _ec.Eventid == @event.Eventid)
                                    .ToList();
            var newEC = @event.Eventcharacteristic;

            _context.Eventcharacteristic.RemoveRange(curEC.Except(newEC));
            _context.Eventcharacteristic.AddRange(newEC.Except(curEC));

            var curEHC = _context.Eventhclass
                                    .Where(_ec => _ec.Eventid == @event.Eventid)
                                    .ToList();
            var newEHC = @event.Eventhclass;

            _context.Eventhclass.RemoveRange(curEHC.Except(newEHC));
            _context.Eventhclass.AddRange(newEHC.Except(curEHC));
            var curEH = _context.Eventhorse
                                    .Where(_ec => _ec.Eventid == @event.Eventid)
                                    .ToList();
            var newEH = @event.Eventhorse;

            _context.Eventhorse.RemoveRange(curEH.Except(newEH));
            _context.Eventhorse.AddRange(newEH.Except(curEH));

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

            _context.Entry(@event).State = EntityState.Modified;

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

            return NoContent();
        }

        // POST: api/Events
        [HttpPost]
        public async Task<ActionResult<Event>> PostEvent(Event @event)
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
