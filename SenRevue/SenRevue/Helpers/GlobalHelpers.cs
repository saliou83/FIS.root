using SenRevue.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Net.Mail;
using System.Web.Mvc;
using SenRevue.Business.Model;
using SenRevue.Business.Manager;
using SenRevue.Areas.Admin.Models.ViewModel;

namespace SenRevue.Helpers
{
    public class GlobalHelper
    {
        /// <summary>
        /// Verifie si un email est valide
        /// </summary>
        /// <param name="emailaddress"></param>
        /// <returns></returns>
        public static bool IsEmailValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="Tenum"></typeparam>
        /// <param name="values"></param>
        /// <returns></returns>
        public static List<SelectListItem> EnumToSelectListItem<Tenum>()
        {
            var result = new List<SelectListItem>()
            {
                {
                    new SelectListItem
                    {
                        Text = string.Format("-- {0} --",LabelHelpers.GetLabel("select_label")),
                        Value = string.Empty
                    }
                }
            };
            result.AddRange(Enum.GetValues(typeof(Tenum)).Cast<Tenum>()
                .Select(v => new SelectListItem
                {
                    Text = LabelHelpers.GetLabel(v.ToString()),
                    Value = v.ToString()
                }).ToList());

            return result.ToList();
        }

        /// <summary>
        /// Retourne la langue courante 
        /// </summary>
        /// <returns></returns>
        public static LanguageModel GetCurrentLanguage()
        {
            var result = new LanguageModel();
            try
            {
                var curLang = HttpContext.Current.Request.RequestContext.RouteData.Values["languageCode"];
                var defaultLang = (curLang != null) ? curLang.ToString()
                    : ConfigurationManager.AppSettings["application:defaultLang"];
                result = LanguageManager.Current.GetLangageByCode(defaultLang);
            }
            catch (Exception ex)
            {
                LogManager.Current.Error("GGetCurrentLanguage() : Echec lors de la récupération de la langue en cours.", ex);
                throw ex;
            }

            return result;

        }

        #region Article

        /// <summary>
        /// Retourne une article pour une langue
        /// </summary>
        /// <param name="model"></param>
        /// <param name="lang"></param>
        /// <returns></returns>
        public static ArticleViewModel ToArticleViewModel(ArticleModel model, LanguageModel lang)
        {
            var result = new ArticleViewModel();
            if (model != null)
            {
                result.Id = model.Id;
                result.IsActive = model.IsActive;
                result.IsHome = model.IsHome;
                result.StartDate = model.StartDate;
                result.EndDate = model.EndDate;
                result.UserId = model.UserId;
                result.CreationDate = model.CreationDate;
                result.ModificationDate = model.ModificationDate;
                result.Source = model.Source;
                result.Language = lang;
                result.Title = model.Titles.FirstOrDefault(t => t.LanguageId == lang.Id);
                result.Content = model.Contents.FirstOrDefault(c => c.LanguageId == lang.Id);
                result.Comments = model.Comments.Where(c => c.LanguageId == lang.Id).ToList();
                result.Categories = model.Categories;
                result.Images = model.Images;
            }
            return result;
        }
        #endregion Article
    }
}