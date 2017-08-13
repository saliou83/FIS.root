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
    public class ImageManager : Singleton<ImageManager>
    {
        public ImageManager() { }

        #region Add, Update, Delete

        /// <summary>
        /// Ajouter ou modifier une image
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ImageModel AddOrUpdateImage(ImageModel model)
        {
            try
            {
                using (var db = new senrevueEntities())
                {
                    var img = ToDbImage(model);
                    db.image.AddOrUpdate(img);
                    if (db.SaveChanges() > 0)
                    {
                        model = ToImageModel(img);
                    }
                    else
                    {
                        model = new ImageModel();
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.Current.ErrorAndThrow("Echec lors de l'ajout ou la mise à jour d'une image", ex);
            }
            return model;
        }

        /// <summary>
        /// Suppression d'une image
        /// <param name="imgId">Id de l'image</param>
        /// <returns></returns>
        public bool DeleteImage(int imgId)
        {
            bool result = false;
            try
            {
                using (var db = new senrevueEntities())
                {
                    var img = db.image.FirstOrDefault(a => a.img_id == imgId);
                    if (img.img_id > 0)
                    {
                        db.image.Remove(img);
                        result = (db.SaveChanges() > 0);
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.Current.ErrorAndThrow("Echec lors de l'ajout de la suppression d'un image imgId = " + imgId, ex);
            }
            return result;
        }

        #endregion Add, Update, Delete

        #region Get

        /// <summary>
        /// Récupérer les images d'un article
        /// </summary>
        /// <param name="artId">Id de l'article</param>
        /// <returns></returns>
        public List<ImageModel> GetArticleImages(int artId)
        {
            var result = new List<ImageModel>();
            try
            {
                using (var db = new senrevueEntities())
                {
                    var imgs = db.image.Where(c => c.article != null && c.article.Any(a => a.art_id == artId)).ToList();
                    if (imgs != null && imgs.Any())
                    {
                        result = imgs.Select(c => ToImageModel(c)).ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.Current.ErrorAndThrow("Echec lors de la récupération des images de l'article artId = " + artId, ex);
            }
            return result;
        }

        /// <summary>
        /// Récupérer les images d'une catégorie
        /// </summary>
        /// <param name="catId">Id de la catégorie</param>
        /// <returns></returns>
        public List<ImageModel> GetCategoryImages(int catId)
        {
            var result = new List<ImageModel>();
            try
            {
                using (var db = new senrevueEntities())
                {
                    var imgs = db.image.Where(c => c.category != null && c.category.Any(a => a.cat_id == catId)).ToList();
                    if (imgs != null && imgs.Any())
                    {
                        result = imgs.Select(c => ToImageModel(c)).ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.Current.ErrorAndThrow("Echec lors de la récupération des images de la catégorie catId = " + catId, ex);
            }
            return result;
        }

        /// <summary>
        /// Récupérer une image par son id
        /// </summary>
        /// <param name="imgId">Id de l'image</param>
        /// <returns></returns>
        public ImageModel GetimageById(int imgId)
        {
            var result = new ImageModel();
            try
            {
                using (var db = new senrevueEntities())
                {
                    var img = db.image.FirstOrDefault(c => c.img_id == imgId);
                    if (img != null && img.img_id > 0)
                    {
                        result = ToImageModel(img);
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.Current.ErrorAndThrow("Echec lors de la récupération de l'image imgId = " + imgId, ex);
            }
            return result;
        }

        #endregion Get
        
        #region Mapper Methods

        public image ToDbImage(ImageModel model)
        {
            var result = new image();
            if (model != null)
            {
                result.img_id = model.Id;
                result.img_title = model.Title;
                result.img_path = model.Path;
                result.img_description = model.Description;
            }
            return result;
        }


        public ImageModel ToImageModel(image model)
        {
            var result = new ImageModel();
            if (model != null)
            {
                result.Id = model.img_id;
                result.Title = model.img_title;
                result.Path = model.img_path;
                result.Description = model.img_description;
            }
            return result;
        }
        #endregion Mapper Methods
    }
}
