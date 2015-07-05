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
    public class QuestionController : Controller
    {
        private DBEntities db = new DBEntities();

        //
        // GET: /Question/

        public ActionResult Index()
        {
            if (User.IsInRole("Client"))
            {
                var questions = db.Questions.Include(q => q.Category).Where(q => q.PostedBy == WebSecurity.CurrentUserId);
                return View(questions.OrderByDescending(m => m.Time).ToList());
            }
            else
            {
                var questions = db.Questions.Include(q => q.Category);
                return View(questions.OrderByDescending(m => m.Time).ToList());
            }
        }

        //
        // GET: /Question/Details/5

        public ActionResult Details(int id = 0)
        {
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        //
        // GET: /Question/Create

        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Id");
            return View();
        }

        //
        // POST: /Question/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Question question, HttpPostedFileBase[] files)
        {
            question.Time = DateTime.Now;
            question.Status = "Pending";
            if (ModelState.IsValid)
            {
                db.Questions.Add(question);
                try
                {
                    db.SaveChanges();
                    if (!System.IO.Directory.Exists(Server.MapPath("~/UserFiles/Q" + question.Id)))
                    {
                        System.IO.Directory.CreateDirectory(Server.MapPath("~/UserFiles/Q" + question.Id));
                    }
                    foreach (HttpPostedFileBase file in files)
                    {
                        if (file != null)
                        {
                            string filename = System.IO.Path.GetFileName(file.FileName);
                            string path = System.IO.Path.Combine(
                                       Server.MapPath("~/UserFiles/Q" + question.Id), filename);

                            file.SaveAs(path);
                            QuestionFile qf = new QuestionFile();
                            qf.QuestionId = question.Id;
                            qf.Path = question.Id + "/" + filename;
                            db.QuestionFiles.Add(qf);
                            db.SaveChanges();
                        }
                    }
                }
                catch
                {
                    ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Id", question.CategoryId);
                    return View(question);
                }

                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Id", question.CategoryId);
            return View(question);
        }

        //
        // GET: /Question/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Id", question.CategoryId);
            return View(question);
        }

        //
        // POST: /Question/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Question question)
        {
            if (ModelState.IsValid)
            {
                db.Entry(question).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Id", question.CategoryId);
            return View(question);
        }

        //
        // GET: /Question/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        //
        // POST: /Question/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Question question = db.Questions.Find(id);
            db.Questions.Remove(question);
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