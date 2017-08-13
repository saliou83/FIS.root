using SenRevue.Business.Data;
using SenRevue.Business.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace SenRevue.Business.Manager
{
    public class LanguageManager : Singleton<LanguageManager>
    {
        public LanguageManager() { }

        #region Add, Update, Delete

        /// <summary>
        /// Ajouter ou modifier une langue
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public LanguageModel AddOrUpdateLanguage(LanguageModel model)
        {
            try
            {
                using (var db = new senrevueEntities())
                {
                    var lng = ToDbLanguage(model);
                    db.language.AddOrUpdate(lng);
                    if (db.SaveChanges() > 0)
                    {
                        model = ToLanguageModel(lng);
                    }
                    else
                    {
                        model = new LanguageModel();
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.Current.ErrorAndThrow("Echec lors de l'ajout ou la mise à jour d'une langue", ex);
            }
            return model;
        }

        #endregion Add, Update, Delete

        #region Get

        /// <summary>
        /// Récuperer toutes les langues
        /// </summary>
        /// <returns></returns>
        public List<LanguageModel> GetLangages()
        {
            var results = new List<LanguageModel>();
            try
            {
                using (var db = new senrevueEntities())
                {
                    var lngs = db.language.ToList();
                    if (lngs != null && lngs.Any())
                    {
                        results = lngs.Select(l => ToLanguageModel(l)).ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.Current.ErrorAndThrow("Echec lors de la récupération de toutes les langues", ex);
            }
            return results;
        }

        /// <summary>
        /// Récuperer une langue par son id
        /// </summary>
        /// <param name="lngId">Id de la langue</param>
        /// <returns></returns>
        public LanguageModel GetLangageById(int lngId)
        {
            var result = new LanguageModel();
            try
            {
                using (var db = new senrevueEntities())
                {
                    var lng = db.language.FirstOrDefault(l => l.lng_id == lngId);
                    if (lng != null && lng.lng_id > 0)
                    {
                        result = ToLanguageModel(lng);
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.Current.ErrorAndThrow("Echec lors de la récupération de la langue lngId = "+ lngId, ex);
            }
            return result;
        }

        /// <summary>
        /// Récuperer une langue par son code
        /// </summary>
        /// <param name="code">code de la langue</param>
        /// <returns></returns>
        public LanguageModel GetLangageByCode(string code)
        {
            var result = new LanguageModel();
            try
            {
                if (!string.IsNullOrEmpty(code))
                {
                    using (var db = new senrevueEntities())
                    {
                        var lng = db.language.FirstOrDefault(l => !string.IsNullOrEmpty(l.lng_code) && l.lng_code.ToUpper() == code.ToUpper());
                        if (lng != null && lng.lng_id > 0)
                        {
                            result = ToLanguageModel(lng);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.Current.ErrorAndThrow("Echec lors de la récupération de la langue lngCode = " + code, ex);
            }
            return result;
        }

        #endregion Get

        #region Mapper Methods

        public language ToDbLanguage(LanguageModel model)
        {
            var result = new language();
            if (model != null)
            {
                result.lng_id = model.Id;
                result.lng_code = model.Code;
                result.lng_image_name = model.Name;
                result.lng_image_path = model.Path;
                result.lng_libelle = model.Libelle;
                result.lng_active = model.Active;
            }
            return result;
        }

        public LanguageModel ToLanguageModel(language model)
        {
            var result = new LanguageModel();
            if (model != null)
            {
                result.Id = model.lng_id;
                result.Code = model.lng_code;
                result.Name = model.lng_image_name;
                result.Path = model.lng_image_path;
                result.Libelle = model.lng_libelle;
                result.Active = model.lng_active;
            }
            return result;
        }

        #endregion Mapper Methods
    }
}
