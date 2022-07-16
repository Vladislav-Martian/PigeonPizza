using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PigeonPizza.Contexts;
using PigeonPizza.Models.Basics;

namespace PigeonPizza.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScalesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ScalesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Scales
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PizzaBasicsScale>>> GetScales()
        {
            return await _context.Scales.ToListAsync();
        }

        // GET: api/Scales/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PizzaBasicsScale>> GetPizzaBasicsScale(int id)
        {
            var pizzaBasicsScale = await _context.Scales.FindAsync(id);

            if (pizzaBasicsScale == null)
            {
                return NotFound();
            }

            return pizzaBasicsScale;
        }

        // PUT: api/Scales/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPizzaBasicsScale(int id, PizzaBasicsScale pizzaBasicsScale)
        {
            if (id != pizzaBasicsScale.Id)
            {
                return BadRequest();
            }

            _context.Entry(pizzaBasicsScale).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PizzaBasicsScaleExists(id))
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

        // POST: api/Scales
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PizzaBasicsScale>> PostPizzaBasicsScale(PizzaBasicsScale pizzaBasicsScale)
        {
            _context.Scales.Add(pizzaBasicsScale);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPizzaBasicsScale), new { id = pizzaBasicsScale.Id }, pizzaBasicsScale);
        }

        // DELETE: api/Scales/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePizzaBasicsScale(int id)
        {
            var pizzaBasicsScale = await _context.Scales.FindAsync(id);
            if (pizzaBasicsScale == null)
            {
                return NotFound();
            }

            _context.Scales.Remove(pizzaBasicsScale);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PizzaBasicsScaleExists(int id)
        {
            return _context.Scales.Any(e => e.Id == id);
        }
    }
}
