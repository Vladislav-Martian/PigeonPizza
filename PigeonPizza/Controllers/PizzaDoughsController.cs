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
    public class PizzaDoughsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PizzaDoughsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/PizzaDoughs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PizzaDough>>> GetPizzaDoughs()
        {
            return await _context.PizzaDoughs.ToListAsync();
        }

        // GET: api/PizzaDoughs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PizzaDough>> GetPizzaDough(int id)
        {
            var pizzaDough = await _context.PizzaDoughs.FindAsync(id);

            if (pizzaDough == null)
            {
                return NotFound();
            }

            return pizzaDough;
        }

        // PUT: api/PizzaDoughs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPizzaDough(int id, PizzaDough pizzaDough)
        {
            if (id != pizzaDough.Id)
            {
                return BadRequest();
            }

            _context.Entry(pizzaDough).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PizzaDoughExists(id))
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

        // POST: api/PizzaDoughs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PizzaDough>> PostPizzaDough(PizzaDough pizzaDough)
        {
            _context.PizzaDoughs.Add(pizzaDough);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPizzaDough), new { id = pizzaDough.Id }, pizzaDough);
        }

        // DELETE: api/PizzaDoughs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePizzaDough(int id)
        {
            var pizzaDough = await _context.PizzaDoughs.FindAsync(id);
            if (pizzaDough == null)
            {
                return NotFound();
            }

            _context.PizzaDoughs.Remove(pizzaDough);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PizzaDoughExists(int id)
        {
            return _context.PizzaDoughs.Any(e => e.Id == id);
        }
    }
}
