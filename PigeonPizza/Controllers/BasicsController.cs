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
    public class BasicsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BasicsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Basics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PizzaBasic>>> GetBasics()
        {
            return await _context.Basics.ToListAsync();
        }

        // GET: api/Basics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PizzaBasic>> GetPizzaBasic(int id)
        {
            var pizzaBasic = await _context.Basics.FindAsync(id);

            if (pizzaBasic == null)
            {
                return NotFound();
            }

            return pizzaBasic;
        }

        // PUT: api/Basics/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPizzaBasic(int id, PizzaBasic pizzaBasic)
        {
            if (id != pizzaBasic.Id)
            {
                return BadRequest();
            }

            _context.Entry(pizzaBasic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PizzaBasicExists(id))
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

        // POST: api/Basics
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PizzaBasic>> PostPizzaBasic(PizzaBasic pizzaBasic)
        {
            _context.Basics.Add(pizzaBasic);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPizzaBasic), new { id = pizzaBasic.Id }, pizzaBasic);
        }

        // DELETE: api/Basics/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePizzaBasic(int id)
        {
            var pizzaBasic = await _context.Basics.FindAsync(id);
            if (pizzaBasic == null)
            {
                return NotFound();
            }

            _context.Basics.Remove(pizzaBasic);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PizzaBasicExists(int id)
        {
            return _context.Basics.Any(e => e.Id == id);
        }
    }
}
