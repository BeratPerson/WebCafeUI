using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebCafeUI.Models.Classes
{
    public class Property
    {
        [Key]

        public int id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}