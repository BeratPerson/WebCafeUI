using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCafeUI.Models.Classes;
using WebCafeUI.Models.ContextDb;
using WebCafeUI.Models.Entities;

namespace WebCafeUI.Controllers
{
    [Authorize]
    public class ProductController : Controller
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
        [HttpPost]
        public JsonResult AddProduct(Product product)
        {

            ActiveUser currentUser = (ActiveUser)Session["CurrentUser"];
            product.ImagePath = product.ImagePath;
            product.CategoryId = product.CategoryId;
            product.ProductName = product.ProductName;
            product.Price = product.Price;
            product.IsDeleted = false;
            product.CreatedDate = DateTime.Now;
            product.CreatorUserId = currentUser.id;
            db.Products.Add(product);
            db.SaveChanges();
            var products = from c in db.Products
                           join u in db.Users on c.CreatorUserId equals u.id
                           join cat in db.Categories on c.CategoryId equals cat.id

                           select new
                           {
                               c.id,
                               c.ProductName,
                               c.Price,
                               c.ImagePath,
                               c.IsDeleted,
                               cat.CategoryName,
                               c.CreatedDate,
                               u.Name,
                               u.SurName
                           };


            return Json(products, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public JsonResult GetList()
        {
            var products = from c in db.Products
                           join u in db.Users on c.CreatorUserId equals u.id
                           join cat in db.Categories on c.CategoryId equals cat.id

                           select new
                           {
                               c.id,
                               c.ProductName,
                               c.Price,
                               c.ImagePath,
                               c.IsDeleted,
                               cat.CategoryName,
                               c.CreatedDate,
                               u.Name,
                               u.SurName
                           };
            return Json(products, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Deleteproduct(int id)
        {

            var deleteproduct = db.Products.Where(x => x.id == id).First();
            db.Products.Remove(deleteproduct);
            db.SaveChanges();
            var products = from c in db.Products
                           join u in db.Users on c.CreatorUserId equals u.id
                           join cat in db.Categories on c.CategoryId equals cat.id

                           select new
                           {
                               c.id,
                               c.ProductName,
                               c.Price,
                               c.ImagePath,
                               c.IsDeleted,
                               cat.CategoryName,
                               c.CreatedDate,
                               u.Name,
                               u.SurName
                           };
            return Json(products, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public JsonResult Updateproduct(Product product)
        {
            if (ModelState.IsValid)
            {
                var DBproduct = db.Products.Where(x => x.id == product.id).First();
                DBproduct.ImagePath = product.ImagePath;
                DBproduct.CategoryId = product.CategoryId;
                DBproduct.ProductName = product.ProductName;
                DBproduct.Price = product.Price;
                DBproduct.IsDeleted = product.IsDeleted;
                db.SaveChanges();
            }
            var products = from c in db.Products
                           join u in db.Users on c.CreatorUserId equals u.id
                           join cat in db.Categories on c.CategoryId equals cat.id

                           select new
                           {
                               c.id,
                               c.ProductName,
                               c.Price,
                               c.ImagePath,
                               c.IsDeleted,
                               cat.CategoryName,
                               c.CreatedDate,
                               u.Name,
                               u.SurName
                           };
            return Json(products, JsonRequestBehavior.AllowGet);

        }
    }
}