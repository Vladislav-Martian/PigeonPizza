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
    public class OfficialRecipesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OfficialRecipesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/OfficialRecipes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PizzaOfficialRecipe>>> GetOfficialRecipes()
        {
            return await _context.OfficialRecipes
                .Include(x => x.Scale)
                .Include(x => x.Dough)
                .Include(x => x.Covers)
                .Include(x => x.Toppings)
                .Include(x => x.Works)
                .ToListAsync();
        }

        // GET: api/OfficialRecipes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PizzaOfficialRecipe>> GetPizzaOfficialRecipe(int id)
        {
            var pizzaOfficialRecipe = await _context.OfficialRecipes.FindAsync(id);

            if (pizzaOfficialRecipe == null)
            {
                return NotFound();
            }

            return pizzaOfficialRecipe;
        }

        // PUT: api/OfficialRecipes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPizzaOfficialRecipe(int id, PizzaOfficialRecipe pizzaOfficialRecipe)
        {
            if (id != pizzaOfficialRecipe.Id)
            {
                return BadRequest();
            }

            _context.Entry(pizzaOfficialRecipe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PizzaOfficialRecipeExists(id))
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

        // POST: api/OfficialRecipes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PizzaOfficialRecipe>> PostPizzaOfficialRecipe(PizzaOfficialRecipe pizzaOfficialRecipe)
        {
            _context.OfficialRecipes.Add(pizzaOfficialRecipe);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPizzaOfficialRecipe), new { id = pizzaOfficialRecipe.Id }, pizzaOfficialRecipe);
        }

        // DELETE: api/OfficialRecipes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePizzaOfficialRecipe(int id)
        {
            var pizzaOfficialRecipe = await _context.OfficialRecipes.FindAsync(id);
            if (pizzaOfficialRecipe == null)
            {
                return NotFound();
            }

            _context.OfficialRecipes.Remove(pizzaOfficialRecipe);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PizzaOfficialRecipeExists(int id)
        {
            return _context.OfficialRecipes.Any(e => e.Id == id);
        }
    }
}
