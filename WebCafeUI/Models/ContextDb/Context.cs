using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebCafeUI.Models.Classes;

namespace WebCafeUI.Models.ContextDb
{
    public class Context:DbContext
    {
            public Context() : base("Server=DESKTOP-L41CNHP;Database=DbCafe;Trusted_Connection=true")
            {

            }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductProperty> ProductProperies { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<User> Users { get; set; }
    }
}