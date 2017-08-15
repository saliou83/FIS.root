using SenRevue.Areas.Admin.Models.ViewModel;
using SenRevue.Business.Manager;
using System.Web.Mvc;

namespace SenRevue.Areas.Admin.Controllers
{
    // GET: Admin/Admin
    [Authorize]
    public class AdminController : Controller
    {
        /// <summary>
        /// Page d'accueil
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            var model = new AdminHomeViewModel();
            model.Title = LabelManager.Current.GetLabel(model.DefaultLang.Code, "admin_home_title").Libelle;
            return View(model);
        }
    }
}