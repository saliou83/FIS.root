namespace SenRevue.Business.Model
{
    /// <summary>
    /// Model d'une langue
    /// </summary>
    public class LanguageModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Libelle { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public bool Active { get; set; }
    }
}