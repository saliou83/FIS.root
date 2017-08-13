using SenRevue.Business.Data;
using SenRevue.Business.Model;
using System;
using System.Linq;

namespace SenRevue.Business.Manager
{
    public class LabelManager : Singleton<LabelManager>
    {
        public LabelManager() { }

        #region Get

        /// <summary>
        /// Récuperer un label par son code et le code de la langue
        /// </summary>
        /// <param name="lngCode">code de la langue(exemple "fr")</param>
        /// <param name="lblCode">code du label</param>
        /// <returns></returns>
        public LabelModel GetLabel(string lngCode,string lblCode)
        {
            var result = new LabelModel();
            try
            {
                if (!string.IsNullOrEmpty(lngCode) && !string.IsNullOrEmpty(lblCode))
                {
                    using (var db = new senrevueEntities())
                    {
                        var langue = db.language.FirstOrDefault(l => !string.IsNullOrEmpty(l.lng_code) && l.lng_code.ToUpper() == lngCode.ToUpper());
                        if (langue != null && langue.lng_id > 0)
                        {
                            var label = db.label.FirstOrDefault(l => (!string.IsNullOrEmpty(l.lbl_code) && l.lbl_code.ToUpper() == lblCode.ToUpper()) && l.lng_id == langue.lng_id);
                            if (label != null)
                            {
                                result = ToLabelModel(label);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.Current.ErrorAndThrow(
                    string.Format("Echec lors de la récupération d'un label => lngCode = {0}, lblCode = {1}", lngCode, lblCode), ex);
            }
            return result;
        }

        /// <summary>
        /// Récuperer un label par son code et l'id de la langue
        /// </summary>
        /// <param name="lngId">Id de la langue</param>
        /// <param name="lblCode">code du label</param>
        /// <returns></returns>
        public LabelModel GetLabel(int lngId, string lblCode)
        {
            var result = new LabelModel();
            try
            {
                if (lngId > 0 && !string.IsNullOrEmpty(lblCode))
                {
                    using (var db = new senrevueEntities())
                    {
                        var label = db.label.FirstOrDefault(l => (!string.IsNullOrEmpty(l.lbl_code) && l.lbl_code.ToUpper() == lblCode.ToUpper()) && l.lng_id == lngId);
                        if (label != null)
                        {
                            result = ToLabelModel(label);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.Current.ErrorAndThrow(
                    string.Format("Echec lors de la récupération d'un label => lngId = {0}, lblCode = {1}", lngId, lblCode), ex);
            }
            return result;
        }

        #endregion Get

        #region Mapper Methods

        public label ToDbLabel(LabelModel model)
        {
            var result = new label();
            if (model != null)
            {
                result.lbl_id = model.Id;
                result.lng_id = model.LanguageId;
                result.lbl_code = model.Code;
                result.lbl_libelle = model.Libelle;
            }
            return result;
        }

        public LabelModel ToLabelModel(label model)
        {
            var result = new LabelModel();
            if (model != null)
            {
                result.Id = model.lbl_id;
                result.Code = model.lbl_code;
                result.LanguageId = model.lng_id;
                result.Libelle = model.lbl_libelle;
            }
            return result;
        }
        #endregion Mapper Methods
    }
}
