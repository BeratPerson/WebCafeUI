using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCafeUI.Models.Classes;
using WebCafeUI.Models.ContextDb;
using WebCafeUI.Models.Entities;

namespace Cafe_Menu_Project.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {


        private readonly Context db = new Context();


        ActiveUser activeUser;
        public JsonResult ActiveUser()
        {
            ActiveUser currentUser = (ActiveUser)Session["CurrentUser"];
            activeUser = currentUser;
            return Json(activeUser,JsonRequestBehavior.AllowGet);
        }
        public ActionResult Index()
        {
            ActiveUser currentUser = (ActiveUser)Session["CurrentUser"];
            if (!currentUser.IsAdmin || currentUser == null)
            {
                return HttpNotFound();
            }
            return View();
        }
        public JsonResult GetProductsCount()
        {
            var count =db.Products.Count();
            return Json(count, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetOrderTable()
        {

            var orders = from ord in db.Orders
                        join dist in db.Products on ord.productId equals dist.id
                        where ord.IsSend==0
                        select new { 
                            ord.id,
                            ord.Mail,
                            ord.phone,
                            ord.optional,
                            ord.NameSurName,
                            dist.ProductName
                            };



            return Json(orders, JsonRequestBehavior.AllowGet);



        }


        public JsonResult CompleteOrder(int id)
        {

            var order = db.Orders.Where(x => x.id == id).First();
            order.IsSend = 1;
            db.SaveChanges();
            var orders = from ord in db.Orders
                         join dist in db.Products on ord.productId equals dist.id
                         where ord.IsSend == 0
                         select new
                         {
                             ord.id,
                             ord.Mail,
                             ord.phone,
                             ord.optional,
                             ord.NameSurName,
                             dist.ProductName
                         };

            return Json(orders, JsonRequestBehavior.AllowGet);

        }
        public JsonResult GetOrderCount()
        {
            var count = db.Orders.Count();
            return Json(count, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetProductsTotalMany()
        {
            var many = db.Products.Sum(x=>x.Price);
            return Json(many, JsonRequestBehavior.AllowGet);
        }


    }
}