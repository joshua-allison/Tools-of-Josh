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
        #region Controller Creation
        private IHttpContextAccessor http { get; set; }
        private ITheDigitalToolBoxDBUnitOfWork data { get; set; }
        public EmbeddedController(ITheDigitalToolBoxDBUnitOfWork rep, IHttpContextAccessor ctx)
        {
            data = rep;
            http = ctx;
        }
        #endregion Controller Creation
        #region Index & Details
        public ActionResult Index()                                                 // GET: EmbeddedController
        {
            var embeddeds = LoadViewBag("Index");
            return View(embeddeds);
        }
        
        public async Task<ActionResult> Details(int id)                     // GET: EmbeddedController/Details/5
        {
            ViewBag.Action = "Details";
            var embedded = await data.Embeddeds.GetAsync(id);
            return View(embedded);
        }
        #endregion Index & Details
        #region Create
        public ActionResult Create()                                                // GET: EmbeddedController/Create
        {
            LoadViewBag("Create");
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Embedded e)          // POST: EmbeddedController/Create
        {
            string operation = (e.EmbeddedId == 0) ? "Create" : "Update";
            if (ModelState.IsValid)
            {
                if (e.EmbeddedId == 0)
                    data.Embeddeds.Insert(e);
                else
                    data.Embeddeds.Update(e);
                data.Embeddeds.Save();


                // "Error: Session Not Configured"
                //string verb = (operation == "Create") ? "created" : "updated";
                //TempData["msg"] = $"{e.Title} {verb}";

                return GoToEmbeds();

            }
            else
            {
                LoadViewBag(operation);
                return View();
            }
        }
        #endregion Create
        #region Update
        public ActionResult Update(int id)                                      // GET: EmbeddedController/Update/5
        {
            LoadViewBag("Update");
            var e = GetEmbedded(id);
            return View("Create", e);
        }
        #endregion Update
        #region Remove
        public ActionResult Remove(int id)                                      // GET: EmbeddedController/Remove/5
        {
            var e = GetEmbedded(id);
            return View(e);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(Embedded e)  // POST: EmbeddedController/Remove/5
        {
            data.Embeddeds.Delete(e);
            data.Embeddeds.Save();
            return GoToEmbeds();
        }
        #endregion Remove
        #region Private Helper Methods
        public IEnumerable<Embedded> LoadViewBag(string operation)
        {
            ViewBag.Comments = data.Comments.List(new QueryOptions<Comment> { OrderBy = c => c.CommentId });
            ViewBag.Embeddeds = data.Embeddeds.List(new QueryOptions<Embedded> { OrderBy = e => e.EmbeddedId });
            ViewBag.Users = data.Users.List(new QueryOptions<User> { OrderBy = u => u.Lastname });

            ViewBag.Operation = operation;

            //Once I have all the DBSets, I can add them to an IEnumerable and return them to the calling function.
            var Embeddeds = data.Embeddeds.List(new QueryOptions<Embedded> { OrderBy = e => e.EmbeddedId });
            return Embeddeds;
        }
        
        private Embedded GetEmbedded(int id)
        {
            var embeddedOptions = new QueryOptions<Embedded>
            {
                Where = e => e.EmbeddedId == id
            };
            return data.Embeddeds.Get(embeddedOptions);
        }

        private RedirectToActionResult GoToEmbeds()
        {
            return RedirectToAction("Index", "Embedded");
        }
        #endregion Private Helper Methods
    }
}
