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
    public class ViewProductsController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public ViewProductsController(ApplicationDbContext context)
        {
            dbContext = context;
        }

        // GET: ViewProducts
        public async Task<IActionResult> Index()
        {
              return dbContext.Products != null ?
                          View(await dbContext.Products.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Products'  is null.");
        }

        // GET: ViewProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || dbContext.Products == null)
            {
                return NotFound();
            }

            var product = await dbContext.Products
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: ViewProducts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ViewProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductID,ProductName,ProductDescription,Price,ProductType,Quantity")] Product product)
        {
            if (ModelState.IsValid)
            {
                dbContext.Add(product);
                await dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: ViewProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || dbContext.Products == null)
            {
                return NotFound();
            }

            var product = await dbContext.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: ViewProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductID,ProductName,ProductDescription,Price,ProductType,Quantity")] Product product)
        {
            if (id != product.ProductID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    dbContext.Update(product);
                    await dbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductID))
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
            return View(product);
        }

        // GET: ViewProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || dbContext.Products == null)
            {
                return NotFound();
            }

            var product = await dbContext.Products
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: ViewProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (dbContext.Products == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Products'  is null.");
            }
            var product = await dbContext.Products.FindAsync(id);
            if (product != null)
            {
                dbContext.Products.Remove(product);
            }
            await dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
          return (dbContext.Products?.Any(e => e.ProductID == id)).GetValueOrDefault();
        }
    }
}
