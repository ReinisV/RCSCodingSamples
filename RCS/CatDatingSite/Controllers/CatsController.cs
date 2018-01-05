using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CatDatingSite.Controllers
{
    using System.Data.Entity;
    using System.IO;

    using CatDatingSite.Models;

    using File = CatDatingSite.Models.File;

    public class CatsController : Controller
    {
        // GET: Cats
        public ActionResult Index()
        {
            using (var catDb = new CatDb())
            {
                // iegūt kaķu sarakstu no kaķu datubāzes tabulas
                var catListFromDb = catDb.CatProfiles.Include(catProf => catProf.ProfilePicture).ToList();
                
                // izveido skatu, tam iekšā iedodot kaķu sarakstu
                return View(catListFromDb);
            }
        }

        public ActionResult AddCat()
        {
            return View();
        }

        public ActionResult GetCatProfilePicture(int catProfilePictureId)
        {
            using (var db = new CatDb())
            {
                var profilePic = db.Files.First(rec => rec.FileId == catProfilePictureId);
                return File(profilePic.Content, profilePic.ContentType);
            }
        }

        [HttpPost]
        public ActionResult AddCat(CatProfile userCreatedCat, HttpPostedFileBase uploadedPicture)
        {
            if (ModelState.IsValid == false)
            {
                return View(userCreatedCat);
            }

            // izveido savienojumu ar datubāzi
            using (var catDb = new CatDb())
            {
                // pievienojam kaķi kaķu tabulā
                catDb.CatProfiles.Add(userCreatedCat);

                // saglabājam izmaiņas datubāzē
                catDb.SaveChanges();

                // ja ir pievienota profila bilde
                if (uploadedPicture != null)
                {
                    // izveidojam jaunu profila bildes datubāzes eksemplāru, ko ierakstīsim datubāzē
                    var profilePic = new File();

                    // saglabājam bildes faila nosaukumu
                    profilePic.FileName = Path.GetFileName(uploadedPicture.FileName);

                    // saglabājam bildes tipu
                    profilePic.ContentType = uploadedPicture.ContentType;

                    // izmantojam BinaryReader lai pārvērstu bildi baitos
                    using (var reader = new BinaryReader(uploadedPicture.InputStream))
                    {
                        // saglabājam baitus datubāzes ierakstā
                        profilePic.Content = reader.ReadBytes(uploadedPicture.ContentLength);
                    }

                    // pasakam profila bildei, kurš kaķa profils ir kaķa profils, kam šī bilde pieder
                    profilePic.CatProfileId = userCreatedCat.CatId;
                    profilePic.CatProfile = userCreatedCat;

                    // pievienojam profila bildes datubāzes ierakstu Files tabulai
                    catDb.Files.Add(profilePic);

                    // saglabājam profila bildi datubāzē, lai iegūtu FileId priekš profila bildes ieraksta
                    catDb.SaveChanges();

                    // paskam kaķu profilam, kas ir viņa profila bilde
                    userCreatedCat.ProfilePicture = profilePic;

                    // saglabājam izmaiņas datubāzē
                    catDb.SaveChanges();
                }
            }

            // pavēlam browserim atgriezties Index lapā (t.i. pārlādēt to)
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EditCat(CatProfile catProfile, HttpPostedFileBase uploadedPicture)
        {
            if (ModelState.IsValid == false)
            {
                return View(catProfile);
            }

            using (var catDb = new CatDb())
            {
                // ja ir pievienota profila bilde
                if (uploadedPicture != null)
                {
                    // atrodam šobrīdējo bildi, ja tāda ir
                    var currentPic = catDb.Files.FirstOrDefault(fileRecord => fileRecord.CatProfileId == catProfile.CatId);
                    if (currentPic != null)
                    {
                        catDb.Files.Remove(currentPic);
                    }

                    // izveidojam jaunu profila bildes datubāzes eksemplāru, ko ierakstīsim datubāzē
                    var profilePic = new File();

                    // saglabājam bildes faila nosaukumu
                    profilePic.FileName = Path.GetFileName(uploadedPicture.FileName);

                    // saglabājam bildes tipu
                    profilePic.ContentType = uploadedPicture.ContentType;

                    // izmantojam BinaryReader lai pārvērstu bildi baitos
                    using (var reader = new BinaryReader(uploadedPicture.InputStream))
                    {
                        // saglabājam baitus datubāzes ierakstā
                        profilePic.Content = reader.ReadBytes(uploadedPicture.ContentLength);
                    }

                    // pasakam profila bildei, kurš kaķa profils ir kaķa profils, kam šī bilde pieder
                    profilePic.CatProfileId = catProfile.CatId;
                    profilePic.CatProfile = catProfile;

                    // pievienojam profila bildes datubāzes ierakstu Files tabulai
                    catDb.Files.Add(profilePic);

                    // paskam kaķu profilam, kas ir viņa profila bilde
                    catProfile.ProfilePicture = profilePic;
                }
                
                // pievienot using System.Data.Entity;
                catDb.Entry(catProfile).State = EntityState.Modified;
                catDb.SaveChanges();
            }

            // pavēlam browserim atgriezties Index lapā (t.i. pārlādēt to)
            return RedirectToAction("Index");
        }

        public ActionResult EditCat(int editableCatId)
        {
            using (var catDb = new CatDb())
            {
                var editableCat = catDb.CatProfiles.Include(catRecord => catRecord.ProfilePicture).First(catProfile => catProfile.CatId == editableCatId);
                return View("EditCat", editableCat);
            }
        }

        public ActionResult DeleteCats(int deletableCatId)
        {
            using (var catDb = new CatDb())
            {

                // atrast kaķi, kam pieder norādītais identifikators
                var deletableCat = catDb.CatProfiles.Include(catProf => catProf.ProfilePicture).First(record => record.CatId == deletableCatId);
                
                // atrast kaķa bildi, ja tāda ir
                if (deletableCat.ProfilePicture != null)
                {
                    // izdzēst šo bildi
                    catDb.Files.Remove(deletableCat.ProfilePicture);
                }

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