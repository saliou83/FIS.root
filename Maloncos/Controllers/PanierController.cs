using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Maloncos.Models;
using System.Web.Mvc;


namespace Maloncos.Controllers
{
    public class PanierController : Controller
    {
        //
        // GET: /Home/
        private MaloncosDBEntities _db = new MaloncosDBEntities();
        public ActionResult Index()
        {
            return RedirectToAction("Accueil");
        }
       
    }
}
