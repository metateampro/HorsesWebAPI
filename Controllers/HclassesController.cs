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
    public class HclassesController : ControllerBase
    {
        private readonly horsesContext _context;

        public HclassesController(horsesContext context)
        {
            _context = context;
        }

        // GET: api/Hclasses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hclass>>> GetHclass()
        {
            return await _context.Hclass.ToListAsync();
        }

        // GET: api/Hclasses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hclass>> GetHclass(int id)
        {
            var hclass = await _context.Hclass.FindAsync(id);

            if (hclass == null)
            {
                return NotFound();
            }

            return hclass;
        }

        // PUT: api/Hclasses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHclass(int id, Hclass hclass)
        {
            if (id != hclass.Hclassid)
            {
                return BadRequest();
            }

            _context.Entry(hclass).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HclassExists(id))
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

        // POST: api/Hclasses
        [HttpPost]
        public async Task<ActionResult<Hclass>> PostHclass(Hclass hclass)
        {
            _context.Hclass.Add(hclass);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHclass", new { id = hclass.Hclassid }, hclass);
        }

        // DELETE: api/Hclasses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Hclass>> DeleteHclass(int id)
        {
            var hclass = await _context.Hclass.FindAsync(id);
            if (hclass == null)
            {
                return NotFound();
            }

            _context.Hclass.Remove(hclass);
            await _context.SaveChangesAsync();

            return hclass;
        }

        private bool HclassExists(int id)
        {
            return _context.Hclass.Any(e => e.Hclassid == id);
        }
    }
}
