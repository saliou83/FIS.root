using SenRevue.Business.Data;
using SenRevue.Business.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace SenRevue.Business.Manager
{
    public class CategoryManager : Singleton<CategoryManager>
    {
        public CategoryManager() { }

        #region Add, Update, Delete

        /// <summary>
        /// Ajouter ou modifier une catégorie
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public CategoryModel AddOrUpdateCategory(CategoryModel model)
        {
            try
            {
                using (var db = new senrevueEntities())
                {
                    var categorie = ToDbCategory(model);
                    db.category.AddOrUpdate(categorie);
                    if (db.SaveChanges() > 0)
                    {
                        model = ToCategoryModel(categorie);
                    }
                    else
                    {
                        model = new CategoryModel();
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.Current.ErrorAndThrow("Echec lors de l'ajout ou la mise à jour d'une categorie", ex);
            }
            return model;
        }
        
        /// <summary>
        /// Suppression d'une catégorie
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        public bool DeleteCategory(int catId)
        {
            bool result = false;
            try
            {
                using (var db = new senrevueEntities())
                {
                    var categorie = db.category.FirstOrDefault(a => a.cat_id == catId);
                    if (categorie.cat_id > 0)
                    {
                        db.category.Remove(categorie);
                        result = (db.SaveChanges() > 0);
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.Current.ErrorAndThrow("Echec lors de l'ajout de la suppression d'une catégorie", ex);
            }
            return result;
        }

        #endregion Add, Update, Delete

        #region Get

        /// <summary>
        /// Récupérer toutes les catégories
        /// </summary>
        /// <returns></returns>
        public List<CategoryModel> GetCategories()
        {
            var result = new List<CategoryModel>();
            try
            {
                using (var db = new senrevueEntities())
                {
                    var categories = db.category.ToList();
                    if (categories != null && categories.Any())
                    {
                        result = categories.Select(a => ToCategoryModel(a)).ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.Current.ErrorAndThrow("Echec lors de la récupération de toutes les catégories.", ex);
            }
            return result;
        }

        /// <summary>
        /// Récupérer une categorie par son id
        /// </summary>
        /// <returns></returns>
        public CategoryModel GetCategorieById(int catId)
        {
            var result = new CategoryModel();
            try
            {
                using (var db = new senrevueEntities())
                {
                    var categorie = db.category.FirstOrDefault(c => c.cat_id == catId);
                    if (categorie != null && categorie.cat_id > 0)
                    {
                        result = ToCategoryModel(categorie);
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.Current.ErrorAndThrow("Echec lors de la récupération de la catégorie Id = "+catId, ex);
            }
            return result;
        }

        #endregion Get

        #region Mapper Methods

        public category ToDbCategory(CategoryModel model)
        {
            var result = new category();
            if (model != null)
            {
                result.cat_id = model.Id;
                result.categ_code = model.Code;
            }
            return result;
        }

        public CategoryModel ToCategoryModel(category model)
        {
            var result = new CategoryModel();
            if (model != null)
            {
                result.Id = model.cat_id;
                result.Code = model.categ_code;
            }
            return result;
        }
        #endregion Mapper Methods
    }
}
