using Mvc.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/
        [Authorize]
        public ActionResult Index()
        {
            var prods = dc.Products.ToList();
            return View(prods);
        }

        //
        // GET: /Product/
        vendrEntities dc = new vendrEntities();

        public ActionResult Details(int id)
        {

            var prod = dc.Products.Find(id);
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

            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.ProductName.Contains(searchString));
            }

            return View(products);
        }
        //
        //Create
        //GET
        public ActionResult Create()
        {
            ViewBag.Categories = new SelectList(dc.Categories.ToList(), "CategoryID", "CategoryName", null);
            ViewBag.VATCategories = new SelectList(dc.VATCategories.ToList(), "VATCategoryID", "VATCategoryName", null);
            ViewBag.UnitTypes = new SelectList(dc.UnitTypes.ToList(), "UnitTypeID", "UnitTypeName", null);
            ViewBag.MediaTypes = new SelectList(dc.MediaTypes.ToList(), "MediaTypeID", "MediaTypeName", null);
            ViewBag.Prices = new SelectList(dc.Prices.ToList(), "PriceID", "Prices", null);
            var prod = new Product();
            prod.ProductAddingDate = DateTime.Now.Date;
            return View(prod);
        }

        //POST
        [HttpPost]
        public ActionResult Create(Product prod)
        {
            dc.Products.Add(prod);
            dc.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        //
        //
        //Delete
        //GET
        public ActionResult Delete(int id)
        {

            var prod = dc.Products.Find(id);

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

        //
        //Edit 
        //
        //GET
        public ActionResult Edit(int id)
        {

            //return View(dc.Users.Find(id)); ok mais pourrait avoir page d'erreur si entre un id inexistant si url odif

            var prod = dc.Products.Find(id);

            
            if (prod == null)
                return RedirectToAction("Index", "Home");

            var media = dc.Media.ToList();
            ViewBag.CategoryID = new SelectList(dc.Categories, "CategoryID", "CategoryName", prod.CategoryID);
            ViewBag.lastPrice = prod.Prices.OrderBy(pr => pr.PriceDate).FirstOrDefault().PriceValue;
            ViewBag.media = media;
            return View(prod);

        }
        //
        //POST
        [HttpPost]
        public ActionResult Edit(Product prod, int[] ListMedia, decimal priceEditor)
        {
            try
            {

                Product prd = dc.Products.Find(prod.ProductID);

                prd.Prices.FirstOrDefault().PriceValue = priceEditor;
               

                prd.ProductMedias.Clear();

                dc.Entry<Product>(prd).CurrentValues.SetValues(prod);

                foreach (int id in ListMedia)
                {
                    ProductMedia pm = new ProductMedia();
                    Medium medi = dc.Media.Find(id);
                    pm.Medium = medi;
                    pm.MediaID = medi.MediaID;
                    pm.ProductID = prd.ProductID;
                    pm.Product = prd;

                    prd.ProductMedias.Add(pm);
                }
                dc.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {

                throw e;
            }
            return RedirectToAction("Index", "Home");
        }

    }
}
