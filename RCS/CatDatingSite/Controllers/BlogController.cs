using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CatDatingSite.Controllers
{
    using System.Data.Entity;
    using System.Web.Security;

    using CatDatingSite.Models;

    using Microsoft.AspNet.Identity;

    public class BlogController : Controller
    {
        // GET: Blog
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                string userId = User.Identity.GetUserId();
                using (var db2 = new ApplicationDbContext())
                {
                    var user = db2.Users.First(u => u.Id == userId);
                }
            }

            
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

        public ActionResult Edit(Blog model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new CatDb())
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToAction("Index");
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