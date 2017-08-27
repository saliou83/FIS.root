using SenRevue.Areas.Admin.Models.ViewModel;
using SenRevue.Business.Manager;
using SenRevue.Business.Model;
using SenRevue.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
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

        #region Articles

        /// <summary>
        /// Page des articles
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public ActionResult News()
        {
            var model = new AdminNewsViewModel();
            model.Title = LabelHelpers.GetLabel("article_label");
            return View(model);
        }


        [HttpPost]
        [Authorize]
        public ActionResult LoadNewsData(string langCode)
        {
            var articles = ArticleManager.Current.GetArticles();
            try
            {
                //Get parameters
                string search = Request.Form.GetValues("search[value]").FirstOrDefault();

                // get Start (paging start index) and length (page size for paging)
                var draw = Request.Form.GetValues("draw").FirstOrDefault();
                var start = Request.Form.GetValues("start").FirstOrDefault();
                var length = Request.Form.GetValues("length").FirstOrDefault();
                //Get Sort columns value
                var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
                var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();

                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;

                var result = new List<ArticleViewModel>();
                if (articles.Any())
                {
                    LanguageModel lang = !string.IsNullOrEmpty(langCode) ? LanguageManager.Current.GetLangageByCode(langCode)
                        : GlobalHelper.GetCurrentLanguage();
                    result.AddRange(articles.Select(c => GlobalHelper.ToArticleViewModel(c, lang)));

                    if (!string.IsNullOrEmpty(search))
                    {
                        result = result.Where(r => (r.Title != null & !string.IsNullOrEmpty(r.Title.Text) && r.Title.Text.Contains(search))
                                                    || (r.Content!= null & !string.IsNullOrEmpty(r.Content.Text) && r.Content.Text.Contains(search))
                                                    || (r.Categories.Any(c => c.Label != null && c.Label.Libelle.Contains(search)))
                                                    || (!string.IsNullOrEmpty(r.Source) && r.Source.Contains(search))).ToList();
                    }

                    if (!string.IsNullOrEmpty(sortColumn))
                    {
                        result = SortNews(result, sortColumn, sortColumnDir);
                    }

                }

                int totalRecords = result.Count();

                var data = (pageSize > -1) ? result.Skip(skip).Take(pageSize).ToList() : result.ToList();

                return Json(new { draw = draw, recordsFiltered = totalRecords, recordsTotal = totalRecords, data = data }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        #endregion Articles

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

        #region privates methodes

        private List<ArticleViewModel> SortNews(List<ArticleViewModel> articles, string sortColumn, string order = "asc")
        {
            var result = new List<ArticleViewModel> ();

            if (order == "asc")
            {
                if (sortColumn ==  "Title")
                {
                    result = articles.OrderBy(a => a.Title).ToList();
                }
                else if (sortColumn == "Source")
                {
                    result = articles.OrderBy(a => a.Source).ToList();
                }
                else if (sortColumn == "Content")
                {
                    result = articles.OrderBy(a => a.Content.Text).ToList();
                }
                else if (sortColumn == "StartDate")
                {
                    result = articles.OrderBy(a => a.StartDate).ToList();
                }
            }
            else
            {
                if (sortColumn == "Title")
                {
                    result = articles.OrderByDescending(a => a.Title).ToList();
                }
                else if (sortColumn == "Source")
                {
                    result = articles.OrderByDescending(a => a.Source).ToList();
                }
                else if (sortColumn == "Content")
                {
                    result = articles.OrderByDescending(a => a.Content.Text).ToList();
                }
                else if (sortColumn == "StartDate")
                {
                    result = articles.OrderByDescending(a => a.StartDate).ToList();
                }
            }

            return result;
        }

        #endregion privates methodes
    }
}