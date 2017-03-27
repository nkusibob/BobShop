using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Mvc.Models;

namespace Mvc.Controllers
{
    public class AdressesController : Controller
    {
        private vendrEntities db = new vendrEntities();

        // GET: Adresses
        public ActionResult Index()
        {
            var adresses = db.Adresses.Include(a => a.Customer).Include(a => a.DeliverableCountry);
            return View(adresses.ToList());
        }

        // GET: Adresses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adress adress = db.Adresses.Find(id);
            if (adress == null)
            {
                return HttpNotFound();
            }
            return View(adress);
        }

        // GET: Adresses/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerLastName");
            ViewBag.DeliverableCountryID = new SelectList(db.DeliverableCountries, "DeliverableCountryID", "DeliverableCountryName");
            return View();
        }

        // POST: Adresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AdressID,AdressCompany,AdressLine1,AdressLine2,AdressZipCode,AdressType,AdressActive,DeliverableCountryID,CustomerID")] Adress adress)
        {
            if (ModelState.IsValid)
            {
                db.Adresses.Add(adress);
                db.SaveChanges();
                return RedirectToAction("Index","Manage");
            }

            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerLastName", adress.CustomerID);
            ViewBag.DeliverableCountryID = new SelectList(db.DeliverableCountries, "DeliverableCountryID", "DeliverableCountryName", adress.DeliverableCountryID);
            return View(adress);
        }

        // GET: Adresses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adress adress = db.Adresses.Find(id);
            if (adress == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerLastName", adress.CustomerID);
            ViewBag.DeliverableCountryID = new SelectList(db.DeliverableCountries, "DeliverableCountryID", "DeliverableCountryName", adress.DeliverableCountryID);
            return View(adress);
        }

        // POST: Adresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AdressID,AdressCompany,AdressLine1,AdressLine2,AdressZipCode,AdressType,AdressActive,DeliverableCountryID,CustomerID")] Adress adress)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adress).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Manage");
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerLastName", adress.CustomerID);
            ViewBag.DeliverableCountryID = new SelectList(db.DeliverableCountries, "DeliverableCountryID", "DeliverableCountryName", adress.DeliverableCountryID);
            return View(adress);
        }

        // GET: Adresses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adress adress = db.Adresses.Find(id);
            if (adress == null)
            {
                return HttpNotFound();
            }
            return View(adress);
        }

        // POST: Adresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Adress adress = db.Adresses.Find(id);
            db.Adresses.Remove(adress);
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
