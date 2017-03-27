using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc.Models;
using System.Data.Entity;
using Mvc.Helpers;

namespace Mvc.Controllers
{
    public class CartController : Controller
    {
        vendrEntities dc = new vendrEntities();
        ShoppingCart scart = new ShoppingCart();
        //
        // GET: /Cart/

        public ActionResult Index()
        {
            //le problème est l'authentification tant que l'user ne l'est pas sinon invalid column is UserID
            if (User.Identity.IsAuthenticated)
            {
                var clquery = from cl in dc.CommandLines
                              where cl.Command.Adress.Customer.User.UserEmail == User.Identity.Name
                             
                              select cl;
                var customer = from cl1 in dc.Customers
                               where cl1.User.UserEmail == User.Identity.Name
                               select cl1;
                var customerAdress = from cl2 in dc.Adresses
                               where cl2.Customer.User.UserEmail == User.Identity.Name
                               select cl2;
                ViewBag.customer = new SelectList(customer.ToList(), "CustomerID", "CustomerLastName", null);
                ViewBag.customerAdress = new SelectList(customerAdress.ToList(), "AdressID", "AdressLine2","AdressLine2");
                ViewBag.clines = clquery.ToList();
            }
            //Calculer le total 

            return View(Utils.sessionCart);
        }

        //
        // POST:/Create
        public ActionResult Create(int id, int quantity)
        {

           // ShoppingCart cart = (ShoppingCart)Session["sessioncart"];
            /*recherche si le produit est deja sur une ligne du cart*/
            var knvquery = from KeyValuePair<int, CartItem> knv in Utils.sessionCart.CartLine.ToList()
                           where knv.Value.productid == id
                           select knv;

       
            if (Utils.sessionCart.CartLine.Any(a => a.Value.productid == id))
            {
                Utils.sessionCart.CartLine.First(a => a.Value.productid == id).Value.quantity = quantity;
            }
            else
            {
                CartItem ci = new CartItem();
                //ci.productid = id;
                var query = from p in dc.Products
                            where p.ProductID == id
                            select p;
                //ci.productname = query.First().ProductName;
                ci.product = query.First();
                ci.price = query.First().Prices.FirstOrDefault().PriceValue;
                ci.quantity = quantity;
               
                Utils.sessionCart.AddCartLine(ci);
            }

           
            



            ///*Si authentifié, il va en plus rajouter en db.
            // *S'il existe une commande de status=1, la ligne s'ajoute dans celle là
            // *Sinon, crée une nouvelle commande*/
            //if (User.Identity.IsAuthenticated)
            //{
            //    var prodquery = from p in dc.Products
            //                    where p.ProductID == id
            //                    select p;
            //    var userquery = from u in dc.Users
            //                    where u.UserEmail == User.Identity.Name
            //                    select u;

            //    // check s'il existe deja une commande ouverte (i.e. de status=1)
            //    var status1commquery = from c in dc.Commands
            //                           where c.CommandStatusID == 1
            //                           select c;
            //    Command ncomm = null;
            //    if (status1commquery != null)
            //    {
            //        ncomm = status1commquery.FirstOrDefault();
            //    }
            //    else
            //    {
            //        ncomm = new Command();
            //        ncomm.CommandDate = DateTime.Now;
            //        ncomm.CommandFicsalDate = DateTime.Now;
            //        ncomm.CommandeReference = DateTime.Now + "-" + userquery.FirstOrDefault().UserID;
            //        ncomm.CommandStatusID = 1;
            //        ncomm.UserID = userquery.FirstOrDefault().UserID;
            //        dc.Commands.Add(ncomm);
            //        dc.SaveChanges();
            //    }
            //    /*commande ouverte, on ajoute la ligne de commande*/

            //    CommandLine ncline = new CommandLine();
            //    ncline.CommandLineQuantity = quantity;
            //    ncline.CommandLinePrice = prodquery.FirstOrDefault().Prices.FirstOrDefault().PriceValue;
            //    ncline.CommandID = ncomm.CommandID;
            //    ncline.ProductID = id;
            //    dc.CommandLines.Add(ncline);
            //    dc.SaveChanges();


            //}
            return RedirectToAction("Index", "Cart");
        }

        // POST:/Edit
        public ActionResult Edit(int id, int quantity)
        {
            if (!Request.IsAuthenticated)
            {
                ShoppingCart cart = (ShoppingCart)Session["sessioncart"];
                /*recherche si le produit est deja sur une ligne du cart*/
                var knvquery = from KeyValuePair<int, CartItem> knv in cart.CartLine.ToList()
                               where knv.Value.productid == id
                               select knv;

                if (cart.CartLine.Any(a => a.Value.productid == id))
                {
                    //cart.CartLine.First(a => a.Value.productid == productId).Value.quantity
                }

                if (knvquery.Count() != 0)
                {
                    CartItem cItemToUpdate = knvquery.First().Value;
                    

                    cItemToUpdate.quantity = quantity;
                }
                else
                {
                    CartItem ci = new CartItem();
                    //ci.productid = id;
                    var query = from p in dc.Products
                                where p.ProductID == id
                                select p;
                   // ci.productname = query.First().ProductName;
                    ci.product = query.First();
                    ci.price = query.First().Prices.FirstOrDefault().PriceValue;
                    ci.quantity = quantity;

                    cart.AddCartLine(ci);
                }
                return RedirectToAction("Index", "Cart");

            }
            /*Sinon, ie. s'il est authentified, on va 
             editer la db*/
            else
            {

                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult Delete(int id)
        {

            ShoppingCart cart = (ShoppingCart)Session["sessioncart"];
            /*recherche si le produit est deja sur une ligne du cart*/
            var knvquery = from KeyValuePair<int, CartItem> knv in cart.CartLine.ToList()
                           where knv.Value.productid == id
                           select knv;



            if (knvquery.Count() != 0)
            {
                CartItem cItemToDelete = knvquery.First().Value;
                cItemToDelete.quantity = 0;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
           
        }
           
        //
        //POST
        [HttpPost]
        public ActionResult Delete(CartItem ci)//d'abord suprrimer les dependances dela table prod comme prix par exemple
        {
            dc.Entry<CartItem>(ci).State = EntityState.Deleted;

            dc.SaveChanges();
            return RedirectToAction("Index", "Home");
        }


        // POST:/delete
      
        //[HttpGet]
        //public ActionResult GetQuantity(int id)
        //{
        //    ShoppingCart cart = (ShoppingCart)Session["sessioncart"];

        //    return Json(new { quantity = (cart.CartLine.Any(a => a.Value.productid == id)) ? cart.CartLine.Where(a => a.Value.productid == id).First().Value.quantity : 0 }, JsonRequestBehavior.AllowGet);
        //}

        ////GET
        //public ActionResult Edit(int id)
        //{

        //    /*on aimerait faire un Edit comme pour var prod = dc.Products.Find(id);
        //     * mais la methode .Find() n'existe pas (encore?) pour la classe CartLine
        //    */

        //    var query = from cl in scart.CartLine
        //                where cl.Key == id
        //                select cl;

        //    CartItem citem = query.First();
        //    var cartline = scart.CartLine.Find(id);

        //    if (cartline == null)
        //        return RedirectToAction("Index", "Home");

        //    return View(prod);

        //}

        ////
        ////POST
        //[HttpPost]
        //public ActionResult Edit(Product prod)
        //{
        //    dc.Entry<Product>(prod).State = System.Data.EntityState.Modified;

        //    dc.SaveChanges();
        //    return RedirectToAction("Index", "Home");
        //}


    }
}