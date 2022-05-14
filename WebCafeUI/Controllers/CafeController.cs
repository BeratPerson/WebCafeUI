using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebCafeUI.Models.ContextDb;
using WebCafeUI.Models.Entities;
using WebCafeUI.Models.ViewModels;

namespace Cafe_Menu_Project.Controllers
{
    public class CafeController : Controller
    {
        private readonly Context db = new Context();
        public string dolar()
        {
            Uri url = new Uri("https://bigpara.hurriyet.com.tr/doviz/dolar/");
            WebClient client = new WebClient();
            string html = client.DownloadString(url);
            HtmlAgilityPack.HtmlDocument dokuman = new HtmlAgilityPack.HtmlDocument();
            dokuman.LoadHtml(html);
            // İndirdiğimiz html kodlarını bir HtmlDocument nesnesine yüklüyoruz. 
            string dolar = dokuman.DocumentNode.SelectNodes("/html/body/div[3]/div[3]/div[2]/div/div[2]/div[3]/span[2]")[0].InnerText;
            return dolar;
        }
        public ActionResult Index()
        {
            string dolarKur =dolar();
            TempData["dolar"] = dolarKur;
            var products = db.Products.ToList();
            var categories = db.Categories.ToList();
            var productProp = db.ProductPropertys.ToList();
            var properties = db.Properties.ToList();
            var ProductViewModels = new ProductViewModels
            {
             products=products,
             categories=categories,
             productProperties=productProp,
             properties=properties
            };

            return View(ProductViewModels);
        }
        public ActionResult Category(int id)
        {
            string dolarKur = dolar();
            TempData["dolar"] = dolarKur;
            var products = db.Products.Where(x=>x.CategoryId==id).ToList();
            var categories = db.Categories.ToList();
            var productProp = db.ProductPropertys.ToList();
            var properties = db.Properties.ToList();
            var ProductViewModels = new ProductViewModels
            {
                products = products,
                categories = categories,
                productProperties = productProp,
                properties = properties
            };

            return View(ProductViewModels);
        }
        public ActionResult Order(int id)
        {
            string dolarKur = dolar();
            TempData["dolar"] = dolarKur;
            var products = db.Products.Where(x => x.id == id).ToList();
            var productProp = db.ProductPropertys.ToList();
            var properties = db.Properties.ToList();
            var ProductViewModels = new ProductViewModels
            {
                products = products,
                productProperties = productProp,
                properties = properties
            };

            return View(ProductViewModels);
        }
        [HttpPost]
        public ActionResult Order(Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
            }
            TempData["order"] = "your order has been created";
            return RedirectToAction("Index");
        }
        public ActionResult Search(string search)
        {
            string dolarKur = dolar();
            TempData["dolar"] = dolarKur;
            var products = db.Products.Where(x => x.ProductName.ToLower().Contains(search.ToLower())).ToList();
            var categories = db.Categories.ToList();
            var productProp = db.ProductPropertys.ToList();
            var properties = db.Properties.ToList();
            var ProductViewModels = new ProductViewModels
            {
                products = products,
                productProperties = productProp,
                categories = categories,
                properties = properties
            };
            return View(ProductViewModels);
        }

    }
}