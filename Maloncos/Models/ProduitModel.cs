using Maloncos.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maloncos.Models
{
    /// <summary>
    /// Tout produit doit hériter de cette classe
    /// </summary>
    [Serializable]
    public class ProduitModel
    {
        public int Id { get; set; }
        public TypeProduitEnum Type { get; set; }
        public string Reference { get; set; }
        public string Libelle { get; set; }
        public double Prix { get; set; }
        public string Couleur { get; set; }
        public string Description { get; set; }
        public List<string> Image { get; set; }
    }
}