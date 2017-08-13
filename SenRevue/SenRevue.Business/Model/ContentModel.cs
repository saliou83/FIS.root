namespace SenRevue.Business.Model
{
    /// <summary>
    /// Model du contenu d'un article
    /// </summary>
    public class ContentModel
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public int LanguageId { get; set; }
        public string Text { get; set; }
    }
}