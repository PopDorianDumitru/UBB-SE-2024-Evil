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
    public class ViewAuctionsController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public ViewAuctionsController(ApplicationDbContext context)
        {
            dbContext = context;
        }

        // GET: ViewAuctions
        public async Task<IActionResult> Index()
        {
              return dbContext.Auctions != null ?
                          View(await dbContext.Auctions.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Auctions'  is null.");
        }

        // GET: ViewAuctions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || dbContext.Auctions == null)
            {
                return NotFound();
            }

            var auction = await dbContext.Auctions
                .FirstOrDefaultAsync(m => m.AuctionID == id);
            if (auction == null)
            {
                return NotFound();
            }

            return View(auction);
        }

        // GET: ViewAuctions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ViewAuctions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AuctionID,AuctionDescription,AuctionName,CurrentMaxSum,DateOfStart")] Auction auction)
        {
            if (true || ModelState.IsValid)
            {
                dbContext.Add(auction);
                await dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(auction);
        }

        // GET: ViewAuctions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || dbContext.Auctions == null)
            {
                return NotFound();
            }

            var auction = await dbContext.Auctions.FindAsync(id);
            if (auction == null)
            {
                return NotFound();
            }
            return View(auction);
        }

        // POST: ViewAuctions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AuctionID,AuctionDescription,AuctionName,CurrentMaxSum,DateOfStart")] Auction auction)
        {
            if (id != auction.AuctionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    dbContext.Update(auction);
                    await dbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuctionExists(auction.AuctionID))
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
            return View(auction);
        }

        // GET: ViewAuctions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || dbContext.Auctions == null)
            {
                return NotFound();
            }

            var auction = await dbContext.Auctions
                .FirstOrDefaultAsync(m => m.AuctionID == id);
            if (auction == null)
            {
                return NotFound();
            }

            return View(auction);
        }

        // POST: ViewAuctions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (dbContext.Auctions == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Auctions'  is null.");
            }
            var auction = await dbContext.Auctions.FindAsync(id);
            if (auction != null)
            {
                dbContext.Auctions.Remove(auction);
            }
            await dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AuctionExists(int id)
        {
          return (dbContext.Auctions?.Any(e => e.AuctionID == id)).GetValueOrDefault();
        }
    }
}
