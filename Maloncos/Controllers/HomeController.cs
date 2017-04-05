using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Maloncos.Models;
using System.Web.Mvc;


namespace Maloncos.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
       private MaloncosDBEntities _db = new MaloncosDBEntities();
        public ActionResult Index()
        {
            return RedirectToAction("Accueil");
        }

        public ActionResult Accueil()
        {
            return View();
        }
        public ActionResult Produitfemme()
        {
            return View(_db.Produits.ToList());
        }
        public ActionResult ProduitVeste()
        {
            
            
                return View(_db.Vetements.ToList());
            
        }
        public ActionResult Produithomme()
        {
            return View(_db.Produits.ToList());
        }
        //
        // GET: /Home/Details/5

        public ActionResult Details(int id)
        {
            return View(_db.Produits.First(i => i.Id == id));
        }
        public ActionResult DetailsVetementfemme(int id)
        {
            return View(_db.Vetements.First(i => i.Id_vetement == id));
        }
        public ActionResult Vetementfemme(string couleur = null)
        {
            ViewBag.Couleurs = _db.Couleur.ToList();
            if (couleur != null)
            {
                return View(_db.Vetements.Where(i => i.Couleur == couleur));                
            }
            return View(_db.Vetements.ToList());
        }
        public ActionResult Couleurvetement(string couleur)
        {
            return View(_db.Vetements.Where(i=>i.Couleur == couleur));
        
        }
        public ActionResult Vetementenfant(string couleur = null)
        {
            ViewBag.Couleurs = _db.Couleur.ToList();
            if (couleur != null)
            {
                return View(_db.Vetements.Where(i => i.Couleur == couleur));
            }
            return View(_db.Vetements.ToList());
        }
        public ActionResult DetailsVetementEnfant(int id)
        {
            return View(_db.Vetements.First(i => i.Id_vetement == id));
        }
        public ActionResult VetementHomme(string couleur = null)
        {
            ViewBag.Couleurs = _db.Couleur.ToList();
            if (couleur != null)
            {
                return View(_db.Vetements.Where(i => i.Couleur == couleur));
            }
            return View(_db.Vetements.ToList());
        }
        public ActionResult DetailsVetementHomme(int id)
        {
            return View(_db.Vetements.First(i => i.Id_vetement == id));
        }
      
        //
        // GET: /Home/CreateClient

        public ActionResult CreateClient()
        {
            var client = new ClientsModel();
            
            return View(client);
        } 

        //
        // POST: /Home/CreateClient

        [HttpPost]
        public ActionResult CreateClient([Bind(Exclude = "Id")] Clients clientocreat)
        {
            try
            {
                if (!ModelState.IsValid)
                 return View(); 
                var client = new ClientsModel();
                // TODO: Add insert logic here
                client.Id_Clients = clientocreat.Id_Clients;
                client.Nom_Client = clientocreat.Nom_Client;
                client.Prenom_Client = clientocreat.Prenom_Client;
                client.Adresse = clientocreat.Adresse;
                client.Code_postal = clientocreat.Code_postal;
                client.Genre = clientocreat.Genre;
                client.Email_Client = clientocreat.Email_Client;
                client.Password = clientocreat.Password;
                _db.Clients.Add(clientocreat);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult PageCheveux()
        {

            return View();

        }
        public ActionResult AffichageCadeau()
        {

            return View();

        }

        //
        // GET: /Home/Edit/5

        public ActionResult Edit(int id)
        {
            return View(_db.Produits.First(i => i.Id == id));
        }

        //
        // POST: /Home/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Home/Delete/5
        
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Home/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
