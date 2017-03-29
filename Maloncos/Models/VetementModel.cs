using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Maloncos.Models
{
    public class VetementModel
    {
        public int Id_vetement { get; set; }

        public String Type_vetement { get; set; }
        public String Categorie { get; set; }
        public String Genre_vetement { get; set; }
        public String Reference_vetement { get; set; }
        public String Libelle_vetement { get; set; }
        public String Prix_vetement { get; set; }
        public String Couleur { get; set; }
        public String Description { get; set; }
        public String Image { get; set; }
        public String Image1 { get; set; }
        public String Image2 { get; set; }
        public String Image3 { get; set; }
        public String Image4 { get; set; }
        public String Prix_unit { get; set; }


    }

}