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
    public class ProductPropertyController : Controller
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
        public JsonResult AddProductProperty(ProductProperty ProductProperty)
        {
            var ctrl = db.ProductPropertys.Where(x => x.ProductId == ProductProperty.ProductId&& x.PropertyId== ProductProperty.PropertyId).FirstOrDefault();

            if (ctrl!=null)
                return Json("0", JsonRequestBehavior.AllowGet);
            if (ProductProperty.ProductId == null || ProductProperty.PropertyId == null)
                return Json("-1", JsonRequestBehavior.AllowGet);


            db.ProductPropertys.Add(ProductProperty);
            db.SaveChanges();
            var ProductPropertys = from p in db.ProductPropertys
                                 join prod in db.Products on p.ProductId equals prod.id
                                 join prop in db.Properties on p.PropertyId equals prop.id
                                   select new
                                 {
                                       p.id,
                                       prod.ProductName,
                                       prop.Value,
                                       prop.Key
                                 };
            return Json(ProductPropertys, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public JsonResult GetList()
        {
            var ProductPropertys = from p in db.ProductPropertys
                                   join prod in db.Products on p.ProductId equals prod.id
                                   join prop in db.Properties on p.PropertyId equals prop.id
                                   select new
                                   {
                                       p.id,
                                       prod.ProductName,
                                       prop.Value,
                                       prop.Key
                                   };
            return Json(ProductPropertys, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteProductProperty(int id)
        {

            var deleteProductProperty = db.ProductPropertys.Where(x => x.id == id).First();
            db.ProductPropertys.Remove(deleteProductProperty);
            db.SaveChanges();
            var ProductPropertys = from p in db.ProductPropertys
                                   join prod in db.Products on p.ProductId equals prod.id
                                   join prop in db.Properties on p.PropertyId equals prop.id
                                   select new
                                   {
                                       p.id,
                                       prod.ProductName,
                                       prop.Value,
                                       prop.Key
                                   };
            return Json(ProductPropertys, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public JsonResult UpdateProductProperty(ProductProperty ProductProperty)
        {
            if (ModelState.IsValid)
            {
                var DBProductProperty = db.ProductPropertys.Where(x => x.id == ProductProperty.id).First();
                DBProductProperty.ProductId = ProductProperty.ProductId;
                DBProductProperty.PropertyId = ProductProperty.PropertyId;

                db.SaveChanges();
            }
            var ProductPropertys = from p in db.ProductPropertys
                                   join prod in db.Products on p.ProductId equals prod.id
                                   join prop in db.Properties on p.PropertyId equals prop.id
                                   select new
                                   {
                                       p.id,
                                       prod.ProductName,
                                       prop.Value,
                                       prop.Key
                                   };
            return Json(ProductPropertys, JsonRequestBehavior.AllowGet);

        }
    }
}