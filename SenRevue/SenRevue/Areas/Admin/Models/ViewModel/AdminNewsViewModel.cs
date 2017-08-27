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
            Articles = new List<ArticleViewModel>();
        }

        public List<ArticleViewModel> Articles { get; set; }
    }
}