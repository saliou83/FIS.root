namespace SenRevue.Business.Model
{
    /// <summary>
    /// Model d'une catégorie d'un article
    /// </summary>
    public class CategoryModel
    {
        public CategoryModel()
        {
            Label = new LabelModel();
        }
        public int Id { get; set; }
        public string Code { get; set; }
        public LabelModel Label { get; set; }
    }
}