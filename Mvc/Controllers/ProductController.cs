using Mvc.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc.Controllers
{
   
    public class ProductController : Controller
    {
        //
        // GET: /Product/
     
        public ActionResult Index()
        {
            var prods = dc.Categories.ToList();

            return View(prods);
        }

        //
        // GET: /Product/
        vendrEntities dc = new vendrEntities();
 
        public ActionResult Details(int id)
        {
           
            var prod = dc.Products.Find(id);
           
            prod.Medium = dc.Media.Where(x => x.ProductMedias.FirstOrDefault().ProductID == prod.ProductID).ToList();
            if (prod == null)
                return RedirectToAction("Index", "Home");
            return View(prod);
        }

        //
        //GET: /Product/Browse?
        public ActionResult Browse(string searchString)
        {
            var products = from p in dc.Products
                         select p;
         
            foreach (var p in products)

            {
                p.Medium = dc.Media.Where(x => x.ProductMedias.FirstOrDefault().ProductID == p.ProductID).ToList();

            }
            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.ProductName.Contains(searchString));



            }
           
            return View(products);
        }
        
       // Create
      //  GET
       [Authorize]
        public ActionResult Create()
        {
            ViewBag.Categories = new SelectList(dc.Categories.ToList(), "CategoryID", "CategoryName",null);
            ViewBag.VATCategories = new SelectList(dc.VATCategories.ToList(), "VATCategoryID", "VATCategoryName", null);
            ViewBag.UnitTypes = new SelectList(dc.UnitTypes.ToList(), "UnitTypeID", "UnitTypeName", null);
            ViewBag.MediaTypes = new SelectList(dc.MediaTypes.ToList(), "MediaTypeID", "MediaTypeName", null);
            var prod = new Product();
            prod.ProductAddingDate = DateTime.Now.Date;
            return View(prod);
        }
        [Authorize]
        //POST
        [HttpPost]
        public ActionResult Create(Product prod)
        {
            dc.Products.Add(prod);
            dc.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        
        
        //Delete
        //GET
        public ActionResult Delete(int id)
        {

            var prod= dc.Products.Find(id);

            if (prod == null)
                return RedirectToAction("Index", "Home"); 

            return View(prod);

        }
        //
        //POST
        [HttpPost]
        public ActionResult Delete(Product prod)//d'abord suprrimer les dependances dela table prod comme prix par exemple
        {
            dc.Entry<Product>(prod).State = EntityState.Deleted;

            dc.SaveChanges();
            return RedirectToAction("Index", "Home"); 
        }

        
        //Edit 
        
        //GET
       [Authorize]
        public ActionResult Edit(int id)
        {

            //return View(dc.Users.Find(id)); 
            //ok mais pourrait avoir page d'erreur si entre un id inexistant si url odif

            var prod = dc.Products.Find(id);

            if (prod == null)
                return RedirectToAction("Index", "Home");

          
            return View(prod);

        }
        //
        //POST
        [HttpPost]
        public ActionResult Edit(Product prod)
        {
            dc.Entry<Product>(prod).State = EntityState.Modified;
            dc.SaveChanges();
            return RedirectToAction("Index","Home");
        }

    }
}
