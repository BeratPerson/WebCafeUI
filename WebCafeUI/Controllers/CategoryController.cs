using System;
using System.Linq;
using System.Web.Mvc;
using WebCafeUI.Models.Classes;
using WebCafeUI.Models.ContextDb;
using WebCafeUI.Models.Entities;
namespace WebCafeUI.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly Context db = new Context();

        public ActionResult Index()
        {
            ActiveUser currentUser = (ActiveUser)Session["CurrentUser"];
            if (!currentUser.IsAdmin || currentUser == null)
            {
                return HttpNotFound();
            }
            return View();
        }
        public JsonResult GetList()
        {
            var categoriesList = from c in db.Categories
                                 join u in db.Users on c.CreatorUserId equals u.id
                                 select new
                                 {
                                     c.id,
                                     c.CategoryName,
                                     c.ParentCategoryId,
                                     c.IsDeleted,
                                     c.CreatedDate,
                                     u.Name,
                                     u.SurName
                                 };
            return Json(categoriesList, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult DeleteCategory(int id)
        {

            var deleteCategory = db.Categories.Where(x => x.id == id).First();
            db.Categories.Remove(deleteCategory);
            db.SaveChanges();
            var categoriesList = from c in db.Categories
                                 join u in db.Users on c.CreatorUserId equals u.id
                                 select new
                                 {
                                     c.id,
                                     c.CategoryName,
                                     c.ParentCategoryId,
                                     c.IsDeleted,
                                     c.CreatedDate,
                                     u.Name,
                                     u.SurName
                                 };
            return Json(categoriesList, JsonRequestBehavior.AllowGet);

        }


        [HttpPost]
        public JsonResult Add(Category category)
        {
            ActiveUser currentUser = (ActiveUser)Session["CurrentUser"];
            var ctrl = db.Categories.Where(x => x.CategoryName == category.CategoryName).FirstOrDefault();
            if (ctrl == null)
            {
                category.CreatedDate = DateTime.Now;
                category.CategoryName = category.CategoryName.Trim();
                category.CreatorUserId = 1;
                category.CreatorUserId = currentUser.id;
                db.Categories.Add(category);
                db.SaveChanges();

                var categoriesList = from c in db.Categories
                                     join u in db.Users on c.CreatorUserId equals u.id
                                     select new
                                     {
                                         c.id,
                                         c.CategoryName,
                                         c.ParentCategoryId,
                                         c.IsDeleted,
                                         c.CreatedDate,
                                         u.Name,
                                         u.SurName
                                     };
                return Json(categoriesList, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("0", JsonRequestBehavior.AllowGet);
            }



        }





        [HttpPost]
        public JsonResult UpdateCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                var DBCategory = db.Categories.Where(x => x.id == category.id).First();
                DBCategory.IsDeleted = category.IsDeleted;
                DBCategory.CategoryName = category.CategoryName;
                DBCategory.ParentCategoryId = category.ParentCategoryId;
                db.SaveChanges();
                var categoriesList = from c in db.Categories
                                     join u in db.Users on c.CreatorUserId equals u.id
                                     select new
                                     {
                                         c.id,
                                         c.CategoryName,
                                         c.ParentCategoryId,
                                         c.IsDeleted,
                                         c.CreatedDate,
                                         u.Name,
                                         u.SurName
                                     };
                return Json(categoriesList, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("0", JsonRequestBehavior.AllowGet);
            }



        }
    }
}