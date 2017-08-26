using SenRevue.Business.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SenRevue.Areas.Admin.Models.ViewModel
{
    public class AdminRubricsViewModel: AdminViewModelBase
    {
        public AdminRubricsViewModel()
        {
            Rubrics = new List<CategoryModel>();
        }

        public List<CategoryModel> Rubrics { get; set; }
    }
}