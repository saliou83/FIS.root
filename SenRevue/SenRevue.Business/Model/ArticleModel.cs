using System;
using System.Collections.Generic;

namespace SenRevue.Business.Model
{
    public class ArticleModel
    {
        public ArticleModel()
        {
            Comments = new List<CommentModel>();
            Contents = new List<ContentModel>();
            Titles = new List<TitleModel>();
            Categories = new List<CategoryModel>();
            Images = new List<ImageModel>();
        }

        public int Id { get; set; }

        public bool IsActive { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModificationDate { get; set; }

        public int? UserId { get; set; }

        public bool IsHome { get; set; }
        public string Source { get; set; }
                
        public List<CommentModel> Comments { get; set; }

        public List<ContentModel> Contents { get; set; }

        public List<TitleModel> Titles { get; set; }

        public List<CategoryModel> Categories { get; set; }
        public List<ImageModel> Images { get; set; }
        public List<LanguageModel> Languages { get; set; }
    }
}