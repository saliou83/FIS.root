using System.Configuration;
using System.Web.Mvc;

namespace SenRevue.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{languageCode}/{controller}/{action}/{id}",
                new { languageCode = ConfigurationManager.AppSettings["application:defaultLang"],
                    controller = "Admin", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}