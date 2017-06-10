using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maloncos.Models
{
    /// <summary>
    /// Un produit dans un panier
    /// </summary>
    [Serializable]
    public class ProduitPanierModel: ProduitModel
    {
        public int quantite { get; set; }
    }
}