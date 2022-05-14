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
        public int CategoryId { get; set; }
        public double Price { get; set; }
        public string ImagePath { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatorUserId { get; set; }

        public static implicit operator List<object>(Product v)
        {
            throw new NotImplementedException();
        }
    }
}