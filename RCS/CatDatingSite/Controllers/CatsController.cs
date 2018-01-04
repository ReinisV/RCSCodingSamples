using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CatDatingSite.Controllers
{
    using System.Data.Entity.Migrations;

    using CatDatingSite.Models;

    public class CatsController : Controller
    {
        // GET: Cats
        public ActionResult Index()
        {
            using (var catDb = new CatDb())
            {
                // iegūt kaķu sarakstu no kaķu datubāzes tabulas
                var catListFromDb = catDb.CatProfiles.ToList();

                // izveido skatu, tam iekšā iedodot kaķu sarakstu
                return View(catListFromDb);
            }
        }

        public ActionResult AddCat()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCat(CatProfile userCreatedCat)
        {
            if (ModelState.IsValid == false)
            {
                return RedirectToAction("AddCat");
            }

            // izveido savienojumu ar datubāzi
            using (var catDb = new CatDb())
            {
                // pievienojam kaķi kaķu tabulā
                catDb.CatProfiles.Add(userCreatedCat);
                // saglabājam izmaiņas datubāzē
                catDb.SaveChanges();
            }

            // pavēlam browserim atgriezties Index lapā (t.i. pārlādēt to)
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EditCat(CatProfile catProfile)
        {
            using (var catDb = new CatDb())
            {
                catDb.Entry(catProfile).CurrentValues.SetValues(catProfile);
                catDb.SaveChanges();
            }

            // pavēlam browserim atgriezties Index lapā (t.i. pārlādēt to)
            return RedirectToAction("Index");
        }

        public ActionResult EditCat(int editableCatId)
        {
            using (var catDb = new CatDb())
            {
                var editableCat = catDb.CatProfiles.First(catProfile => catProfile.CatId == editableCatId);
                return View("EditCat", editableCat);
            }
        }

        public ActionResult DeleteCats(int deletableCatId)
        {
            using (var catDb = new CatDb())
            {
                // atrast kaķi, kam pieder norādītais identifikators
                var deletableCat = catDb.CatProfiles.First(record => record.CatId == deletableCatId);

                // izdzēst šo kaķi no tabulas
                catDb.CatProfiles.Remove(deletableCat);

                // saglabāt veiktās izmaiņas datubāzē
                catDb.SaveChanges();
            }

            // jāpievieno using System.Net;
            // pavēlam browserim atgriezties Index lapā (t.i. pārlādēt to)
            return RedirectToAction("Index");
        }
    }
}