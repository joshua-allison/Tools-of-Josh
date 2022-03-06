using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using TheDigitalToolbox.Models;

namespace TheDigitalToolbox.Controllers
{
    public class ControllerHelpers : Controller
    {

        //This is a place where I can store the headers of my controllers.
        private ITheDigitalToolBoxDBUnitOfWork data { get; set; }
        public ControllerHelpers(ITheDigitalToolBoxDBUnitOfWork unit) => data = unit;
        public void LoadViewBag()
        {
            //Theres a lot of entities related to equipment that need to be added to the ViewBag, so it makes sense to just write a function that just loads them all up at once, so I don't have to keep writing it out.
            ViewBag.Comments = data.Comments.List(new QueryOptions<Comment> { OrderBy = c => c.CommentId });
            ViewBag.Embeddeds = data.Embeddeds.List(new QueryOptions<Embedded> { OrderBy = e => e.EmbeddedId });
            ViewBag.Guides = data.Guides.List(new QueryOptions<Guide> { OrderBy = g => g.GuideId });
            ViewBag.HelpfulLinks = data.HelpfulLinks.List(new QueryOptions<HelpfulLink> { OrderBy = h => h.HelpfulLinkId });
            ViewBag.Macros = data.Macros.List(new QueryOptions<Macro> { OrderBy = m => m.MacroId });
            ViewBag.Programs = data.Programs.List(new QueryOptions<TheDigitalToolbox.Models.Program> { OrderBy = p => p.ProgramId });
            ViewBag.Users = data.Users.List(new QueryOptions<User> { OrderBy = u => u.Lastname });
            return;
        }
    }
}
