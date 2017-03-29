using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Maloncos.Models;
using System.Net;
using System.Data.Entity;


namespace Maloncos.Areas.Admin.Controllers
{
    public class VetementController : Controller
    {
        private MaloncosDBEntities _db = new MaloncosDBEntities();
        //
        // GET: /Admin/Vetement/
       
        public ActionResult Index()
        {
            return View("/Areas/Admin/Views/Vetement/Index.cshtml");
        }
        //
        // GET: /Admin/Vetement/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Admin/Vetement/Create

        public ActionResult CreateVetement()
        {
            var model = new VetementModel();
            return View(model);
           
        } 

        //
        // POST: /Admin/Vetement/Create

        [HttpPost]
        public ActionResult CreateVetement([Bind(Exclude = "Id")] Vetements vetementocreate)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                    return View();

                var article = new Vetements();
                article.Id_vetement = vetementocreate.Id_vetement;
              article.Type_vetement = vetementocreate.Type_vetement;
              article.Categorie = vetementocreate.Categorie;
              article.Genre_vetement = vetementocreate.Genre_vetement;
              article.Reference_vetement = vetementocreate.Reference_vetement;
              article.Libelle_vetement = vetementocreate.Libelle_vetement;
             article.Prix_vetement = vetementocreate.Prix_vetement;
             article.Couleur = vetementocreate.Couleur;
             article.Description = vetementocreate.Description;
             article.Image = vetementocreate.Image;

             _db.Vetements.Add(vetementocreate);
             _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Admin/Vetement/Edit/5
 
        public ActionResult Edit(int id)
        {
            var vetementToEdit = (from m in _db.Vetements
                               where m.Id_vetement == id
                               select m).First();

            return View(vetementToEdit);
        }

        //
        // POST: /Admin/Vetement/Edit/5

        [HttpPost]
        public ActionResult Edit( Vetements vetementoedit)
        {
             if (!ModelState.IsValid)
        return View();

             try
             {
                 var originalVetement = (from m in _db.Vetements
                                      where m.Id_vetement == vetementoedit.Id_vetement
                                      select m).First();
                                
                 _db.Vetements.Add(vetementoedit);
                 _db.SaveChanges();

                 return RedirectToAction("Index");
             }
             catch
             {
                 return View();
             }
        }

        //
        // GET: /Admin/Vetement/Delete/5
 
        public ActionResult Delete(int id)
        {
           
      return View();
        }

        //
        // POST: /Admin/Vetement/Delete/5

        [HttpPost]
        public ActionResult Delete(Vetements vetementdelete)
        {
            try
            {
                var originalVetement = (from m in _db.Vetements
                                        where m.Id_vetement == vetementdelete.Id_vetement
                                        select m).First();
                _db.Vetements.Remove(originalVetement);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
