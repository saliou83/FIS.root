using SenRevue.Business.Data;
using SenRevue.Business.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace SenRevue.Business.Manager
{
    public class ContentManager : Singleton<ContentManager>
    {
        public ContentManager() { }

        #region Add, Update, Delete

        /// <summary>
        /// Ajouter ou modifier un contenu d'un article
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ContentModel AddOrUpdateContent(ContentModel model)
        {
            try
            {
                using (var db = new senrevueEntities())
                {
                    var contenu = ToDbContent(model);
                    db.content.AddOrUpdate(contenu);
                    if (db.SaveChanges() > 0)
                    {
                        model = ToContentModel(contenu);
                    }
                    else
                    {
                        model = new ContentModel();
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.Current.ErrorAndThrow("Echec lors de l'ajout ou la mise à jour d'un contenu", ex);
            }
            return model;
        }

        /// <summary>
        /// Suppression d'une catégorie
        /// </summary>
        /// <param name="ctnId"></param>
        /// <returns></returns>
        public bool DeleteContent(int ctnId)
        {
            bool result = false;
            try
            {
                using (var db = new senrevueEntities())
                {
                    var contenu = db.content.FirstOrDefault(a => a.ctn_id == ctnId);
                    if (contenu.ctn_id > 0)
                    {
                        db.content.Remove(contenu);
                        result = (db.SaveChanges() > 0);
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.Current.ErrorAndThrow("Echec lors de l'ajout de la suppression d'un contenu", ex);
            }
            return result;
        }

        #endregion Add, Update, Delete
        
        #region Get

        /// <summary>
        /// Récupérer les contenues d'un article
        /// </summary>
        /// <param name="artId">Id de l'article</param>
        /// <returns></returns>
        public List<ContentModel> GetArticleContents(int artId)
        {
            var result = new List<ContentModel>();
            try
            {
                using (var db = new senrevueEntities())
                {
                    var contenues = db.content.Where(c => c.art_id == artId).ToList();
                    if (contenues != null && contenues.Any())
                    {
                        result = contenues.Select(c => ToContentModel(c)).ToList();
                    } 
                }
            }
            catch (Exception ex)
            {
                LogManager.Current.ErrorAndThrow("Echec lors de la récupération des contenues de l'article artId = "+artId, ex);
            }
            return result;
        }

        /// <summary>
        /// Récupérer le contenue d'un article par son id
        /// </summary>
        /// <param name="ctnId">Id du contenu</param>
        /// <returns></returns>
        public ContentModel GetContentById(int ctnId)
        {
            var result = new ContentModel();
            try
            {
                using (var db = new senrevueEntities())
                {
                    var contenue = db.content.FirstOrDefault(c => c.ctn_id == ctnId);
                    if (contenue != null && contenue.ctn_id > 0)
                    {
                        result = ToContentModel(contenue);
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.Current.ErrorAndThrow("Echec lors de la récupération du contenue ctnId = " + ctnId, ex);
            }
            return result;
        }

        #endregion Get

        #region Mapper Methods

        public content ToDbContent(ContentModel model)
        {
            var result = new content();
            if (model != null)
            {
                result.ctn_id = model.Id;
                result.art_id = model.ArticleId;
                result.lng_id = model.LanguageId;
                result.ctn_text = model.Text;
            }
            return result;
        }

        public ContentModel ToContentModel(content model)
        {
            var result = new ContentModel();
            if (model != null)
            {
                result.Id = model.ctn_id;
                result.ArticleId = model.art_id;
                result.LanguageId = model.lng_id;
                result.Text = model.ctn_text;
            }
            return result;
        }
        #endregion Mapper Methods
    }
}
