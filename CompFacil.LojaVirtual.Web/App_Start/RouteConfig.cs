using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CompFacil.LojaVirtual.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //1 - Inicio
            routes.MapRoute(
                null, "",
                new
                {
                    Controller = "Vitrine",
                    Action = "ListaProdutos",
                    Categorias = (string)null,
                    pagina = 1
                }
            );

            //2
            routes.MapRoute(
                null, "Pagina{pagina}",
                new
                {
                    Controller = "Vitrine",
                    Action = "ListaProdutos",
                    Categorias = (string)null
                },
                    new
                    {
                        pagina = @"\d+"
                    }
            );

            //3
            routes.MapRoute(null, "{categoria}",
                new
                {
                    controller = "Vitrine",
                    action = "ListaProdutos",
                    pagina = 1
                }
            );

            //4
            routes.MapRoute(
                null, "{categoria}Pagina{pagina}",
                new
                {
                    Controller = "Vitrine",
                    Action = "ListaProdutos",
                },
                    new
                    {
                        pagina = @"\d+"
                    }
            );

            routes.MapRoute(null, "{controller}/{action}");
        }
    }
}
