using Mvc.Helpers;
using Mvc.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc.Controllers
{
    public class CmdLineController : Controller
    {
        vendrEntities dc = new vendrEntities();
        ApplicationDbContext dbc = new ApplicationDbContext();
        //
        // GET: /Category/

        public ActionResult Index()
        {

            FromSessionToDb();
            //récupérer le userid
            int userId = dc.Users.Where(u => u.UserEmail == User.Identity.Name).First().UserID;
            var customerAdress = from cl2 in dc.Adresses
                                 where cl2.Customer.User.UserEmail == User.Identity.Name
                                 
                                 select cl2;
            var addressesList = customerAdress.
                        Select (x => new
                        {
                            ID = x.AdressID,
                            AddressLine = x.AdressLine1+x.AdressLine2



                        });
            ViewBag.Adresses = new SelectList(addressesList.ToList(), "ID", "AddressLine ", null);
            ViewBag.Adresses2 = new SelectList(customerAdress.ToList(), "AdressID", "AdressLine2", null);
            ViewBag.Country = new SelectList(dc.DeliverableCountries.ToList(), "DeliverableCountryID", "DeliverableCountryName", null);
            ViewBag.user = dc.Users.Where(u => u.UserEmail == User.Identity.Name).First().UserEmail;
            ViewBag.PostCode = dc.Customers.Where(c => c.User.UserUsername == User.Identity.Name).First().Adresses.First().AdressZipCode;
                               
            var customer = from cl1 in dc.Customers
                           where cl1.User.UserEmail == User.Identity.Name
                           select cl1;
            ViewBag.customer = new SelectList(customer.ToList(), "CustomerID", "CustomerLastName", null);




            List<CommandLine> listOrders=(from cl in dc.CommandLines where cl.Command.Adress.Customer.User.UserID==userId select cl).ToList();

            List<CommandLine> lstcmdline = (from cl in dc.CommandLines
                                            join c in dc.Commands on cl.CommandID equals c.CommandID
                                            where c.Adress.Customer.User.UserID == userId
                                            select cl).ToList();

            
            return View(lstcmdline);
        }
      
        private void FromSessionToDb()
        {
            //récupérer le userid
            string email = dbc.Users.Where(u=>u.Email == User.Identity.Name).First().Email;
            int userId = dc.Users.Where(u => u.UserEmail == User.Identity.Name).First().UserID;

            // récupérer toute les commandelines dont command status = 1 et user id = user loggé
            List<CommandLine> lstcmdline = (from cl in dc.CommandLines
                                            join c in dc.Commands on cl.CommandID equals c.CommandID
                                            join u in dc.Users on c.Adress.Customer.UserID equals u.UserID
                                            where u.UserEmail == email
                                            select cl).ToList();

            int cmdid=0;

            foreach (CommandLine c in lstcmdline)
            {
                if (cmdid == 0) cmdid = c.CommandID;
                dc.CommandLines.Remove(c);
            }

            try
            {
                dc.SaveChanges();
            }
            catch (Exception e)
            {

                throw e;
            }

            //insertion db
            if (Utils.sessionCart.CartLine!=null && Utils.sessionCart.CartLine.Count > 0)
            {
                try
                {


                    Command cmd = new Command();
                    // cmd.Adress.Customer.UserID = userId;
                    cmd.CommandDate = DateTime.Now;
                    cmd.CommandeReference = "jbfkjbkjbjf";
                    cmd.CommandFicsalDate = Convert.ToDateTime("2017 - 02 - 28 19:06:45.943");
                    cmd.CommandStatusID = 1;
                    cmd.Adress = dc.Adresses.Where(x => x.Customer.UserID ==userId).First();
                    dc.Commands.Add(cmd);
                    dc.SaveChanges();

                    foreach (KeyValuePair<int, CartItem> ci in Utils.sessionCart.CartLine)
                    {
                        CommandLine cl = new CommandLine();

                        cl.CommandLinePrice = ci.Value.price;
                        cl.ProductID = ci.Value.productid;
                        cl.CommandLineQuantity = ci.Value.quantity;
                        cl.CommandID = cmd.CommandID;

                        dc.CommandLines.Add(cl);
                    }

                    dc.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {

                    throw e;
                }
                
                
            }


            



        }


       

       
    }
}