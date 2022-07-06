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
    public class PizzaProcessesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PizzaProcessesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/PizzaProcesses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PizzaProcess>>> GetPizzaProcesses()
        {
            return await _context.PizzaProcesses.ToListAsync();
        }

        // GET: api/PizzaProcesses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PizzaProcess>> GetPizzaProcess(int id)
        {
            var pizzaProcess = await _context.PizzaProcesses.FindAsync(id);

            if (pizzaProcess == null)
            {
                return NotFound();
            }

            return pizzaProcess;
        }

        // PUT: api/PizzaProcesses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPizzaProcess(int id, PizzaProcess pizzaProcess)
        {
            if (id != pizzaProcess.Id)
            {
                return BadRequest();
            }

            _context.Entry(pizzaProcess).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PizzaProcessExists(id))
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

        // POST: api/PizzaProcesses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PizzaProcess>> PostPizzaProcess(PizzaProcess pizzaProcess)
        {
            _context.PizzaProcesses.Add(pizzaProcess);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPizzaProcess), new { id = pizzaProcess.Id }, pizzaProcess);
        }

        // DELETE: api/PizzaProcesses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePizzaProcess(int id)
        {
            var pizzaProcess = await _context.PizzaProcesses.FindAsync(id);
            if (pizzaProcess == null)
            {
                return NotFound();
            }

            _context.PizzaProcesses.Remove(pizzaProcess);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PizzaProcessExists(int id)
        {
            return _context.PizzaProcesses.Any(e => e.Id == id);
        }
    }
}
