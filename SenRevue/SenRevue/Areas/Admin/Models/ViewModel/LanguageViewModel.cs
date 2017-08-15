using SenRevue.Business.Model;

namespace SenRevue.Areas.Admin.Models.ViewModel
{
    public class LanguageViewModel: LanguageModel
    {
        /// <summary>
        /// Détermine la langue courante
        /// </summary>
        public bool Current { get; set; }
    }
}