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
    public class MacrosController : Controller
    {
        private readonly ToolboxContext _context;

        public MacrosController(ToolboxContext context)
        {
            _context = context;
        }

        // GET: Macroes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Macros.ToListAsync());
        }

        // GET: Macroes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var macro = await _context.Macros
                .FirstOrDefaultAsync(m => m.ToolId == id);
            if (macro == null)
            {
                return NotFound();
            }

            return View(macro);
        }

        // GET: Macroes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Macroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("App,ToolId,Creator,ShareURL,Title,Description")] Macro macro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(macro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(macro);
        }

        // GET: Macroes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var macro = await _context.Macros.FindAsync(id);
            if (macro == null)
            {
                return NotFound();
            }
            return View(macro);
        }

        // POST: Macroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("App,ToolId,Creator,ShareURL,Title,Description")] Macro macro)
        {
            if (id != macro.ToolId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(macro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MacroExists(macro.ToolId))
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
            return View(macro);
        }

        // GET: Macroes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var macro = await _context.Macros
                .FirstOrDefaultAsync(m => m.ToolId == id);
            if (macro == null)
            {
                return NotFound();
            }

            return View(macro);
        }

        // POST: Macroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var macro = await _context.Macros.FindAsync(id);
            _context.Macros.Remove(macro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MacroExists(int id)
        {
            return _context.Macros.Any(e => e.ToolId == id);
        }
    }
}
