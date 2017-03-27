using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc.Models;

namespace Mvc.Controllers
{
    public class HomeController : Controller
    {
        vendrEntities dc = new vendrEntities();

        public ActionResult Index(string searchString)
        {
            var products = from p in dc.Products
                           select p;
           
            foreach (var p in products)

            {
                p.Medium = dc.Media.Where(x => x.ProductMedias.FirstOrDefault().ProductID == p.ProductID).ToList();
                
            }
            //var category=from c in dc.Categories select c;
            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.ProductName.Contains(searchString));
                //category = category.Where(t => t.CategoryName.Contains(searchString));
            }
            //cela précise le nbr de produit à montrer sur la première page
            int param = dc.parametres .AsEnumerable().LastOrDefault().nbre;

            products = products.Take(param);
          
           
            //categorie affiché à l'accueil
            var displayedCategories = from cat in dc.Categories
                                      where cat.CategoryIsMenu == true
                                      select cat;
            ViewBag.categorie = displayedCategories;
            var AllCategories = from cat in dc.Categories
                                   
                                      select cat;
            ViewBag.allcategorie = AllCategories;
           
            return View(products);
        }

        //[Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Bob at work";

            return View();
        }

        public ActionResult Policy()
        {
            ViewBag.Message = "Privacy Policy";

            return View();
        }

        public ActionResult Terms()
        {
            ViewBag.Message = "Terms and Conditions";

            return View();
        }

        public ActionResult Shipping()
        {
            ViewBag.Message = "Shipping Methods";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

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
    }
}
