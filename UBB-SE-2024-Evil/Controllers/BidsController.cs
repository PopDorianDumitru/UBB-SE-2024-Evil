using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UBB_SE_2024_Evil.Data;
using UBB_SE_2024_Evil.Models;

namespace UBB_SE_2024_Evil.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BidsController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public BidsController(ApplicationDbContext context)
        {
            dbContext = context;
        }

        // GET: api/Bids
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bid>>> GetBids()
        {
            return await dbContext.Bids.ToListAsync();
        }

        // GET: api/Bids/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bid>> GetBid(int id)
        {
            var bid = await dbContext.Bids.FindAsync(id);

            if (bid == null)
            {
                return NotFound();
            }

            return bid;
        }

        // PUT: api/Bids/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBid(int id, Bid bid)
        {
            if (id != bid.BidId)
            {
                return BadRequest();
            }

            dbContext.Entry(bid).State = EntityState.Modified;

            try
            {
                await dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BidExists(id))
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

        // POST: api/Bids
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Bid>> PostBid(Bid bid)
        {
            dbContext.Bids.Add(bid);
            await dbContext.SaveChangesAsync();

            return CreatedAtAction("GetBid", new { id = bid.BidId }, bid);
        }

        // DELETE: api/Bids/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBid(int id)
        {
            var bid = await dbContext.Bids.FindAsync(id);
            if (bid == null)
            {
                return NotFound();
            }

            dbContext.Bids.Remove(bid);
            await dbContext.SaveChangesAsync();

            return NoContent();
        }

        private bool BidExists(int id)
        {
            return dbContext.Bids.Any(e => e.BidId == id);
        }
    }
}
