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
    public class PizzaSaucesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PizzaSaucesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/PizzaSauces
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PizzaSauce>>> GetPizzaSauces()
        {
            return await _context.PizzaSauces.ToListAsync();
        }

        // GET: api/PizzaSauces/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PizzaSauce>> GetPizzaSauce(int id)
        {
            var pizzaSauce = await _context.PizzaSauces.FindAsync(id);

            if (pizzaSauce == null)
            {
                return NotFound();
            }

            return pizzaSauce;
        }

        // PUT: api/PizzaSauces/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPizzaSauce(int id, PizzaSauce pizzaSauce)
        {
            if (id != pizzaSauce.Id)
            {
                return BadRequest();
            }

            _context.Entry(pizzaSauce).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PizzaSauceExists(id))
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

        // POST: api/PizzaSauces
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PizzaSauce>> PostPizzaSauce(PizzaSauce pizzaSauce)
        {
            _context.PizzaSauces.Add(pizzaSauce);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPizzaSauce), new { id = pizzaSauce.Id }, pizzaSauce);
        }

        // DELETE: api/PizzaSauces/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePizzaSauce(int id)
        {
            var pizzaSauce = await _context.PizzaSauces.FindAsync(id);
            if (pizzaSauce == null)
            {
                return NotFound();
            }

            _context.PizzaSauces.Remove(pizzaSauce);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PizzaSauceExists(int id)
        {
            return _context.PizzaSauces.Any(e => e.Id == id);
        }
    }
}
