using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;

namespace _91app.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection post)
        {
            string account = post["account"];

            if (!account.Equals("UserA"))
            {
                ViewBag.Msg = "請輸入UserA";
                return View();
            }
            else
            {
                Session["account"] = account;
                ViewBag.Account = "UserA";
                Response.Redirect("~/Home/About");
                return new EmptyResult();
            }
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            using (StreamReader sr = new StreamReader(@"D:\Product.txt"))
            {
                ViewBag.Product = sr.ReadToEnd();
            }
            return View();
        }
        [HttpPost]
        public ActionResult Check(string Product1, string Product2, string Product3, string Product4)
        {
            using (StreamWriter sw = new StreamWriter(@"D:\Product.txt"))
            {
                sw.Write(Product1 + "," + Product2 + "," + Product3 + "," + Product4);
            }
            return Json(new { success = true, responseText = Product1 + "," + Product2 + "," + Product3 + "," + Product4 });
        }
        [HttpPost]
        public ActionResult Product(string Product)
        {
            int count = int.Parse(Product);
            string[] str = { "Product1 Details1", "Prodcut2 Details2", "Product3 Details3 ", "Product4 Details4" };
            return Json(new { success = true, responseText = str[count - 1] });
        }
        public ActionResult Contact()
        {
            return View();
        }
    }
}