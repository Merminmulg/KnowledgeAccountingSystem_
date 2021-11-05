using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KnowledgeAccountingSystem_.DAL;
using KnowledgeAccountingSystem_.Models;

namespace KnowledgeAccountingSystem_.Controllers
{
    public class QuestionEntitiesController : Controller
    {
        private SystemContext db = new SystemContext();

        // GET: QuestionEntities
        public ActionResult Index()
        {
            var questions = db.Questions.Include(q => q.Task);
            return View(questions.ToList());
        }

        // GET: QuestionEntities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionEntity questionEntity = db.Questions.Find(id);
            if (questionEntity == null)
            {
                return HttpNotFound();
            }
            return View(questionEntity);
        }

        // GET: QuestionEntities/Create
        public ActionResult Create()
        {
            ViewBag.TaskID = new SelectList(db.Tasks, "TaskID", "Title");
            return View();
        }

        // POST: QuestionEntities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "QuestionID,Title,TaskID,RightAnswer")] QuestionEntity questionEntity)
        {
            if (ModelState.IsValid)
            {
                db.Questions.Add(questionEntity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TaskID = new SelectList(db.Tasks, "TaskID", "Title", questionEntity.TaskID);
            return View(questionEntity);
        }

        // GET: QuestionEntities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionEntity questionEntity = db.Questions.Find(id);
            if (questionEntity == null)
            {
                return HttpNotFound();
            }
            ViewBag.TaskID = new SelectList(db.Tasks, "TaskID", "Title", questionEntity.TaskID);
            return View(questionEntity);
        }

        // POST: QuestionEntities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "QuestionID,Title,TaskID,RightAnswer")] QuestionEntity questionEntity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(questionEntity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TaskID = new SelectList(db.Tasks, "TaskID", "Title", questionEntity.TaskID);
            return View(questionEntity);
        }

        // GET: QuestionEntities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionEntity questionEntity = db.Questions.Find(id);
            if (questionEntity == null)
            {
                return HttpNotFound();
            }
            return View(questionEntity);
        }

        // POST: QuestionEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QuestionEntity questionEntity = db.Questions.Find(id);
            db.Questions.Remove(questionEntity);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
