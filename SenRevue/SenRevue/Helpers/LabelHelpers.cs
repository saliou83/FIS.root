using SenRevue.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using SenRevue.Business.Manager;

namespace SenRevue.Helpers
{
    public class LabelHelpers
    {
        /// <summary>
        /// Recupérer  le label pour la langue courante de l'application
        /// </summary>
        /// <param name="lblCode">Code du label</param>
        /// <returns></returns>
        public static string GetLabel(string lblCode)
        {
            string result = string.Empty;
            try
            {
                var curLang = HttpContext.Current.Request.RequestContext.RouteData.Values["languageCode"];
                var defaultLang = (curLang != null) ? curLang.ToString() 
                    : ConfigurationManager.AppSettings["application:defaultLang"];
                var label = LabelManager.Current.GetLabel(defaultLang, lblCode);
                if (label.Id > 0)
                {
                    result = label.Libelle;
                }
                else
                {
                    result = string.Format("K_{0}", lblCode);
                }
            }
            catch (Exception ex)
            {
                LogManager.Current.Error(
                    string.Format("GetLabel(string lblCode) : Echec lors de la récupération d'un label => lblCode = {0}", 
                    lblCode), ex);
            }
            return result;
        }
    }
}