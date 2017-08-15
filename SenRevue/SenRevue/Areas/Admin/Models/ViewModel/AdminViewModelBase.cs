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
            ApplicationName = ConfigurationManager.AppSettings["application:name"];
            Langs = CacheService.GetOrSet("application.langs", () => GetLangs());
            DefaultLang = Langs.FirstOrDefault(l => l.Current);
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
        public LanguageViewModel DefaultLang { get; set; }

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
            var curLang = GlobalHelpers.GetCurrentLang();
            var langs = LanguageManager.Current.GetLangages();
            return langs.Select(l => new LanguageViewModel()
            {
                Id = l.Id,
                Code = l.Code,
                Libelle = l.Libelle,
                Name = l.Name,
                Path = l.Path,
                Active = l.Active,
                Current = l.Code.ToLower() == curLang
            }).ToList();
        }
    }
}