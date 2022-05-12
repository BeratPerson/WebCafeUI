using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebCafeUI.Models.Classes;
using WebCafeUI.Models.ContextDb;

namespace ContactsProjectUI.Controllers
{
    public class SecurityController : Controller
    {
        private readonly Context db = new Context();
        private char[] observedText;

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            var userdb = db.Users.FirstOrDefault(x => x.UserName == user.UserName && x.Password == user.Password);
            if (userdb != null)
            {
                FormsAuthentication.SetAuthCookie(userdb.UserName, false);

                if (userdb.IsAdmin == true)
                {
                    return RedirectToAction("Index", "Admin");

                }
                else
                {
                    return RedirectToAction("Index", "Cafe");
                }
            }
            else
            {
                TempData["User"] = "Geçersiz Kullanıcı Adı veya Şifre";
                return View();

            }
        }
        [HttpPost]
        public ActionResult Register(User user)
        {
            var userdb = db.Users.FirstOrDefault(x => x.UserName == user.UserName && x.Password == user.Password);
            if (userdb == null)
            {
                user.PasswordMD5 = MD5Hash(user.Password);
                if (ModelState.IsValid)
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Login");
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return View("Login");
        }
        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }
    }
}