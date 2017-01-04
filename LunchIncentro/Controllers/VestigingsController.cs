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
    public class VestigingsController : Controller
    {
        private VestigingDbContext db = new VestigingDbContext();

        // GET: Vestigings
        public ActionResult Index()
        {
            return View(db.Vestigingen.ToList());
        }

        // GET: Vestigings/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vestiging vestiging = db.Vestigingen.Find(id);
            if (vestiging == null)
            {
                return HttpNotFound();
            }
            return View(vestiging);
        }

        // GET: Vestigings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vestigings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ManagerUser,Bunq,Image,StandardCost")] Vestiging vestiging)
        {
            if (ModelState.IsValid)
            {
                db.Vestigingen.Add(vestiging);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vestiging);
        }

        // GET: Vestigings/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vestiging vestiging = db.Vestigingen.Find(id);
            if (vestiging == null)
            {
                return HttpNotFound();
            }
            return View(vestiging);
        }

        // POST: Vestigings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ManagerUser,Bunq,Image,StandardCost")] Vestiging vestiging)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vestiging).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vestiging);
        }

        // GET: Vestigings/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vestiging vestiging = db.Vestigingen.Find(id);
            if (vestiging == null)
            {
                return HttpNotFound();
            }
            return View(vestiging);
        }

        // POST: Vestigings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Vestiging vestiging = db.Vestigingen.Find(id);
            db.Vestigingen.Remove(vestiging);
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


        public IEnumerable<Vestiging> GetVestigingen()
        {
            return from vestiging in db.Vestigingen select vestiging;
        }

        public IEnumerable<VestigingOverzicht> GetVestigingenWithBalance(string username)
        {
            var vs = from vestiging in db.Vestigingen select vestiging;
            var vestigingWithBalances = new List<VestigingOverzicht>();
            foreach (var vestiging in vs)
            {

                var control = DependencyResolver.Current.GetService<BalanceController>();
                var balance = control.GetBalance(vestiging, username) ?? new BalanceModel(0.0f, vestiging.Id);//find the balance for user and vestiging.
                vestigingWithBalances.Add(new VestigingOverzicht(vestiging, balance));
            }
            return vestigingWithBalances;
        }

        public IEnumerable<SelectListItem> VestigingSelectList()
        {
            return from s in GetVestigingen()
                   select new SelectListItem
                   {
                       Text = s.Name,
                       Value = s.Id
                   };
        }

        public Vestiging GetVestigingById(string vestigingId)
        {
            return db.Vestigingen.Find(vestigingId);
        }
    }
}
