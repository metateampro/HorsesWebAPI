using System;
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
    public class CharacteristicsController : ControllerBase
    {
        private readonly horsesContext _context;

        public CharacteristicsController(horsesContext context)
        {
            _context = context;
        }

        // GET: api/Characteristics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Characteristic>>> GetCharacteristic()
        {
            return await _context.Characteristic.ToListAsync();
        }

        // GET: api/Characteristics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Characteristic>> GetCharacteristic(int id)
        {
            var characteristic = await _context.Characteristic.FindAsync(id);

            if (characteristic == null)
            {
                return NotFound();
            }

            return characteristic;
        }

        // PUT: api/Characteristics/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharacteristic(int id, Characteristic characteristic)
        {
            if (id != characteristic.Characteristicid)
            {
                return BadRequest();
            }

            _context.Entry(characteristic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CharacteristicExists(id))
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

        // POST: api/Characteristics
        [HttpPost]
        public async Task<ActionResult<Characteristic>> PostCharacteristic(Characteristic characteristic)
        {
            _context.Characteristic.Add(characteristic);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCharacteristic", new { id = characteristic.Characteristicid }, characteristic);
        }

        // DELETE: api/Characteristics/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Characteristic>> DeleteCharacteristic(int id)
        {
            var characteristic = await _context.Characteristic.FindAsync(id);
            if (characteristic == null)
            {
                return NotFound();
            }

            _context.Characteristic.Remove(characteristic);
            await _context.SaveChangesAsync();

            return characteristic;
        }

        private bool CharacteristicExists(int id)
        {
            return _context.Characteristic.Any(e => e.Characteristicid == id);
        }
    }
}
