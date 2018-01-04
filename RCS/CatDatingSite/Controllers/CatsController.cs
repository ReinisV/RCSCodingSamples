using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CatDatingSite.Controllers
{
    using CatDatingSite.Models;

    public class CatsController : Controller
    {
        // GET: Cats
        public ActionResult Index()
        {
            // izveido kaķi
            var catFromDb = new CatProfile();
            catFromDb.CatName = "REinis";
            catFromDb.CatAge = 15;
            catFromDb.CatImage =
                "http://r.ddmcdn.com/s_f/o_1/cx_462/cy_245/cw_1349/ch_1349/w_720/APL/uploads/2015/06/caturday-shutterstock_149320799.jpg";
            
            var anotherCatFromDb = new CatProfile();
            anotherCatFromDb.CatName = "cits REinis";
            anotherCatFromDb.CatAge = 5;
            
            using (var catDb = new CatDb())
            {
                // pievieno kaķi kaķu sarakstam
                //catDb.CatProfiles.Add(catFromDb);
                //catDb.CatProfiles.Add(anotherCatFromDb);
                // saglabāt datubāzē veiktās izmaiņas
                //catDb.SaveChanges();

                // iegūt kaķu sarakstu no kaķu datubāzes tabulas
                var catListFromDb = catDb.CatProfiles.ToList();

                // izveido skatu, tam iekšā iedodot kaķu sarakstu
                return View(catListFromDb);
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