using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MezoExperts.Models;
using WebMatrix.WebData;

namespace MezoExperts.Controllers
{
    [Authorize(Roles="Client")]
    public class ClientController : Controller
    {
        private DBEntities db = new DBEntities();

        //
        // GET: /Client/Index/5
        [AllowAnonymous]
        public ActionResult Profile(int id = 0)
        {
            Client client = db.Clients.Where(c => c.LoginId == id).FirstOrDefault();
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        //
        // GET: /Client/Edit/5

        public ActionResult Edit()
        {
            Client client = db.Clients.Where(c=>c.LoginId==WebSecurity.CurrentUserId).FirstOrDefault();
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        //
        // POST: /Client/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(client);
        }

        //
        // GET: /Client/Delete/5
        /*
        public ActionResult Delete(int id = 0)
        {
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }
        

        //
        // POST: /Client/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = db.Clients.Find(id);
            db.Clients.Remove(client);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        */

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}