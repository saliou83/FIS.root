namespace SenRevue.Business.Model
{
    /// <summary>
    /// Model de commentaire d'un article
    /// </summary>
    public class CommentModel
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public int LanguageId { get; set; }
        public int? ParentId { get; set; }
        public string UserName { get; set; }
        public string UserMail { get; set; }
        public string Text { get; set; }        
    }
}