using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LunchIncentro.Models;

namespace LunchIncentro.Controllers
{
    public class MutationsController : Controller
    {
        private MutationDbContext db = new MutationDbContext();

        // GET: Mutations
        public ActionResult Index()
        {
            return View(db.Mutations.ToList());
        }

        // GET: Mutations/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MutationModel mutationModel = db.Mutations.Find(id);
            if (mutationModel == null)
            {
                return HttpNotFound();
            }
            return View(mutationModel);
        }

        // GET: Mutations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mutations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,User,Vestiging,Mutation,DateTime")] MutationModel mutationModel)
        {
            if (ModelState.IsValid)
            {
                db.Mutations.Add(mutationModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mutationModel);
        }

        // GET: Mutations/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MutationModel mutationModel = db.Mutations.Find(id);
            if (mutationModel == null)
            {
                return HttpNotFound();
            }
            return View(mutationModel);
        }

        // POST: Mutations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,User,Vestiging,Mutation,DateTime")] MutationModel mutationModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mutationModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mutationModel);
        }

        // GET: Mutations/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MutationModel mutationModel = db.Mutations.Find(id);
            if (mutationModel == null)
            {
                return HttpNotFound();
            }
            return View(mutationModel);
        }

        // POST: Mutations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            MutationModel mutationModel = db.Mutations.Find(id);
            db.Mutations.Remove(mutationModel);
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
