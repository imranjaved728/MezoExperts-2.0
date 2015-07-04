using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MezoExperts.Models;

namespace MezoExperts.Controllers
{
    public class ReplyController : Controller
    {
        private DBEntities db = new DBEntities();

        //
        // GET: /Reply/

        public ActionResult Index(int QuestionId)
        {
            var replies = db.Replies.Include(r => r.Question).Where(r=>r.QuestionId==QuestionId);
            return View(replies.ToList());
        }

        //
        // GET: /Reply/Details/5

        public ActionResult Details(int id = 0)
        {
            Reply reply = db.Replies.Find(id);
            if (reply == null)
            {
                return HttpNotFound();
            }
            return View(reply);
        }

        //
        // GET: /Reply/Create

        public ActionResult Create()
        {
            ViewBag.QuestionId = new SelectList(db.Questions, "Id", "Details");
            return View();
        }

        //
        // POST: /Reply/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Reply reply)
        {
            if (ModelState.IsValid)
            {
                db.Replies.Add(reply);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.QuestionId = new SelectList(db.Questions, "Id", "Details", reply.QuestionId);
            return View(reply);
        }

        
        //
        // GET: /Reply/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Reply reply = db.Replies.Find(id);
            if (reply == null)
            {
                return HttpNotFound();
            }
            return View(reply);
        }

        //
        // POST: /Reply/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reply reply = db.Replies.Find(id);
            db.Replies.Remove(reply);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}