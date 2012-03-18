using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{resource}.ico/{*pathInfo}");

            routes.IgnoreRoute("image/{*pathInfo}");
            routes.IgnoreRoute("imagens/{*pathInfo}");

            routes.MapRoute(
                "Script",
                "js/{arquivo}/{token}.js",
                new
                {
                    controller = "JavaScript",
                    action = "GetScript",
                    arquivo = "",
                    token = ""
                }
            );

            routes.MapRoute(
                "Styles",
                "css/{arquivo}/{token}.css",
                new
                {
                    controller = "CSS",
                    action = "GetStyle",
                    arquivo = "",
                    token = ""
                }
            );

            //busca
            routes.MapRoute(
                            "Buscar",
                            "b/{*query}",
                            new { controller = "Buscar", action = "Index" }
            );

            //anuncio
            routes.MapRoute(
                            "Anuncio",
                            "a/{id}/{*nome}",
                            new { controller = "Anuncio", action = "Index" }
            );

            //MeuMuambba
            routes.MapRoute(
                            "MeuMuambba",
                            "MeuMuambba/{action}/{parameter}",
                            new { controller = "MeuMuambba", action = "Anuncios", parameter = UrlParameter.Optional }
            );

            //Usuário
            routes.MapRoute(
                            "Usuario",
                            "u/{nome}",
                            new { controller = "Usuario", action = "Usuario"}
            );

            //Ajax
            routes.MapRoute(
                            "Ajax",
                            "Ajax/{action}/{parameter}",
                            new { controller = "Ajax", action = "RetornoPadrao", parameter = UrlParameter.Optional }
            );

            //Json
            routes.MapRoute(
                            "JSON",
                            "j/{action}/{parameter}",
                            new { controller = "JSON", action = "RetornoPadrao", parameter = UrlParameter.Optional }
            );



            routes.MapRoute(
                "Default",
                "",
                new { controller = "Home", action = "Index", parameter = UrlParameter.Optional }
            );

            routes.MapRoute(
                            "Anunciar", // Route name
                            "Anunciar/{id}", // URL with parameters
                            new { controller = "Anunciar", action = "Anunciar", id = UrlParameter.Optional } // Parameter defaults
                        );


            routes.MapRoute(
                            "Anunciante", // Route name
                            "Anunciante/{action}/{parameter}", // URL with parameters
                            new { controller = "Anunciante", action = "Index", parameter = UrlParameter.Optional } // Parameter defaults
                        );

            routes.MapRoute(
                                        "Contato", // Route name
                                        "Contato/{parameter}", // URL with parameters
                                        new { controller = "Contato", action = "Index", parameter = UrlParameter.Optional } // Parameter defaults
                                    );


            //categorias
            routes.MapRoute(
                "Categorias",
                "{*parameter}",
                new { controller = "Categorias", action = "Index" }
            );


            
            
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);
        }
    }
}