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
    public class WorksController : ControllerBase
    {
        private readonly AppDbContext _context;

        public WorksController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Works
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PizzaBasicsWork>>> GetWorks()
        {
            return await _context.Works.ToListAsync();
        }

        // GET: api/Works/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PizzaBasicsWork>> GetPizzaBasicsWork(int id)
        {
            var pizzaBasicsWork = await _context.Works.FindAsync(id);

            if (pizzaBasicsWork == null)
            {
                return NotFound();
            }

            return pizzaBasicsWork;
        }

        // PUT: api/Works/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPizzaBasicsWork(int id, PizzaBasicsWork pizzaBasicsWork)
        {
            if (id != pizzaBasicsWork.Id)
            {
                return BadRequest();
            }

            _context.Entry(pizzaBasicsWork).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PizzaBasicsWorkExists(id))
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

        // POST: api/Works
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PizzaBasicsWork>> PostPizzaBasicsWork(PizzaBasicsWork pizzaBasicsWork)
        {
            _context.Works.Add(pizzaBasicsWork);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPizzaBasicsWork), new { id = pizzaBasicsWork.Id }, pizzaBasicsWork);
        }

        // DELETE: api/Works/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePizzaBasicsWork(int id)
        {
            var pizzaBasicsWork = await _context.Works.FindAsync(id);
            if (pizzaBasicsWork == null)
            {
                return NotFound();
            }

            _context.Works.Remove(pizzaBasicsWork);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PizzaBasicsWorkExists(int id)
        {
            return _context.Works.Any(e => e.Id == id);
        }
    }
}
