using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebCafeUI.Models.Classes;

namespace WebCafeUI.Models.ViewModels
{
    public class ProductViewModels
    {
        public List<Product> products { get; set; }
        public List<ProductProperty> productProperties { get; set; }
        public List<Category> categories { get; set; }
        public List<Property> properties { get; set; }
    }
}