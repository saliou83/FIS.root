using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Maloncos.Models
{
    public class VetementModel :ProduitModel
    {
        public string Genre { get; set; }

        public string Categorie { get; set; }

        public double Taille { get; set; }
    }    
}