using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebCafeUI.Models.Classes
{
    public class ProductProperty
    {
        [Key]

        public int id { get; set; }
        public int ProductId { get; set; }
        public int PropertyId { get; set; }
    }
}