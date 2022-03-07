using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheDigitalToolbox.Models;

namespace TheDigitalToolbox.Controllers
{
    public class EmbeddedController : Controller
    {
        #region Controller Creation
        private IHttpContextAccessor accessor { get; set; }
        private ITheDigitalToolBoxDBUnitOfWork data { get; set; }
        public EmbeddedController(ITheDigitalToolBoxDBUnitOfWork rep, IHttpContextAccessor http)
        {
            data = rep;
            accessor = http;
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
        [Authorize]
        public ActionResult Create()                                                // GET: EmbeddedController/Create
        {
            LoadViewBag("Create");
            return View();
        }

        [HttpPost]
        [Authorize]
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


                string verb = (operation == "Create") ? "created" : "updated";
                //TempData["msg"] = $"{e.Title} {verb}";    // "Error: Session Not Configured"

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
        [Authorize]
        public ActionResult Update(int id)                                      // GET: EmbeddedController/Update/5
        {
            LoadViewBag("Update");
            var e = GetEmbedded(id);
            return View("Create", e);
        }
        #endregion Update
        #region Remove
        [Authorize(Roles = "Admin")]
        public ActionResult Remove(int id)                                      // GET: EmbeddedController/Remove/5
        {
            var e = GetEmbedded(id);
            return View(e);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(Embedded e)                          // POST: EmbeddedController/Remove/5
        {
            e = data.Embeddeds.Get(e.EmbeddedId);   // for notification message 

            data.Embeddeds.Delete(e);
            data.Embeddeds.Save();

            //TempData["msg"] = $"{e.Title} deleted";     // "Error: Session Not Configured"

            return GoToEmbeds();
        }
        #endregion Remove
        #region Private Helper Methods
        public IEnumerable<Embedded> LoadViewBag(string operation)
        {
            ViewBag.Users = data.Users.List(new QueryOptions<User> { OrderBy = u => u.Lastname });
            ViewBag.Comments = data.Comments.List(new QueryOptions<Comment> { OrderBy = c => c.CommentId });
            ViewBag.Embeddeds = data.Embeddeds.List(new QueryOptions<Embedded> { OrderBy = e => e.EmbeddedId });

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
