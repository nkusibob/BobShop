using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc.Models
{
    [MetadataType(typeof(ProductMetaData))]
    public partial class Product
    {
        // Validation rules
        //[Bind(Exclude = "Id")]
        public class ProductMetaData
        {

            [Display(Name = "Name")]
            [Required]
            [MaxLength(40, ErrorMessage = "... In less than 40 characters. Thank you")]
            public String ProductName { get; set; }

            [Display(Name = "Description")]
            [Required]
            public String ProductDescription { get; set; }

            [Display(Name = "Detailed Description")]
            [Required]
            public String ProductLongDescription { get; set; }

            [Display(Name = "Reference")]
            [Required]
            public String ProductReference { get; set; }

            [Display(Name = "Manufacturer Reference")]
            [Required]
            public string ProductManufacturerReference { get; set; }

            [Display(Name = "Bar Code")]
            [Required]
            [MaxLength(16, ErrorMessage = "... In less than 16 characters. Thank you")]
            public String ProductBarCode { get; set; }

            [Display(Name = "Released Date")]
            [DataType(DataType.Date)]
            [Required]
            public DateTime ProductAddingDate { get; set; }

            [Display(Name = "Is the product discontinuited?")]
            public bool ProductDiscontinued { get; set; }

            [Display(Name = "Choose a VAT Category")]
            [Required]
            public int VATCategoryID { get; set; }

            [Display(Name = "Choose a unit type")]
            [Required]
            public int UnitTypeID { get; set; }

            [Display(Name = "Choose a Category")]
            [Required]
            public int CategoryID { get; set; }


            //[Display(Name = "Choose a Media Type")]
            //[Required]
            //public int MediaTypeID { get; set; }
        }
    }
}