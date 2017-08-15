using SenRevue.Areas.Admin.Models.ViewModel;
using SenRevue.Helpers;
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
            model.Title = LabelHelpers.GetLabel("admin_home_title");
            return View(model);
        }
    }
}