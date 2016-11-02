using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication3.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        public ActionResult Index(string c)
        {
            var db = new BlogDatabase();

            db.Database.CreateIfNotExists();

            var lst = db.BlogBodys.AsQueryable();

            if(!string.IsNullOrWhiteSpace(c))
            {
                lst = lst.Where(o => o.Title.Contains(c));
            }

            ViewBag.BlogBodys = lst.OrderByDescending(o=>o.Id).ToList();

            ViewBag.c = c;

            return View();
        }
        /// <summary>
        /// 添加博客
        /// </summary>
        /// <returns></returns>
        public ActionResult AddBlog()
        {

            return View();
        }
        public ActionResult BlogSave(string title, string body)
        {
            var article = new BlogBody();
            article.Title = title ;
            article.Body = body;
            article.DateCreated = DateTime.Now;

            var db = new BlogDatabase();
            db.BlogBodys.Add(article);
            db.SaveChanges();

            return Redirect("Index");
        }
        public ActionResult Show(int id)
        {
            var db = new BlogDatabase();
            var article = db.BlogBodys.First(o => o.Id == id);

            ViewData.Model = article;
            return View();
        }
        public ActionResult Change(int id)
        {
            var db = new BlogDatabase();
            var article = db.BlogBodys.First(o => o.Id == id);

            ViewData.Model = article;
            return View();
        }
        public ActionResult ChangeSave(int id, string title, string body)
        {
            var db = new BlogDatabase();
            var article = db.BlogBodys.First(o => o.Id == id);

            article.Title = title;
            article.Body = body;

            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var db = new BlogDatabase();
            var article = db.BlogBodys.First(o => o.Id == id);


            db.BlogBodys.Remove(article);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}