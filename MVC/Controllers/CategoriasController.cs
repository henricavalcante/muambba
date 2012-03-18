using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class CategoriasController : ControllerBase
    {
        //
        // GET: /Categorias/

        public ActionResult Index(string parameter)
        {

            var bll = new BLL.BLLCategoria();

            Categoria CategoriaAux;

            Categorias = parameter.Split('/').Where(a=>a.Substring(0,1) != "_").ToList();

            CategoriaAux = bll.SelectBaseByName(Categorias[0]);

            for (int i = 1; i < Categorias.Count; i++)
            {
                if (Categorias[i] != String.Empty)
                {
                    CategoriaAux = CategoriaAux.Categoria11.Where(a => a.Categoria1 == Categorias[i]).SingleOrDefault();
                }
                
            }

            if (CategoriaAux == null)
            {
                return RedirectToAction("Index", "Home");
            }

            ViewData["Categoria_ID"] = CategoriaAux.ID;

            


            Titulo = parameter.Split('/').First().ToString();
            
                return View();
            
            
        }

    }
}
