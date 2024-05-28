using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UBB_SE_2024_Evil.Data;
using UBB_SE_2024_Evil.Models.Spartacus;

namespace UBB_SE_2024_Evil.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameSavesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GameSavesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/GameSaves
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameSave>>> GetGameSave()
        {
          if (_context.GameSave == null)
          {
              return NotFound();
          }
            return await _context.GameSave.ToListAsync();
        }

        // GET: api/GameSaves/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GameSave>> GetGameSave(int id)
        {
          if (_context.GameSave == null)
          {
              return NotFound();
          }
            var gameSave = await _context.GameSave.FindAsync(id);

            if (gameSave == null)
            {
                return NotFound();
            }

            return gameSave;
        }

        // PUT: api/GameSaves/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGameSave(int id, GameSave gameSave)
        {
            if (id != gameSave.Id)
            {
                return BadRequest();
            }

            _context.Entry(gameSave).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameSaveExists(id))
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

        // POST: api/GameSaves
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GameSave>> PostGameSave(GameSave gameSave)
        {
          if (_context.GameSave == null)
          {
              return Problem("Entity set 'ApplicationDbContext.GameSave'  is null.");
          }
            _context.GameSave.Add(gameSave);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGameSave", new { id = gameSave.Id }, gameSave);
        }

        // DELETE: api/GameSaves/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGameSave(int id)
        {
            if (_context.GameSave == null)
            {
                return NotFound();
            }
            var gameSave = await _context.GameSave.FindAsync(id);
            if (gameSave == null)
            {
                return NotFound();
            }

            _context.GameSave.Remove(gameSave);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GameSaveExists(int id)
        {
            return (_context.GameSave?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
