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
    public class PublishRecipesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PublishRecipesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/PublishRecipes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublishRecipe>>> GetPublishReceipes()
        {
            return await _context.PublishReceipes.ToListAsync();
        }

        // GET: api/PublishRecipes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublishRecipe>> GetPublishRecipe(int id)
        {
            var publishRecipe = await _context.PublishReceipes.FindAsync(id);

            if (publishRecipe == null)
            {
                return NotFound();
            }

            return publishRecipe;
        }

        // PUT: api/PublishRecipes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPublishRecipe(int id, PublishRecipe publishRecipe)
        {
            if (id != publishRecipe.Id)
            {
                return BadRequest();
            }

            _context.Entry(publishRecipe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PublishRecipeExists(id))
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

        // POST: api/PublishRecipes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PublishRecipe>> PostPublishRecipe(PublishRecipe publishRecipe)
        {
            _context.PublishReceipes.Add(publishRecipe);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPublishRecipe), new { id = publishRecipe.Id }, publishRecipe);
        }

        // DELETE: api/PublishRecipes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePublishRecipe(int id)
        {
            var publishRecipe = await _context.PublishReceipes.FindAsync(id);
            if (publishRecipe == null)
            {
                return NotFound();
            }

            _context.PublishReceipes.Remove(publishRecipe);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PublishRecipeExists(int id)
        {
            return _context.PublishReceipes.Any(e => e.Id == id);
        }
    }
}
