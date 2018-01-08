using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CatDatingSite.Controllers
{
    using CatDatingSite.Models;

    public class BlogController : Controller
    {
        // GET: Blog
        public ActionResult Index()
        {
            using (var db = new CatDb())
            {
                var blogsList = db.Blogs.ToList();
                return View(blogsList);
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Blog model)
        {
            if (ModelState.IsValid)
            {
                return View(model);
            }

            model.BlogCreated = DateTime.Now;
            model.BlogModified = DateTime.Now;

            using (var db = new CatDb())
            {
                db.Blogs.Add(model);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}