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

        /// <summary>
        /// Page des articles
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult News()
        {
            var model = new AdminNewsViewModel();
            model.Title = LabelHelpers.GetLabel("article_label");
            return View(model);
        }

        /// <summary>
        /// Page des rubriques
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Rubrics()
        {
            var model = new AdminRubricsViewModel();
            model.Title = LabelHelpers.GetLabel("rubrique_label");
            return View(model);
        }
    }
}