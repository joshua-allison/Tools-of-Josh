using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheDigitalToolbox.Models;

namespace TheDigitalToolbox.Controllers
{
    public class EmbeddedController : Controller
    {
        private ITheDigitalToolBoxDBUnitOfWork data { get; set; }
        public EmbeddedController(ITheDigitalToolBoxDBUnitOfWork unit) => data = unit;

        public IEnumerable<Embedded> addDBListsToViewBag()
        {
            // Theres a lot of entities related to equipment that need to be added to the ViewBag
            // so it makes sense to just write a function that just loads them all up at once, so I don't have to keep writing it out.
            ViewBag.Comments = data.Comments.List(new QueryOptions<Comment> { OrderBy = c => c.CommentId });
            ViewBag.Embeddeds = data.Embeddeds.List(new QueryOptions<Embedded> { OrderBy = e => e.EmbeddedId });
            ViewBag.Users = data.Users.List(new QueryOptions<User> { OrderBy = u => u.Lastname });

            //Once I have all the DBSets, I can add them to an IEnumerable and return them to the calling function.
            var Embeddeds = data.Embeddeds.List(new QueryOptions<Embedded> { OrderBy = e => e.EmbeddedId });
            return Embeddeds;
        }

        // GET: EmbeddedController
        public ActionResult Index()
        {
            var Embeddeds = addDBListsToViewBag();
            return View(Embeddeds);
        }

        // GET: EmbeddedController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            ViewBag.Action = "Details";
            var embedded = await data.Embeddeds.GetAsync(id);
            return View(embedded);
        }

        // GET: EmbeddedController/Create
        public ActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit", new Embedded());
        }

        // POST: EmbeddedController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmbeddedController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Embedded embedded)
        {
            if (ModelState.IsValid)
            {
                if (embedded.EmbeddedId == 0)
                {
                    data.Embeddeds.InsertAsync(embedded);
                }
                else
                {
                    data.Embeddeds.Update(embedded);
                }
                data.SaveAsync();
                return RedirectToAction("Embedded", "Index");
            }
            else
            {
                ViewBag.Action = (embedded.EmbeddedId == 0) ? "Add" : "Edit";
                data.SaveAsync();
                addDBListsToViewBag();
                return View(embedded);
            }
        }

        // GET: EmbeddedController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmbeddedController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
