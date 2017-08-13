using SenRevue.Business.Data;
using SenRevue.Business.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace SenRevue.Business.Manager
{
    public class CommentManager : Singleton<CommentManager>
    {
        public CommentManager() { }

        #region Add, Update, Delete
        /// <summary>
        /// Ajouter ou modifier un commentaire
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public CommentModel AddOrUpdateComment(CommentModel model)
        {
            try
            {
                using (var db = new senrevueEntities())
                {
                    var com = ToDbComment(model);
                    db.comment.AddOrUpdate(com);
                    if (db.SaveChanges() > 0)
                    {
                        model = ToCommentModel(com);
                    }
                    else
                    {
                        model = new CommentModel();
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.Current.ErrorAndThrow("Echec lors de l'ajout ou la mise à jour d'un commentaire", ex);
            }
            return model;
        }

        /// <summary>
        /// Suppression d'un commentaire
        /// </summary>
        /// <param name="comId"></param>
        /// <returns></returns>
        public bool DeleteComment(int comId)
        {
            bool result = false;
            try
            {
                using (var db = new senrevueEntities())
                {
                    var com = db.comment.FirstOrDefault(a => a.com_id == comId);
                    if (com.com_id > 0)
                    {
                        db.comment.Remove(com);
                        result = (db.SaveChanges() > 0);
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.Current.ErrorAndThrow("Echec lors de l'ajout de la suppression d'un commentaire comId = "+comId, ex);
            }
            return result;
        }

        #endregion Add, Update, Delete

        #region Get

        /// <summary>
        /// Récupérer les commentaires d'un article
        /// </summary>
        /// <param name="artId">Id de l'article</param>
        /// <returns></returns>
        public List<CommentModel> GetArticleComments(int artId)
        {
            var result = new List<CommentModel>();
            try
            {
                using (var db = new senrevueEntities())
                {
                    var coms = db.comment.Where(c => c.art_id == artId).ToList();
                    if (coms != null && coms.Any())
                    {
                        result = coms.Select(c => ToCommentModel(c)).ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.Current.ErrorAndThrow("Echec lors de la récupération des commentaires de l'article artId = " + artId, ex);
            }
            return result;
        }

        /// <summary>
        /// Récupérer un commentaire d'un article par son id
        /// </summary>
        /// <param name="comId">Id du commentaire</param>
        /// <returns></returns>
        public CommentModel GetCommentById(int comId)
        {
            var result = new CommentModel();
            try
            {
                using (var db = new senrevueEntities())
                {
                    var com = db.comment.FirstOrDefault(c => c.com_id == comId);
                    if (com != null && com.com_id > 0)
                    {
                        result = ToCommentModel(com);
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.Current.ErrorAndThrow("Echec lors de la récupération du commentaire comId = " + comId, ex);
            }
            return result;
        }

        #endregion Get

        #region Mapper Methods

        public comment ToDbComment(CommentModel model)
        {
            var result = new comment();
            if (model != null)
            {
                result.com_id = model.Id;
                result.art_id = model.ArticleId;
                result.lng_id = model.LanguageId;
                result.com_text = model.Text;
                result.com_usermail = model.UserMail;
                result.com_username = model.UserName;
                result.parent_id = model.ParentId;
            }
            return result;
        }

        public CommentModel ToCommentModel(comment model)
        {
            var result = new CommentModel();
            if (model != null)
            {
                result.Id = model.com_id;
                result.ArticleId = model.art_id;
                result.LanguageId = model.lng_id;
                result.Text = model.com_text;
                result.UserMail = model.com_usermail;
                result.UserName = model.com_username;
                result.ParentId = model.parent_id;
            }
            return result;
        }
        #endregion Mapper Methods
    }
}
