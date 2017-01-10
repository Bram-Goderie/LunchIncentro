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
        private MutationsDbContext db = new MutationsDbContext();

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
            Mutation mutation = db.Mutations.Find(id);
            if (mutation == null)
            {
                return HttpNotFound();
            }
            return View(mutation);
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
        public ActionResult Create([Bind(Include = "Id,User,Vestiging,Amount,Balance,DateTime,PayPossibility,PayChoice")] Mutation mutation)
        {
            if (ModelState.IsValid)
            {
                db.Mutations.Add(mutation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mutation);
        }

        // GET: Mutations/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mutation mutation = db.Mutations.Find(id);
            if (mutation == null)
            {
                return HttpNotFound();
            }
            return View(mutation);
        }

        // POST: Mutations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,User,Vestiging,Amount,Balance,DateTime,PayPossibility,PayChoice")] Mutation mutation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mutation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mutation);
        }

        // GET: Mutations/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mutation mutation = db.Mutations.Find(id);
            if (mutation == null)
            {
                return HttpNotFound();
            }
            return View(mutation);
        }

        // POST: Mutations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Mutation mutation = db.Mutations.Find(id);
            db.Mutations.Remove(mutation);
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

        public void NewMutation(VestigingOverzicht vestigingOverzicht)
        {
            var mutation = new Mutation
            {
                Id = FindNewId(),
                DateTime = DateTime.Now,
                Vestiging = vestigingOverzicht.Vestiging.Id,
                Amount = vestigingOverzicht.PayAmount,
                Balance = vestigingOverzicht.Balance.Balance,
                User = vestigingOverzicht.Balance.User,
                PayChoice = vestigingOverzicht.PayChoice,
                PayPossibility = vestigingOverzicht.Possibility
            };

            if (!vestigingOverzicht.PayChoice.Equals(PayChoice.DirectPay))
            {
                DependencyResolver.Current.GetService<BalanceController>()
                    .UpdateBalance(vestigingOverzicht.Balance, vestigingOverzicht.PayAmount);
            }

            db.Mutations.Add(mutation);
            db.SaveChanges();
        }

        private string FindNewId()
        {
            var idToFind = 0;
            while (db.Mutations.Find("" + idToFind) != null)
            {
                idToFind++;
            }
            return "" + idToFind;
        }
    }
}
