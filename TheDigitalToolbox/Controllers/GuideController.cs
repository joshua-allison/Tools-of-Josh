using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheDigitalToolbox.Controllers
{
    public class GuideController : Controller
    {
        // GET: GuideController
        public ActionResult Index()
        {
            return View();
        }

        // GET: GuideController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GuideController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GuideController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: GuideController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GuideController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: GuideController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GuideController/Delete/5
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
