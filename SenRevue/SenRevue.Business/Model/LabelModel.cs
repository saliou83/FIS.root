namespace SenRevue.Business.Model
{
    /// <summary>
    /// Model d'un label
    /// </summary>
    public class LabelModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int LanguageId { get; set; }
        public string Libelle { get; set; }
    }
}