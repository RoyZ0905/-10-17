using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        /// <summary>
        /// 列表界面
        /// </summary>
        /// <returns></returns>
        public ActionResult List()
        {
            string[] data = new string[] { "知乎", "豆瓣", "天涯论坛","新浪微博"};
            //ViewBag.Data = data;
            //ViewData["Data"] = data;
            ViewData.Model = data;
            return View(data);
        }
        /// <summary>
        /// welcome界面
        /// </summary>
        /// <returns></returns>
        public ActionResult Welcome()
        {
            int a =10;
            ViewBag.a = a;
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}