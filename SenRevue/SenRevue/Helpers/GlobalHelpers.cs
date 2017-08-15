using SenRevue.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace SenRevue.Helpers
{
    public class GlobalHelpers
    {
        /// <summary>
        /// Recupérer ou met à jour la langue courante de l'application
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentLang()
        {
            var defaulLang = ConfigurationManager.AppSettings["application:defaultLang"];
            if (!string.IsNullOrEmpty(defaulLang))
            {
                defaulLang = defaulLang.ToLower();
            }
            else
            {
                defaulLang = string.Empty;
            }
            return SessionService.GetOrSet("application.currentLang", () 
                => defaulLang);
        }
    }
}