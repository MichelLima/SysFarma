using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SysFarma_Asp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

           //Rota de url criada para acesso SysAdmim
            routes.MapRoute(
                name:"painel",
                url: "Painel",
                defaults: new {Controller = "PainelAdm", Action="Painel"}
                    );
                
            
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}