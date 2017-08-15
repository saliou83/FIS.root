using SenRevue.Business.Manager;
using SenRevue.Business.Model;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SenRevue.Services;
using SenRevue.Helpers;

namespace SenRevue.Areas.Admin.Models.ViewModel
{
    public class AdminViewModelBase
    {
        public AdminViewModelBase()
        {
            DefaultLang = HttpContext.Current.Request.RequestContext.RouteData.Values["languageCode"].ToString();
            ApplicationName = ConfigurationManager.AppSettings["application:name"];
            Langs = CacheService.GetOrSet("application.langs", () => GetLangs());
        }

        /// <summary>
        /// Titre de la page
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Nom de l'application
        /// </summary>
        public string ApplicationName { get; set; }
        
        /// <summary>
        /// La langue courante
        /// </summary>
        public string DefaultLang { get; set; }

        /// <summary>
        /// Liste des langues
        /// </summary>
        public List<LanguageViewModel> Langs { get; set; }

        /// <summary>
        /// Récuperer la liste de toutes les langues
        /// </summary>
        /// <returns></returns>
        private List<LanguageViewModel> GetLangs()
        {
            var langs = LanguageManager.Current.GetLangages();
            var currentUrl = HttpContext.Current.Request.Url.AbsoluteUri;
            if (currentUrl.ToLower().Contains(string.Format("/{0}/",DefaultLang)))
            {
                currentUrl = currentUrl.Replace(string.Format("/{0}/", DefaultLang), "/{0}/");
            }
            else if (currentUrl.ToLower().EndsWith(string.Format("/{0}", DefaultLang)))
            {
                currentUrl = currentUrl.Replace(string.Format("/{0}", DefaultLang), "/{0}");
            }
            else
            {
                currentUrl = currentUrl + "/{0}";
            }
            return langs.Where(l => l.Active).Select(l => new LanguageViewModel()
            {
                Id = l.Id,
                Code = l.Code,
                Libelle = l.Libelle,
                Name = l.Name,
                Path = l.Path,
                Active = l.Active,
                Current = l.Code.ToLower() == DefaultLang,
                Url = string.Format(currentUrl,l.Code)
            }).ToList();
        }
    }
}