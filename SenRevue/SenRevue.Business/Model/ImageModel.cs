namespace SenRevue.Business.Model
{
    /// <summary>
    /// Model d'une image
    /// </summary>
    public class ImageModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
    }
}