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
    public class PizzaToppingsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PizzaToppingsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/PizzaToppings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PizzaTopping>>> GetPizzaToppings()
        {
            return await _context.PizzaToppings.ToListAsync();
        }

        // GET: api/PizzaToppings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PizzaTopping>> GetPizzaTopping(int id)
        {
            var pizzaTopping = await _context.PizzaToppings.FindAsync(id);

            if (pizzaTopping == null)
            {
                return NotFound();
            }

            return pizzaTopping;
        }

        // PUT: api/PizzaToppings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPizzaTopping(int id, PizzaTopping pizzaTopping)
        {
            if (id != pizzaTopping.Id)
            {
                return BadRequest();
            }

            _context.Entry(pizzaTopping).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PizzaToppingExists(id))
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

        // POST: api/PizzaToppings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PizzaTopping>> PostPizzaTopping(PizzaTopping pizzaTopping)
        {
            _context.PizzaToppings.Add(pizzaTopping);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPizzaTopping), new { id = pizzaTopping.Id }, pizzaTopping);
        }

        // DELETE: api/PizzaToppings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePizzaTopping(int id)
        {
            var pizzaTopping = await _context.PizzaToppings.FindAsync(id);
            if (pizzaTopping == null)
            {
                return NotFound();
            }

            _context.PizzaToppings.Remove(pizzaTopping);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PizzaToppingExists(int id)
        {
            return _context.PizzaToppings.Any(e => e.Id == id);
        }
    }
}
