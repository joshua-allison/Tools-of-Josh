using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheDigitalToolbox.Models;

namespace TheDigitalToolbox.Controllers
{
    public class EmbeddedsController : Controller
    {
        private readonly ToolboxContext _context;

        public EmbeddedsController(ToolboxContext context)
        {
            _context = context;
        }

        // GET: Embeddeds
        public async Task<IActionResult> Index()
        {
            return View(await _context.Embeds.ToListAsync());
        }

        // GET: Embeddeds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var embedded = await _context.Embeds
                .FirstOrDefaultAsync(m => m.EmbeddedId == id);
            if (embedded == null)
            {
                return NotFound();
            }

            return View(embedded);
        }

        // GET: Embeddeds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Embeddeds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmbeddedId,EmbedString,Creator,Title,Description,ShareURL")] Embedded embedded)
        {
            if (ModelState.IsValid)
            {
                _context.Add(embedded);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(embedded);
        }

        // GET: Embeddeds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var embedded = await _context.Embeds.FindAsync(id);
            if (embedded == null)
            {
                return NotFound();
            }
            return View(embedded);
        }

        // POST: Embeddeds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmbeddedId,EmbedString,Creator,Title,Description,ShareURL")] Embedded embedded)
        {
            if (id != embedded.EmbeddedId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(embedded);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmbeddedExists(embedded.EmbeddedId))
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
            return View(embedded);
        }

        // GET: Embeddeds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var embedded = await _context.Embeds
                .FirstOrDefaultAsync(m => m.EmbeddedId == id);
            if (embedded == null)
            {
                return NotFound();
            }

            return View(embedded);
        }

        // POST: Embeddeds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var embedded = await _context.Embeds.FindAsync(id);
            _context.Embeds.Remove(embedded);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmbeddedExists(int id)
        {
            return _context.Embeds.Any(e => e.EmbeddedId == id);
        }
    }
}
