using Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc.Helpers
{
    public static class Utils
    {
        public static ShoppingCart sessionCart
        {
            get { return (ShoppingCart)(HttpContext.Current.Session["sessioncart"] = HttpContext.Current.Session["sessioncart"]?? new ShoppingCart()); }

            set { HttpContext.Current.Session["sessioncart"] = value; }
        }

    }
}