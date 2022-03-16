using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheDigitalToolbox.Models;

namespace TheDigitalToolbox.Controllers.Domain
{
    public class EmbedsController : Controller
    {
        private readonly ToolboxContext _context;
        private IHttpContextAccessor _accessor { get; set; }
        private ITheDigitalToolBoxDBUnitOfWork _data { get; set; }
        public EmbedsController(ToolboxContext context, IHttpContextAccessor accessor, ITheDigitalToolBoxDBUnitOfWork data)
        {
            _context = context;
            _accessor = accessor;
            _data = data;
        }

        // GET: Embeds
        public async Task<IActionResult> Index()
        {
            return View(await _context.Embeds.ToListAsync());
        }

        // GET: Embeds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var embed = await _context.Embeds
                .Include(m => m.User)
                .Include(m => m.Comments)
                .FirstOrDefaultAsync(m => m.ToolId == id);

            ViewBag.Tool = embed;

            if (embed == null)
                return NotFound();

            return View(embed);
        }

        // GET: Embeds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Embeds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("User,iFrameString,ToolId,Creator,ShareURL,Title,Description")] Embed embed)
        {
            if (ModelState.IsValid)
            {
                // Get the current logged-in user (the one creating the tool), and assign them to the tool.
                embed.User = await _context.Users.FindAsync(_accessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
                // Add the embedded object to the context and save.
                _context.Add(embed);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(embed);
        }

        // GET: Embeds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var embed = await _context.Embeds.FindAsync(id);

            if (embed == null)
                return NotFound();

            return View(embed);
        }

        // POST: Embeds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("iFrameString,ToolId,Creator,ShareURL,Title,Description")] Embed embed)
        {
            if (id != embed.ToolId)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(embed);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmbedExists(embed.ToolId))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(embed);
        }

        // GET: Embeds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var embed = await _context.Embeds
                .FirstOrDefaultAsync(m => m.ToolId == id);

            if (embed == null)
                return NotFound();

            return View(embed);
        }

        // POST: Embeds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var embed = await _context.Embeds.FindAsync(id);
            _context.Embeds.Remove(embed);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmbedExists(int id)
        {
            return _context.Embeds.Any(e => e.ToolId == id);
        }
    }
}
