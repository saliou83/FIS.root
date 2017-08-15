using SenRevue.Business.Model;

namespace SenRevue.Areas.Admin.Models.ViewModel
{
    public class LanguageViewModel: LanguageModel
    {
        /// <summary>
        /// Détermine la langue courante
        /// </summary>
        public bool Current { get; set; }

        /// <summary>
        /// Url de la langue
        /// </summary>
        public string Url { get; set; }
    }
}