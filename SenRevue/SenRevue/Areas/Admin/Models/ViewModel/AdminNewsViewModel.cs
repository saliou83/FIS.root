using SenRevue.Business.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SenRevue.Areas.Admin.Models.ViewModel
{
    public class AdminNewsViewModel: AdminViewModelBase
    {
        public AdminNewsViewModel()
        {
            Articles = new List<ArticleModel>();
        }

        public List<ArticleModel> Articles { get; set; }
    }
}