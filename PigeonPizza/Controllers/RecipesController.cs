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
    public class RecipesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RecipesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Recipes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PizzaRecipe>>> GetPizzaRecipes()
        {
            return await _context.PizzaRecipes
                .Include(x => x.Dough)
                .Include(x => x.Publish)
                .Include(x => x.Tasks)
                .ThenInclude(t => t.Element)
                .ToListAsync();
        }

        // GET: api/Recipes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PizzaRecipe>> GetPizzaRecipe(int id)
        {
            //var pizzaRecipe = await _context.PizzaRecipes.FindAsync(id);
            var pizzaRecipe = await _context.PizzaRecipes
                .Include(x => x.Dough)
                .Include(x => x.Publish)
                .Include(x => x.Tasks)
                .ThenInclude(t => t.Element)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (pizzaRecipe == null)
            {
                return NotFound();
            }

            return pizzaRecipe;
        }

        // PUT: api/Recipes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPizzaRecipe(int id, PizzaRecipe pizzaRecipe)
        {
            if (id != pizzaRecipe.Id)
            {
                return BadRequest();
            }

            _context.Entry(pizzaRecipe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PizzaRecipeExists(id))
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

        // POST: api/Recipes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PizzaRecipe>> PostPizzaRecipe(PizzaRecipe pizzaRecipe)
        {
            _context.PizzaRecipes.Add(pizzaRecipe);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPizzaRecipe), new { id = pizzaRecipe.Id }, pizzaRecipe);
        }

        // DELETE: api/Recipes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePizzaRecipe(int id)
        {
            var pizzaRecipe = await _context.PizzaRecipes.FindAsync(id);
            if (pizzaRecipe == null)
            {
                return NotFound();
            }

            _context.PizzaRecipes.Remove(pizzaRecipe);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PizzaRecipeExists(int id)
        {
            return _context.PizzaRecipes.Any(e => e.Id == id);
        }
    }
}
