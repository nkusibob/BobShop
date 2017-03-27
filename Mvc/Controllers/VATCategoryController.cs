using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc.Models;
using System.Data.Entity;

namespace Mvc.Controllers
{
    public class VATCategoryController : Controller
    {
        vendrEntities dc = new vendrEntities();
        //
        // GET: /VATCategory/

        public ActionResult Index()
        {
            var vatcats = dc.VATCategories.ToList();
            return View(vatcats);
        }

        //
        // GET: /VATCategory/Details/5

        public ActionResult Details(int id)
        {
            var vatcat = dc.VATCategories.Find(id);
            if (vatcat == null)
                return RedirectToAction("Index");

            return View(vatcat);
        }

        //
        // GET: /VATCategory/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /VATCategory/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection,VATCategory vatcat)
        {
            try
            {
                // TODO: Add insert logic here
                dc.VATCategories.Add(vatcat);
                dc.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Index");
            }
        }

        //
        // GET: /VATCategory/Edit/5

        public ActionResult Edit(int id)
        {
            var vatcat = dc.VATCategories.Find(id);

            if (vatcat == null)
                return RedirectToAction("Index");

            return View(vatcat);
        }

        //
        // POST: /VATCategory/Edit/5

        [HttpPost]
        public ActionResult Edit(VATCategory vatcat, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                dc.Entry<VATCategory>(vatcat).State = EntityState.Modified;

                dc.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Index");
            }
        }

        //
        // GET: /VATCategory/Delete/5

        public ActionResult Delete(int id)
        {
            var vatcat = dc.VATCategories.Find(id);

            if (vatcat == null)
                return RedirectToAction("Index");

            return View(vatcat);
        }

        //
        // POST: /VATCategory/Delete/5

        [HttpPost]
        public ActionResult Delete(VATCategory vatcat, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                dc.Entry<VATCategory>(vatcat).State = EntityState.Deleted;

                dc.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
