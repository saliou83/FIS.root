using SenRevue.Business.Data;
using SenRevue.Business.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenRevue.Business.Manager
{
    public class ArticleManager : Singleton<ArticleManager>
    {
        public ArticleManager() { }

        #region Add, Update, Delete
        /// <summary>
        /// Ajouter ou modifier un article
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ArticleModel AddOrUpdateArticle(ArticleModel model)
        {
            try
            {
                using (var db = new senrevueEntities())
                {
                    var article = ToDbArticle(model);
                    db.article.AddOrUpdate(article);
                    if (db.SaveChanges() > 0)
                    {
                        model = ToArticleModel(article);
                    }
                    else
                    {
                        model = new ArticleModel();
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.Current.ErrorAndThrow("Echec lors de l'ajout ou la mise à jour d'un aricle", ex);
            }
            return model;
        }

        /// <summary>
        /// Suppression d'un article
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        public bool DeleteArticle(int articleId)
        {
            bool result = false;
            try
            {
                using (var db = new senrevueEntities())
                {
                    var article = db.article.FirstOrDefault(a => a.art_id == articleId);
                    if (article.art_id > 0)
                    {
                        db.article.Remove(article);
                        result = (db.SaveChanges() > 0);                        
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.Current.ErrorAndThrow("Echec lors de l'ajout de la suppression d'un aricle", ex);
            }
            return result;
        }

        #endregion Add, Update, Delete

        #region Get

        /// <summary>
        /// Recupérer tous les articles
        /// </summary>
        /// <returns></returns>
        public List<ArticleModel> GetArticles()
        {
            var result = new List<ArticleModel>();
            try
            {
                using (var db = new senrevueEntities())
                {
                    var articles = db.article.ToList();
                    if (articles != null && articles.Any())
                    {
                        result = articles.Select(a => ToArticleModel(a)).ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.Current.ErrorAndThrow("Echec lors de la récupération de tous les articles", ex);
            }
            return result;
        }

        /// <summary>
        /// Recupérer tous les articles actifs de l'accueil
        /// </summary>
        /// <returns></returns>
        public List<ArticleModel> GetHomeActiveArticles()
        {
            var result = new List<ArticleModel>();
            try
            {
                using (var db = new senrevueEntities())
                {
                    var articles = db.article.Where(a => a.art_active && a.art_home).ToList();
                    if (articles != null && articles.Any())
                    {
                        result = articles.Select(a => ToArticleModel(a)).ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.Current.ErrorAndThrow("Echec lors de la récupération de tous les articles actifs de l'accueil", ex);
            }
            return result;
        }
        
        /// <summary>
        /// Recupérer tous les articles actifs d'une catégorie
        /// </summary>
        /// <param name="catId">Id de la catégorie</param>
        /// <returns></returns>
        public List<ArticleModel> GetCategoryActiveArticles(int catId)
        {
            var result = new List<ArticleModel>();
            try
            {
                using (var db = new senrevueEntities())
                {
                    var articles = db.article.Where(a => a.art_active && a.category != null 
                    && a.category.Any(c => c.cat_id == catId)).ToList();
                    if (articles != null && articles.Any())
                    {
                        result = articles.Select(a => ToArticleModel(a)).ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.Current.ErrorAndThrow("Echec lors de la récupération de tous les articles actifs d'une catégorie", ex);
            }
            return result;
        }

        /// <summary>
        /// Recupérer tous les articles
        /// </summary>
        /// <returns></returns>
        public ArticleModel GetArticleById(int id)
        {
            var result = new ArticleModel();
            try
            {
                using (var db = new senrevueEntities())
                {
                    var article = db.article.FirstOrDefault(a => a.art_id == id);
                    if (article != null && article.art_id > 0)
                    {
                        result = ToArticleModel(article);
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.Current.ErrorAndThrow("Echec lors de la récupération de tous les articles", ex);
            }
            return result;
        }

        #endregion Get

        #region Helper Methods

        public article ToDbArticle(ArticleModel model)
        {
            var result = new article();
            if (model != null)
            {
                result.art_id = model.Id;
                result.art_active = model.IsActive;
                result.art_home = model.IsHome;
                result.art_start_date = model.StartDate;
                result.art_end_date = model.EndDate;
                result.art_user_id = model.UserId;
                result.creation_date = model.CreationDate;
                result.modification_date = model.ModificationDate;
                result.art_source = model.Source;
                if (model.Categories != null && model.Categories.Any())
                {
                    result.category = (ICollection<category>)model.Categories.Select(m => CategoryManager.Current.ToDbCategory(m));
                }
                if (model.Languages != null && model.Languages.Any())
                {
                    result.language = (ICollection<language>)model.Languages.Select(m => LanguageManager.Current.ToDbLanguage(m));
                }
                if (model.Images != null && model.Images.Any())
                {
                    result.image = (ICollection<image>)model.Images.Select(m => ImageManager.Current.ToDbImage(m));
                }
                if (model.Titles != null && model.Titles.Any())
                {
                    result.title = (ICollection<title>)model.Titles.Select(m => TitleManager.Current.ToDbTitle(m));
                }
                if (model.Contents != null && model.Contents.Any())
                {
                    result.content = (ICollection<content>)model.Contents.Select(m => ContentManager.Current.ToDbContent(m));
                }
                if (model.Comments != null && model.Comments.Any())
                {
                    result.comment = (ICollection<comment>)model.Comments.Select(m => CommentManager.Current.ToDbComment(m));
                }
            }
            return result;
        }

        public ArticleModel ToArticleModel(article model)
        {
            var result = new ArticleModel();
            if (model != null)
            {
                result.Id = model.art_id;
                result.IsActive = model.art_active;
                result.IsHome = model.art_home;
                result.StartDate = model.art_start_date;
                result.EndDate = model.art_end_date;
                result.UserId = model.art_user_id;
                result.CreationDate = model.creation_date;
                result.ModificationDate = model.modification_date;
                result.Source = model.art_source;
                if (model.language != null && model.language.Any())
                {
                    result.Languages = model.language.Select(l => LanguageManager.Current.ToLanguageModel(l)).ToList();
                }
                if (model.comment != null && model.comment.Any())
                {
                    result.Comments = model.comment.Select(l => CommentManager.Current.ToCommentModel(l)).ToList();
                }
                if (model.title != null && model.title.Any())
                {
                    result.Titles = model.title.Select(l => TitleManager.Current.ToTitleModel(l)).ToList();
                }
                if (model.content != null && model.content.Any())
                {
                    result.Contents = model.content.Select(l => ContentManager.Current.ToContentModel(l)).ToList();
                }
                if (model.category != null && model.category.Any())
                {
                    result.Categories = model.category.Select(l => CategoryManager.Current.ToCategoryModel(l)).ToList();
                }
                if (model.image != null && model.image.Any())
                {
                    result.Images = model.image.Select(l => ImageManager.Current.ToImageModel(l)).ToList();
                }
            }
            return result;
        }

        #endregion Privates Methods
    }
}
