using SenRevue.Business.Data;
using SenRevue.Business.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace SenRevue.Business.Manager
{
    public class TitleManager : Singleton<TitleManager>
    {
        public TitleManager() { }

        #region Add, Update, Delete

        /// <summary>
        /// Ajouter ou modifier un Titre
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public TitleModel AddOrUpdateTitle(TitleModel model)
        {
            try
            {
                using (var db = new senrevueEntities())
                {
                    var contenu = ToDbTitle(model);
                    db.title.AddOrUpdate(contenu);
                    if (db.SaveChanges() > 0)
                    {
                        model = ToTitleModel(contenu);
                    }
                    else
                    {
                        model = new TitleModel();
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.Current.ErrorAndThrow("Echec lors de l'ajout ou la mise à jour d'un titre", ex);
            }
            return model;
        }

        /// <summary>
        /// Suppression d'un titre d'un article
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        public bool Deletetitle(int titId)
        {
            bool result = false;
            try
            {
                using (var db = new senrevueEntities())
                {
                    var contenu = db.title.FirstOrDefault(a => a.tit_id == titId);
                    if (contenu.tit_id > 0)
                    {
                        db.title.Remove(contenu);
                        result = (db.SaveChanges() > 0);
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.Current.ErrorAndThrow("Echec lors de l'ajout de la suppression d'un titre titId = "+titId, ex);
            }
            return result;
        }

        #endregion Add, Update, Delete

        #region Get

        /// <summary>
        /// Récuperer les titres d'un article
        /// </summary>
        /// <param name="artId"></param>
        /// <returns></returns>
        public List<TitleModel> GetArticleTitles(int artId)
        {
            var result = new List<TitleModel>();
            try
            {
                using (var db = new senrevueEntities())
                {
                    var titres = db.title.Where(t => t.art_id == artId).ToList();
                    if (titres != null && titres.Any())
                    {
                        result = titres.Select(c => ToTitleModel(c)).ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.Current.ErrorAndThrow("Echec lors de la récupération des titres de l'article artId = " + artId, ex);
            }
            return result;
        }

        /// <summary>
        /// Récupérer le titre d'un article par son id
        /// </summary>
        /// <param name="titId">Id du titre</param>
        /// <returns></returns>
        public TitleModel GetTitleById(int titId)
        {
            var result = new TitleModel();
            try
            {
                using (var db = new senrevueEntities())
                {
                    var titre = db.title.FirstOrDefault(c => c.tit_id == titId);
                    if (titre != null && titre.tit_id > 0)
                    {
                        result = ToTitleModel(titre);
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.Current.ErrorAndThrow("Echec lors de la récupération du titre titId = " + titId, ex);
            }
            return result;
        }

        #endregion Get

        #region Mapper Methods

        public title ToDbTitle(TitleModel model)
        {
            var result = new title();
            if (model != null)
            {
                result.tit_id = model.Id;
                result.art_id = model.ArticleId;
                result.lng_id = model.LanguageId;
                result.tit_text = model.Text;
            }
            return result;
        }

        public TitleModel ToTitleModel(title model)
        {
            var result = new TitleModel();
            if (model != null)
            {
                result.Id = model.tit_id;
                result.ArticleId = model.art_id;
                result.LanguageId = model.lng_id;
                result.Text = model.tit_text;
            }
            return result;
        }

        #endregion Mapper Methods
    }
}
