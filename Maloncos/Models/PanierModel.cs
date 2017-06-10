using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maloncos.Models
{
    public class PanierModel
    {
        private Dictionary<int, Produit> _Produits;
        public string NomPanier;
        public string idclient;

        public Dictionary<int, Produit> Produits
        {
            get
            {
                if (_Produits == null)
                    _Produits = new Dictionary<int, Produit>();
                return _Produits;
            }
            set
            {
                _Produits = value;
            }
        }

    }
    public class Produit
    {
        public int ID;
        public Vetements name;
    }
    public partial class _Default : System.Web.UI.Page
    {

        public PanierModel MonPanier
        {
            get
            {
                return (PanierModel)Session["Panier"];
            }
            set
            {
                Session["Panier"] = value;
            }
        }

    }
}