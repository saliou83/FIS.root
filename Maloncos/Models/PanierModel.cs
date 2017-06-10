using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maloncos.Models
{
    [Serializable]
    public class PanierModel
    {
        private List<ProduitPanierModel> _Produits;
        public string NomPanier;
        public string idclient;

        public List<ProduitPanierModel> Produits
        {
            get
            {
                if (_Produits == null)
                    _Produits = new List<ProduitPanierModel>();
                return _Produits;
            }
            set
            {
                _Produits = value;
            }
        }

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