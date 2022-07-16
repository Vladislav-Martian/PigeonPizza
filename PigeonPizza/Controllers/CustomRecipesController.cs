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
    public class CustomRecipesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CustomRecipesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/CustomRecipes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PizzaCustomRecipe>>> GetCustomRecipes()
        {
            return await _context.CustomRecipes
                .Include(x => x.Scale)
                .Include(x => x.Dough)
                .Include(x => x.Covers)
                .Include(x => x.Toppings)
                .Include(x => x.Works)
                .ToListAsync();
        }

        // GET: api/CustomRecipes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PizzaCustomRecipe>> GetPizzaCustomRecipe(int id)
        {
            var pizzaCustomRecipe = await _context.CustomRecipes.FindAsync(id);

            if (pizzaCustomRecipe == null)
            {
                return NotFound();
            }

            return pizzaCustomRecipe;
        }

        // PUT: api/CustomRecipes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPizzaCustomRecipe(int id, PizzaCustomRecipe pizzaCustomRecipe)
        {
            if (id != pizzaCustomRecipe.Id)
            {
                return BadRequest();
            }

            _context.Entry(pizzaCustomRecipe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PizzaCustomRecipeExists(id))
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

        // POST: api/CustomRecipes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PizzaCustomRecipe>> PostPizzaCustomRecipe(PizzaCustomRecipe pizzaCustomRecipe)
        {
            _context.CustomRecipes.Add(pizzaCustomRecipe);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPizzaCustomRecipe), new { id = pizzaCustomRecipe.Id }, pizzaCustomRecipe);
        }

        // DELETE: api/CustomRecipes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePizzaCustomRecipe(int id)
        {
            var pizzaCustomRecipe = await _context.CustomRecipes.FindAsync(id);
            if (pizzaCustomRecipe == null)
            {
                return NotFound();
            }

            _context.CustomRecipes.Remove(pizzaCustomRecipe);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PizzaCustomRecipeExists(int id)
        {
            return _context.CustomRecipes.Any(e => e.Id == id);
        }
    }
}
