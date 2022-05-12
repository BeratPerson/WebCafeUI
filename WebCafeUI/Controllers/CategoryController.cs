using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCafeUI.Models.Classes;
using WebCafeUI.Models.ContextDb;

namespace WebCafeUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly Context db = new Context();
        public ActionResult Index()
        {
            var categoriesList = db.Categories.ToList();
            return View(categoriesList);
        }
        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            var ctrl = db.Categories.Where(x => x.CategoryName == category.CategoryName).FirstOrDefault();
            if (ctrl==null)
            {
                category.CreatedDate = DateTime.Now;
                category.CreatorUserId = 1;
                db.Categories.Add(category);
                db.SaveChanges();
                var categoriesList = db.Categories.ToList();

                return Json(categoriesList);
            }
            else
            {
                return Json("0");

            }

        }
        [HttpPost]
        public ActionResult GetCategoryList( )
        {

                var categoriesList = db.Categories.ToList();

                return Json(categoriesList);


        }
        [HttpPost]
        public ActionResult DeleteCategory(Category category)
        {

            var deleteCategory = db.Categories.Where(x=>x.id == category.id).First();
            db.Categories.Remove(deleteCategory);
            //db.SaveChanges();
            var categoriesList = db.Categories.ToList();
            return Json(categoriesList);


        }
    }
}