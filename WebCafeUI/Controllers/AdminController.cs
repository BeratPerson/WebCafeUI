using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCafeUI.Models.Classes;
using WebCafeUI.Models.ContextDb;

namespace Cafe_Menu_Project.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly Context db = new Context();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Category()
        {
            var categoriesList = db.Categories.ToList();
            return View(categoriesList);
        }


    }
}