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
    public class BalanceController : Controller
    {
        private BalanceDbContext db = new BalanceDbContext();

        // GET: Balance
        public ActionResult Index()
        {
            return View(db.Balances.ToList());
        }

        // GET: Balance/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BalanceModel balanceModel = db.Balances.Find(id);
            if (balanceModel == null)
            {
                return HttpNotFound();
            }
            return View(balanceModel);
        }

        // GET: Balance/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Balance/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,User,Vestiging,Balance,Date")] BalanceModel balanceModel)
        {
            if (ModelState.IsValid)
            {
                db.Balances.Add(balanceModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(balanceModel);
        }

        // GET: Balance/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BalanceModel balanceModel = db.Balances.Find(id);
            if (balanceModel == null)
            {
                return HttpNotFound();
            }
            return View(balanceModel);
        }

        // POST: Balance/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,User,Vestiging,Balance,Date")] BalanceModel balanceModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(balanceModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(balanceModel);
        }

        // GET: Balance/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BalanceModel balanceModel = db.Balances.Find(id);
            if (balanceModel == null)
            {
                return HttpNotFound();
            }
            return View(balanceModel);
        }

        // POST: Balance/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            BalanceModel balanceModel = db.Balances.Find(id);
            db.Balances.Remove(balanceModel);
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

        public BalanceModel GetBalance(Vestiging vestiging, string username)
        {
            //if (User == null) return 0.0f;
            return (from b in db.Balances
                where b.Vestiging.Equals(vestiging.Id) && b.User.Equals(username)
                select b).FirstOrDefault();
        }

        public BalanceModel FindBalanceById(string id)
        {
            return db.Balances.Find(id);
        }

        public void UpdateBalance(BalanceModel balance, float amount)
        {
            balance.Balance += amount;
            balance.Date = DateTime.Now;
            if (int.Parse(balance.Id) < 0)
            {
                balance.Id = FindNewId();
                db.Balances.Add(balance);
            }
            else
            {
                db.Entry(balance).State = EntityState.Modified;
            }
            db.SaveChanges();
        }

        private string FindNewId()
        {
            var idToFind = 0;
            while (db.Balances.Find("" + idToFind) != null)
            {
                idToFind++;
            }
            return "" + idToFind;
        }

        public List<BalanceModel> GetBalancesByVestigingId(string vestigingId)
        {
            return db.Balances.Where(b => b.Vestiging.Equals(vestigingId)).ToList();
        }
    }
}
