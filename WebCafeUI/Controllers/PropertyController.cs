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
    public class PropertyController : Controller
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
        public JsonResult AddProperty(Property Property)
        {
            var ctrl = db.Properties.Where(x => x.Value == Property.Value&& x.Key == Property.Key).FirstOrDefault();

            if (ctrl!=null)
                return Json("0", JsonRequestBehavior.AllowGet);

            db.Properties.Add(Property);
            db.SaveChanges();
            var Propertys = db.Properties.ToList();
            return Json(Propertys, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public JsonResult GetList()
        {
            var Propertys = db.Properties.ToList();
            return Json(Propertys, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteProperty(int id)
        {

            var deleteProperty = db.Properties.Where(x => x.id == id).First();
            db.Properties.Remove(deleteProperty);
            db.SaveChanges();
            var Propertys = db.Properties.ToList();
            return Json(Propertys, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public JsonResult UpdateProperty(Property Property)
        {
            if (ModelState.IsValid)
            {
                var DBProperty = db.Properties.Where(x => x.id == Property.id).First();
                DBProperty.Key = Property.Key;
                DBProperty.Value = Property.Value;
                db.SaveChanges();
            }
            var Propertys = db.Properties.ToList();
            return Json(Propertys, JsonRequestBehavior.AllowGet);

        }
    }
}