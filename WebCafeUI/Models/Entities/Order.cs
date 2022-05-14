using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCafeUI.Models.Entities
{
    public class Order
    {
        public int id { get; set; }
        public int IsSend { get; set; }
        public int productId { get; set; }
        public string NameSurName { get; set; }
        public string phone { get; set; }
        public string Mail { get; set; }
        public string optional { get; set; }

    }
}