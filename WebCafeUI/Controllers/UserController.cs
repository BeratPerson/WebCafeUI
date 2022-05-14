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
    public class UserController : Controller
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
            var UsersList = db.Users.ToList();
            return Json(UsersList, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult DeleteUser(int id)
        {
            var deleteUser = db.Users.Where(x => x.id == id).First();
            db.Users.Remove(deleteUser);
            db.SaveChanges();
            var UsersList = db.Users.ToList();
            return Json(UsersList, JsonRequestBehavior.AllowGet);

        }








        [HttpPost]
        public JsonResult UpdateUser(User User)
        {

            var DBUser = db.Users.Where(x => x.id == User.id).First();
            DBUser.IsAdmin = User.IsAdmin;
            db.SaveChanges();
            var UsersList = db.Users.ToList();
            return Json(UsersList, JsonRequestBehavior.AllowGet);



        }
    }
}