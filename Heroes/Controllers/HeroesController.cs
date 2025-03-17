using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Heroes.Data;
using Heroes.Models;

namespace Heroes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public HeroesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Heroes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Heroe>>> GetHeroes()
        {
            return await _context.Heroes.ToListAsync();
        }

        // GET: api/Heroes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Heroe>> GetHeroe(int id)
        {
            var heroe = await _context.Heroes.FindAsync(id);

            if (heroe == null)
            {
                return NotFound();
            }

            return heroe;
        }

        // PUT: api/Heroes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHeroe(int id, Heroe heroe)
        {
            if (id != heroe.Id)
            {
                return BadRequest();
            }

            _context.Entry(heroe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HeroeExists(id))
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

        // POST: api/Heroes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Heroe>> PostHeroe(Heroe heroe)
        {
            _context.Heroes.Add(heroe);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHeroe", new { id = heroe.Id }, heroe);
        }

        // DELETE: api/Heroes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHeroe(int id)
        {
            var heroe = await _context.Heroes.FindAsync(id);
            if (heroe == null)
            {
                return NotFound();
            }

            _context.Heroes.Remove(heroe);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HeroeExists(int id)
        {
            return _context.Heroes.Any(e => e.Id == id);
        }
    }
}
