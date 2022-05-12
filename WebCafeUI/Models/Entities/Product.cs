using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebCafeUI.Models.Classes
{
    public class Product
    {
        [Key]

        public int id { get; set; }
        public string ProductName { get; set; }
        public Category CategoryId { get; set; }
        public double Price { get; set; }
        public string ImagePath { get; set; }
        public bool IsdDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatorUserId { get; set; }
    }
}