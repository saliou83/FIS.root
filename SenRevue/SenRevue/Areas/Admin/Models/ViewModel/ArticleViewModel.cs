using SenRevue.Business.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SenRevue.Areas.Admin.Models.ViewModel
{
    public class ArticleViewModel
    {
        public ArticleViewModel()
        {
            Content = new ContentModel();
            Title = new TitleModel();
            Comments = new List<CommentModel>();
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
        
        public ContentModel Content { get; set; }

        public TitleModel Title { get; set; }

        public List<CommentModel> Comments { get; set; }

        public List<CategoryModel> Categories { get; set; }
        public List<ImageModel> Images { get; set; }
        public LanguageModel Language { get; set; }
    }
}