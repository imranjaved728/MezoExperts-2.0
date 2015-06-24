using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MezoExperts.Controllers
{
    public class ExpertController : Controller
    {
        //
        // GET: /Expert/

        public ActionResult Index()
        {
            return View("Profile");
        }

        //
        // GET: /Expert/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Expert/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Expert/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Expert/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Expert/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Expert/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Expert/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
