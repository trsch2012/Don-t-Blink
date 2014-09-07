using System.Web.Mvc;

namespace DontBlink.API.Areas.v2
{
    public class v2AreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "v2";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "v2_default",
                "v2/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}