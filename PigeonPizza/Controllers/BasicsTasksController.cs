using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PigeonPizza.Contexts;
using PigeonPizza.Models.Complex;

namespace PigeonPizza.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasicsTasksController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BasicsTasksController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/BasicsTasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BasicsTask>>> GetBasicsTasks()
        {
            return await _context.BasicsTasks.ToListAsync();
        }

        // GET: api/BasicsTasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BasicsTask>> GetBasicsTask(int id)
        {
            var basicsTask = await _context.BasicsTasks.FindAsync(id);

            if (basicsTask == null)
            {
                return NotFound();
            }

            return basicsTask;
        }

        // PUT: api/BasicsTasks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBasicsTask(int id, BasicsTask basicsTask)
        {
            if (id != basicsTask.Id)
            {
                return BadRequest();
            }

            _context.Entry(basicsTask).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BasicsTaskExists(id))
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

        // POST: api/BasicsTasks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BasicsTask>> PostBasicsTask(BasicsTask basicsTask)
        {
            _context.BasicsTasks.Add(basicsTask);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBasicsTask), new { id = basicsTask.Id }, basicsTask);
        }

        // DELETE: api/BasicsTasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBasicsTask(int id)
        {
            var basicsTask = await _context.BasicsTasks.FindAsync(id);
            if (basicsTask == null)
            {
                return NotFound();
            }

            _context.BasicsTasks.Remove(basicsTask);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BasicsTaskExists(int id)
        {
            return _context.BasicsTasks.Any(e => e.Id == id);
        }
    }
}
