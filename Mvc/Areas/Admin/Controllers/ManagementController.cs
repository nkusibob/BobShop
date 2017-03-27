using Mvc.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc.Areas.Admin.Controllers
{
    public class ManagementController : Controller
    {
       
        // GET: /Admin/Management/
        vendrEntities dc = new vendrEntities();
        public ActionResult Index()
        {
            var nbusersquery = from u in dc.Users
                               select u;
            ViewBag.usersQuery = nbusersquery;
            return View();
        }

        public ActionResult Create()
        {
            ViewBag.Parametre = new SelectList(dc.parametres.ToList(), "id", "nbr", null);
            var param = new parametre();

            return PartialView();
        }
        
        [HttpPost]
        public ActionResult Create(parametre param)
        {
            dc.parametres.Add(param);
            dc.SaveChanges();
            return PartialView();
        }
        public ActionResult Delete(int id)
        {

            var param = dc.parametres.Find(id);

            if (param == null)
                return RedirectToAction("Index", "Home");

            return View(param);

        }
        //
        //POST
        [HttpPost]
        public ActionResult Delete(parametre param)//d'abord suprrimer les dependances dela table prod comme prix par exemple
        {
            dc.Entry<parametre>(param).State = EntityState.Deleted;

            dc.SaveChanges();
            return RedirectToAction("Index", "Home");
        }


    }
}
