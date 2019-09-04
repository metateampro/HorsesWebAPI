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
    public class EvaluatesController : ControllerBase
    {
        private readonly horsesContext _context;

        public EvaluatesController(horsesContext context)
        {
            _context = context;
        }

        // GET: api/Evaluates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Evaluate>>> GetEvaluate()
        {
            return await _context.Evaluate.ToListAsync();
        }

        // GET: api/Evaluates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Evaluate>> GetEvaluate(int id)
        {
            var evaluate = await _context.Evaluate.FindAsync(id);

            if (evaluate == null)
            {
                return NotFound();
            }

            return evaluate;
        }

        // PUT: api/Evaluates/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvaluate(int id, Evaluate evaluate)
        {
            if (id != evaluate.Evaluateid)
            {
                return BadRequest();
            }

            _context.Entry(evaluate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EvaluateExists(id))
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

        // POST: api/Evaluates
        [HttpPost]
        public async Task<ActionResult<Evaluate>> PostEvaluate(Evaluate evaluate)
        {
            _context.Evaluate.Add(evaluate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEvaluate", new { id = evaluate.Evaluateid }, evaluate);
        }

        // DELETE: api/Evaluates/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Evaluate>> DeleteEvaluate(int id)
        {
            var evaluate = await _context.Evaluate.FindAsync(id);
            if (evaluate == null)
            {
                return NotFound();
            }

            _context.Evaluate.Remove(evaluate);
            await _context.SaveChangesAsync();

            return evaluate;
        }

        private bool EvaluateExists(int id)
        {
            return _context.Evaluate.Any(e => e.Evaluateid == id);
        }
    }
}
