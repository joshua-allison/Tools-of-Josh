using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TheDigitalToolbox.Models;

namespace TheDigitalToolbox.Controllers
{
    public class ControllerHelpers : Controller
    {

        //This is a place where I can store the headers of my controllers.
        //TODO 29 Delete the ControllerHelpers Controller after the model controllers have been created.
        private ITheDigitalToolBoxDBUnitOfWork data { get; set; }
        public ControllerHelpers(ITheDigitalToolBoxDBUnitOfWork unit) => data = unit;
        public void LoadViewBag(string operation)
        {
            //Theres a lot of entities related to equipment that need to be added to the ViewBag, so it makes sense to just write a function that just loads them all up at once, so I don't have to keep writing it out.
            ViewBag.Comments = data.Comments.List(new QueryOptions<Comment> { OrderBy = c => c.CommentId });
            ViewBag.Users = data.Users.List(new QueryOptions<User> { OrderBy = u => u.Lastname });

            ViewBag.Operation = operation;

            //Once I have all the DBSets, I can add them to an IEnumerable and return them to the calling function.
            var Embeddeds = data.Embeddeds.List(new QueryOptions<Embedded> { OrderBy = e => e.EmbeddedId });
            return;
        }
    }
}
