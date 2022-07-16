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
    public class ToppingsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ToppingsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Toppings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PizzaBasicsTopping>>> GetToppings()
        {
            return await _context.Toppings.ToListAsync();
        }

        // GET: api/Toppings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PizzaBasicsTopping>> GetPizzaBasicsTopping(int id)
        {
            var pizzaBasicsTopping = await _context.Toppings.FindAsync(id);

            if (pizzaBasicsTopping == null)
            {
                return NotFound();
            }

            return pizzaBasicsTopping;
        }

        // PUT: api/Toppings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPizzaBasicsTopping(int id, PizzaBasicsTopping pizzaBasicsTopping)
        {
            if (id != pizzaBasicsTopping.Id)
            {
                return BadRequest();
            }

            _context.Entry(pizzaBasicsTopping).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PizzaBasicsToppingExists(id))
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

        // POST: api/Toppings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PizzaBasicsTopping>> PostPizzaBasicsTopping(PizzaBasicsTopping pizzaBasicsTopping)
        {
            _context.Toppings.Add(pizzaBasicsTopping);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPizzaBasicsTopping), new { id = pizzaBasicsTopping.Id }, pizzaBasicsTopping);
        }

        // DELETE: api/Toppings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePizzaBasicsTopping(int id)
        {
            var pizzaBasicsTopping = await _context.Toppings.FindAsync(id);
            if (pizzaBasicsTopping == null)
            {
                return NotFound();
            }

            _context.Toppings.Remove(pizzaBasicsTopping);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PizzaBasicsToppingExists(int id)
        {
            return _context.Toppings.Any(e => e.Id == id);
        }
    }
}
