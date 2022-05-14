using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebCafeUI.Models.Classes
{
    public class User
    {
        [Key]

        public int id { get; set; }
        public bool IsAdmin { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string SurName { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public string PasswordMD5 { get; set; }
    }
}