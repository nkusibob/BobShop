//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Mvc.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductMedia
    {
        public int ProductID { get; set; }
        public int MediaID { get; set; }
        public int ID { get; set; }
    
        public virtual Medium Medium { get; set; }
        public virtual Product Product { get; set; }
    }
}