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
    public class QuestionAnswerEntitiesController : Controller
    {
        private SystemContext db = new SystemContext();

        // GET: QuestionAnswerEntities
        public ActionResult Index()
        {
            var questionAnswers = db.QuestionAnswers.Include(q => q.Question);
            return View(questionAnswers.ToList());
        }

        // GET: QuestionAnswerEntities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionAnswerEntity questionAnswerEntity = db.QuestionAnswers.Find(id);
            if (questionAnswerEntity == null)
            {
                return HttpNotFound();
            }
            return View(questionAnswerEntity);
        }

        // GET: QuestionAnswerEntities/Create
        public ActionResult Create()
        {
            ViewBag.QuestionID = new SelectList(db.Questions, "QuestionID", "Title");
            return View();
        }

        // POST: QuestionAnswerEntities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AnswerID,Title,QuestionID")] QuestionAnswerEntity questionAnswerEntity)
        {
            if (ModelState.IsValid)
            {
                db.QuestionAnswers.Add(questionAnswerEntity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.QuestionID = new SelectList(db.Questions, "QuestionID", "Title", questionAnswerEntity.QuestionID);
            return View(questionAnswerEntity);
        }

        // GET: QuestionAnswerEntities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionAnswerEntity questionAnswerEntity = db.QuestionAnswers.Find(id);
            if (questionAnswerEntity == null)
            {
                return HttpNotFound();
            }
            ViewBag.QuestionID = new SelectList(db.Questions, "QuestionID", "Title", questionAnswerEntity.QuestionID);
            return View(questionAnswerEntity);
        }

        // POST: QuestionAnswerEntities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AnswerID,Title,QuestionID")] QuestionAnswerEntity questionAnswerEntity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(questionAnswerEntity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.QuestionID = new SelectList(db.Questions, "QuestionID", "Title", questionAnswerEntity.QuestionID);
            return View(questionAnswerEntity);
        }

        // GET: QuestionAnswerEntities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionAnswerEntity questionAnswerEntity = db.QuestionAnswers.Find(id);
            if (questionAnswerEntity == null)
            {
                return HttpNotFound();
            }
            return View(questionAnswerEntity);
        }

        // POST: QuestionAnswerEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QuestionAnswerEntity questionAnswerEntity = db.QuestionAnswers.Find(id);
            db.QuestionAnswers.Remove(questionAnswerEntity);
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
