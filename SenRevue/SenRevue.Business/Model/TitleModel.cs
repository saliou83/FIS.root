namespace SenRevue.Business.Model
{
    /// <summary>
    /// Model d'un titre d'article
    /// </summary>
    public class TitleModel
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public int LanguageId { get; set; }
        public string Text { get; set; }
    }
}