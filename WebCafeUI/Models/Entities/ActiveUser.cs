using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCafeUI.Models.Entities
{
    public class ActiveUser
    {
        public int id { get; set; }
        public bool IsAdmin { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
    }
}