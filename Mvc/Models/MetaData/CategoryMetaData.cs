using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Mvc.Models
{
    [MetadataType(typeof(CategoryMetaData))]
    public partial class Category
    {
        // Validation rules
        //[Bind(Exclude = "Id")]
        public class CategoryMetaData
        {
            //public Category Category { get; set; }

            [Required]
            [MaxLength(500, ErrorMessage = "en moins de 500 caractères, merci!")]
            public string CategoryName { get; set; }
            [Required]
            public string CategoryDescription { get; set; }

        }
    }
}