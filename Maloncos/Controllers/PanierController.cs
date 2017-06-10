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

        [HttpPost]
        public ActionResult AddProduitToPanier(ProduitPanierModel produit)
        {
            PanierModel panier;
            if (this.Session["panier_maloncos"] != null)
            {
                panier = (PanierModel)Session["panier_maloncos"];
            }
            else
            {
                panier = new PanierModel()
                {
                    idclient = User.Identity.Name,
                    NomPanier = string.Format("panier_{0}", User.Identity),
                    Produits = new List<ProduitPanierModel>()
                };
            }

            //Si le produit est dans le panier, on augemente la quanté
            if (panier.Produits.Any(p => p.Id == produit.Id))
            {
                panier.Produits.FirstOrDefault(p => p.Id == produit.Id).quantite += produit.quantite;
            }
            else
            {
                panier.Produits.Add(produit);
            }

            Session["panier_maloncos"] = panier;

            return Json(new { resultat = "OK", value = panier });
        }
        
    }
}
