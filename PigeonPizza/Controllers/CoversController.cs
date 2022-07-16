﻿using System;
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
    public class CoversController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CoversController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Covers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PizzaBasicsCover>>> GetCovers()
        {
            return await _context.Covers.ToListAsync();
        }

        // GET: api/Covers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PizzaBasicsCover>> GetPizzaBasicsCover(int id)
        {
            var pizzaBasicsCover = await _context.Covers.FindAsync(id);

            if (pizzaBasicsCover == null)
            {
                return NotFound();
            }

            return pizzaBasicsCover;
        }

        // PUT: api/Covers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPizzaBasicsCover(int id, PizzaBasicsCover pizzaBasicsCover)
        {
            if (id != pizzaBasicsCover.Id)
            {
                return BadRequest();
            }

            _context.Entry(pizzaBasicsCover).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PizzaBasicsCoverExists(id))
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

        // POST: api/Covers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PizzaBasicsCover>> PostPizzaBasicsCover(PizzaBasicsCover pizzaBasicsCover)
        {
            _context.Covers.Add(pizzaBasicsCover);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPizzaBasicsCover), new { id = pizzaBasicsCover.Id }, pizzaBasicsCover);
        }

        // DELETE: api/Covers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePizzaBasicsCover(int id)
        {
            var pizzaBasicsCover = await _context.Covers.FindAsync(id);
            if (pizzaBasicsCover == null)
            {
                return NotFound();
            }

            _context.Covers.Remove(pizzaBasicsCover);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PizzaBasicsCoverExists(int id)
        {
            return _context.Covers.Any(e => e.Id == id);
        }
    }
}
