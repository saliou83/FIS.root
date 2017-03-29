using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maloncos.Models
{
    public class ClientsModel
    {
        public int Id_Clients { get; set; }

        public String Nom_Client { get; set; }
        public String Prenom_Client { get; set; }
        public String Adresse { get; set; }
        public String Code_postal { get; set; }
        public String Genre { get; set; }
        public String Email_Client { get; set; }
        public String Password { get; set; }
    }
}