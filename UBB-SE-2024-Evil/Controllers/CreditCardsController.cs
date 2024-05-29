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
    public class CreditCardsController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public CreditCardsController(ApplicationDbContext context)
        {
            this.context = context;
        }

        // GET: api/CreditCards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CreditCard>>> GetCreditCard()
        {
            if (context.CreditCard == null)
            {
                return NotFound();
            }
            return await context.CreditCard.ToListAsync();
        }

        // GET: api/CreditCards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CreditCard>> GetCreditCard(int id)
        {
            if (context.CreditCard == null)
            {
                return NotFound();
            }
            var creditCard = await context.CreditCard.FindAsync(id);

            if (creditCard == null)
            {
                return NotFound();
            }

            return creditCard;
        }

        // PUT: api/CreditCards/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCreditCard(int id, CreditCard creditCard)
        {
            if (id != creditCard.Id)
            {
                return BadRequest();
            }

            context.Entry(creditCard).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CreditCardExists(id))
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

        // POST: api/CreditCards
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CreditCard>> PostCreditCard(CreditCard creditCard)
        {
            if (context.CreditCard == null)
            {
                return Problem("Entity set 'ApplicationDbContext.CreditCard'  is null.");
            }
            context.CreditCard.Add(creditCard);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetCreditCard", new { id = creditCard.Id }, creditCard);
        }

        // DELETE: api/CreditCards/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCreditCard(int id)
        {
            if (context.CreditCard == null)
            {
                return NotFound();
            }
            var creditCard = await context.CreditCard.FindAsync(id);
            if (creditCard == null)
            {
                return NotFound();
            }

            context.CreditCard.Remove(creditCard);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool CreditCardExists(int id)
        {
            return (context.CreditCard?.Any(element => element.Id == id)).GetValueOrDefault();
        }
    }
}
