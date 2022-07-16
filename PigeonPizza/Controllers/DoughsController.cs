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
    public class DoughsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DoughsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Doughs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PizzaBasicsDough>>> GetDoughs()
        {
            return await _context.Doughs.ToListAsync();
        }

        // GET: api/Doughs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PizzaBasicsDough>> GetPizzaBasicsDough(int id)
        {
            var pizzaBasicsDough = await _context.Doughs.FindAsync(id);

            if (pizzaBasicsDough == null)
            {
                return NotFound();
            }

            return pizzaBasicsDough;
        }

        // PUT: api/Doughs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPizzaBasicsDough(int id, PizzaBasicsDough pizzaBasicsDough)
        {
            if (id != pizzaBasicsDough.Id)
            {
                return BadRequest();
            }

            _context.Entry(pizzaBasicsDough).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PizzaBasicsDoughExists(id))
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

        // POST: api/Doughs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PizzaBasicsDough>> PostPizzaBasicsDough(PizzaBasicsDough pizzaBasicsDough)
        {
            _context.Doughs.Add(pizzaBasicsDough);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPizzaBasicsDough), new { id = pizzaBasicsDough.Id }, pizzaBasicsDough);
        }

        // DELETE: api/Doughs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePizzaBasicsDough(int id)
        {
            var pizzaBasicsDough = await _context.Doughs.FindAsync(id);
            if (pizzaBasicsDough == null)
            {
                return NotFound();
            }

            _context.Doughs.Remove(pizzaBasicsDough);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PizzaBasicsDoughExists(int id)
        {
            return _context.Doughs.Any(e => e.Id == id);
        }
    }
}
