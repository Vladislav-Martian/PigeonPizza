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
    public class PizzaBasesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PizzaBasesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/PizzaBases
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PizzaBase>>> GetPizzaBases()
        {
            return await _context.PizzaBases.ToListAsync();
        }

        // GET: api/PizzaBases/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PizzaBase>> GetPizzaBase(int id)
        {
            var pizzaBase = await _context.PizzaBases.FindAsync(id);

            if (pizzaBase == null)
            {
                return NotFound();
            }

            return pizzaBase;
        }

        // PUT: api/PizzaBases/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPizzaBase(int id, PizzaBase pizzaBase)
        {
            if (id != pizzaBase.Id)
            {
                return BadRequest();
            }

            _context.Entry(pizzaBase).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PizzaBaseExists(id))
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

        // POST: api/PizzaBases
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PizzaBase>> PostPizzaBase(PizzaBase pizzaBase)
        {
            _context.PizzaBases.Add(pizzaBase);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPizzaBase), new { id = pizzaBase.Id }, pizzaBase);
        }

        // DELETE: api/PizzaBases/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePizzaBase(int id)
        {
            var pizzaBase = await _context.PizzaBases.FindAsync(id);
            if (pizzaBase == null)
            {
                return NotFound();
            }

            _context.PizzaBases.Remove(pizzaBase);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PizzaBaseExists(int id)
        {
            return _context.PizzaBases.Any(e => e.Id == id);
        }
    }
}
