using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UBB_SE_2024_Evil.Data;
using UBB_SE_2024_Evil.Models;

namespace UBB_SE_2024_Evil.Controllers.ViewControllers
{
    [Authorize]
    public class ViewBidsController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public ViewBidsController(ApplicationDbContext context)
        {
            dbContext = context;
        }

        // GET: ViewBids
        public async Task<IActionResult> Index()
        {
              return dbContext.Bids != null ?
                          View(await dbContext.Bids.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Bids'  is null.");
        }

        // GET: ViewBids/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || dbContext.Bids == null)
            {
                return NotFound();
            }

            var bid = await dbContext.Bids
                .FirstOrDefaultAsync(m => m.BidId == id);
            if (bid == null)
            {
                return NotFound();
            }

            return View(bid);
        }

        // GET: ViewBids/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ViewBids/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BidId,BidSum,TimeOfBid")] Bid bid)
        {
            // bid.TimeOfBid = DateTime.Now;
            if (ModelState.IsValid)
            {
                dbContext.Add(bid);
                await dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bid);
        }

        // GET: ViewBids/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || dbContext.Bids == null)
            {
                return NotFound();
            }

            var bid = await dbContext.Bids.FindAsync(id);
            if (bid == null)
            {
                return NotFound();
            }
            return View(bid);
        }

        // POST: ViewBids/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BidId,BidSum,TimeOfBid")] Bid bid)
        {
            if (id != bid.BidId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    dbContext.Update(bid);
                    await dbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BidExists(bid.BidId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(bid);
        }

        // GET: ViewBids/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || dbContext.Bids == null)
            {
                return NotFound();
            }

            var bid = await dbContext.Bids
                .FirstOrDefaultAsync(m => m.BidId == id);
            if (bid == null)
            {
                return NotFound();
            }

            return View(bid);
        }

        // POST: ViewBids/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (dbContext.Bids == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Bids'  is null.");
            }
            var bid = await dbContext.Bids.FindAsync(id);
            if (bid != null)
            {
                dbContext.Bids.Remove(bid);
            }
            await dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BidExists(int id)
        {
          return (dbContext.Bids?.Any(e => e.BidId == id)).GetValueOrDefault();
        }
    }
}
