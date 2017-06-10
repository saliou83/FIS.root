using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Maloncos.Models;
using System.Web.Mvc;
using System.Web.Security;

namespace Maloncos.Controllers
{
    public class PanierController : Controller
    {
        PanierModel panier = new PanierModel();
        
        //
        // GET: /Home/
        private MaloncosDBEntities _db = new MaloncosDBEntities();
        public ActionResult Index()
        {
            return RedirectToAction("Accueil");
        }

       public ActionResult AjouterPanier(Vetements vetement, string nompanier, int n=1)
        {
            string userId = Membership.GetUser().ProviderUserKey.ToString();
            HttpCookie cookie = Request.Cookies["panier"];
            if( cookie != null)
            {
                Response.Cookies["panier"].Expires = DateTime.Now.AddHours(12);
                panier.NomPanier = nompanier;
                panier.Produits.Add(n,vetement);
                panier.idclient = userId;
                


            }
            else
                Response.Cookies["panier"].Expires = DateTime.Now.AddHours(12);
                panier.NomPanier = nompanier;
                panier.Produits.Add(n,vetement);
                panier.idclient = userId;
            return View();
        }
    }
}
