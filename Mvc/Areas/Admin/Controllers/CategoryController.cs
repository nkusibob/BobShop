using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc.Models;
using System.Data.Entity;

namespace Mvc.Areas.Admin.Controllers
{
    
    public class CategoryController : Controller
    {
        vendrEntities dc = new vendrEntities();
        //
        // GET: /Category/
        
        public ActionResult Index()
        {
            var cats = dc.Categories.ToList();
            return View(cats);
        }

        //
        // GET: /Category/Details/5

        public ActionResult Details(int id)
        {
            var cat = dc.Categories.Find(id);
            if (cat == null)
                return RedirectToAction("Index");

            return View(cat);
        }

       // cela empeche l'utilisateur de creer des nouvelles categories
        // GET: /Category/Create

        public ActionResult Create()
        {
            
            var media = dc.Media.Where(m => m.MediaType.MediaTypeName == "image").ToList();
            ViewBag.medium = new SelectList(media, "MediaID", "MediaName", null);
            
            return View();
        }

        //
        // POST: /Category/Create
       
        [HttpPost]
        public ActionResult Create(FormCollection collection, Category cat)
        {
            try
            {
                // TODO: Add insert logic here
                dc.Categories.Add(cat);
                dc.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                throw e;
               
            }
        }

        //
        // GET: /Category/Edit/5

        public ActionResult Edit(int id)
        {
            var cat = dc.Categories.Find(id);

            if (cat == null)
                return RedirectToAction("Index");

            return View(cat);
        }

        //
        // POST: /Category/Edit/5

        [HttpPost]
        public ActionResult Edit(Category cat, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                dc.Entry<Category>(cat).State = EntityState.Modified;

                dc.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Index");
            }
        }

        //
        // GET: /Category/Delete/5

        public ActionResult Delete(int id)
        {
            var cat = dc.Categories.Find(id);

            if (cat == null)
                return RedirectToAction("Index");

            return View(cat);
        }

        //
        // POST: /Category/Delete/5

        [HttpPost]
        public ActionResult Delete(Category cat, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                dc.Entry<Category>(cat).State = EntityState.Deleted;

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
