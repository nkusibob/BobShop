using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Mvc.Models
{
    [MetadataType(typeof(CartMetaData))]
    public partial class CartItem
    {
        // Validation rules
        //[Bind(Exclude = "Id")]
        public class CartMetaData
        {

            [Display(Name = "Product Name")]
            public string productname { get; set; }

            [Display(Name = "Unit Price")]
            public decimal price { get; set; }

            [Display(Name = "Quantity")]
            public int quantity { get; set; }

        }
    }
}