﻿using System;
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
    public class TaskEntitiesController : Controller
    {
        private SystemContext db = new SystemContext();

        // GET: TaskEntities
        public ActionResult Index()
        {
            return View(db.Tasks.ToList());
        }

        // GET: TaskEntities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskEntity taskEntity = db.Tasks.Find(id);
            if (taskEntity == null)
            {
                return HttpNotFound();
            }
            return View(taskEntity);
        }

        // GET: TaskEntities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TaskEntities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TaskID,Title,Discription,MaxScore")] TaskEntity taskEntity)
        {
            if (ModelState.IsValid)
            {
                db.Tasks.Add(taskEntity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(taskEntity);
        }

        // GET: TaskEntities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskEntity taskEntity = db.Tasks.Find(id);
            if (taskEntity == null)
            {
                return HttpNotFound();
            }
            return View(taskEntity);
        }

        // POST: TaskEntities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TaskID,Title,Discription,MaxScore")] TaskEntity taskEntity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(taskEntity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(taskEntity);
        }

        // GET: TaskEntities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskEntity taskEntity = db.Tasks.Find(id);
            if (taskEntity == null)
            {
                return HttpNotFound();
            }
            return View(taskEntity);
        }

        // POST: TaskEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TaskEntity taskEntity = db.Tasks.Find(id);
            db.Tasks.Remove(taskEntity);
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
