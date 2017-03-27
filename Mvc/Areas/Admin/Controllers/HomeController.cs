using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc.Models;

namespace Mvc.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        vendrEntities dc = new vendrEntities();
        //
        // GET: /Admin/Home/
        [Authorize]
        public ActionResult Index()
        {
            var nbusersquery=from u in dc.Users
                             select u;
            ViewBag.usersQuery = nbusersquery;
            ViewBag.NbUsers = nbusersquery.Count();
            var nbcmdquery = from u in dc.Commands
                               select u;
            ViewBag.NbComds = nbcmdquery.Count();
            return View();
        }

       
    }
}
