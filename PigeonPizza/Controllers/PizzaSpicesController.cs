using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PigeonPizza.Contexts;
using PigeonPizza.Models.Primitive;

namespace PigeonPizza.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaSpicesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PizzaSpicesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/PizzaSpices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PizzaSpice>>> GetPizzaSpices()
        {
            return await _context.PizzaSpices.ToListAsync();
        }

        // GET: api/PizzaSpices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PizzaSpice>> GetPizzaSpice(int id)
        {
            var pizzaSpice = await _context.PizzaSpices.FindAsync(id);

            if (pizzaSpice == null)
            {
                return NotFound();
            }

            return pizzaSpice;
        }

        // PUT: api/PizzaSpices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPizzaSpice(int id, PizzaSpice pizzaSpice)
        {
            if (id != pizzaSpice.Id)
            {
                return BadRequest();
            }

            _context.Entry(pizzaSpice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PizzaSpiceExists(id))
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

        // POST: api/PizzaSpices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PizzaSpice>> PostPizzaSpice(PizzaSpice pizzaSpice)
        {
            _context.PizzaSpices.Add(pizzaSpice);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPizzaSpice), new { id = pizzaSpice.Id }, pizzaSpice);
        }

        // DELETE: api/PizzaSpices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePizzaSpice(int id)
        {
            var pizzaSpice = await _context.PizzaSpices.FindAsync(id);
            if (pizzaSpice == null)
            {
                return NotFound();
            }

            _context.PizzaSpices.Remove(pizzaSpice);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PizzaSpiceExists(int id)
        {
            return _context.PizzaSpices.Any(e => e.Id == id);
        }
    }
}
