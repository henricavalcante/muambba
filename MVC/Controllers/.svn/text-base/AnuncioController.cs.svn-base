using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class AnuncioController : ControllerBase
    {
        //
        // GET: /Anuncio/

        public ActionResult Index(int id, string nome)
        {
            Titulo = nome.Replace("-"," ");

            ViewData["id"] = id;
                 
            return View();
        }


    }
}
