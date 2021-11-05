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
    public class UserEntitiesController : Controller
    {
        private SystemContext db = new SystemContext();

        // GET: UserEntities
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: UserEntities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserEntity userEntity = db.Users.Find(id);
            if (userEntity == null)
            {
                return HttpNotFound();
            }
            return View(userEntity);
        }

        // GET: UserEntities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserEntities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,Login,Password,Admin,Manager")] UserEntity userEntity)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(userEntity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userEntity);
        }

        // GET: UserEntities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserEntity userEntity = db.Users.Find(id);
            if (userEntity == null)
            {
                return HttpNotFound();
            }
            return View(userEntity);
        }

        // POST: UserEntities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,Login,Password,Admin,Manager")] UserEntity userEntity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userEntity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userEntity);
        }

        // GET: UserEntities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserEntity userEntity = db.Users.Find(id);
            if (userEntity == null)
            {
                return HttpNotFound();
            }
            return View(userEntity);
        }

        // POST: UserEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserEntity userEntity = db.Users.Find(id);
            db.Users.Remove(userEntity);
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
