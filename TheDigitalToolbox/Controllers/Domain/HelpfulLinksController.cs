using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheDigitalToolbox.Models;

namespace TheDigitalToolbox.Controllers.Domain
{
    public class HelpfulLinksController : Controller
    {
        private readonly ToolboxContext _context;

        public HelpfulLinksController(ToolboxContext context)
        {
            _context = context;
        }

        // GET: HelpfulLinks
        public async Task<IActionResult> Index()
        {
            return View(await _context.HelpfulLinks.ToListAsync());
        }

        // GET: HelpfulLinks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var helpfulLink = await _context.HelpfulLinks
                .FirstOrDefaultAsync(m => m.ToolId == id);
            if (helpfulLink == null)
            {
                return NotFound();
            }

            return View(helpfulLink);
        }

        // GET: HelpfulLinks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HelpfulLinks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Subject,ToolId,Creator,ShareURL,Title,Description")] HelpfulLink helpfulLink)
        {
            if (ModelState.IsValid)
            {
                _context.Add(helpfulLink);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(helpfulLink);
        }

        // GET: HelpfulLinks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var helpfulLink = await _context.HelpfulLinks.FindAsync(id);
            if (helpfulLink == null)
            {
                return NotFound();
            }
            return View(helpfulLink);
        }

        // POST: HelpfulLinks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Subject,ToolId,Creator,ShareURL,Title,Description")] HelpfulLink helpfulLink)
        {
            if (id != helpfulLink.ToolId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(helpfulLink);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HelpfulLinkExists(helpfulLink.ToolId))
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
            return View(helpfulLink);
        }

        // GET: HelpfulLinks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var helpfulLink = await _context.HelpfulLinks
                .FirstOrDefaultAsync(m => m.ToolId == id);
            if (helpfulLink == null)
            {
                return NotFound();
            }

            return View(helpfulLink);
        }

        // POST: HelpfulLinks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var helpfulLink = await _context.HelpfulLinks.FindAsync(id);
            _context.HelpfulLinks.Remove(helpfulLink);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HelpfulLinkExists(int id)
        {
            return _context.HelpfulLinks.Any(e => e.ToolId == id);
        }
    }
}
