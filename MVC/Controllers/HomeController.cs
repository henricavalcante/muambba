using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Models;


namespace MVC.Controllers
{
    [HandleError]
    public class HomeController : ControllerBase
    {
        public ActionResult Index()
        {
            using (var BLLCategoria = new BLL.BLLCategoria())
            {
                ViewData["categorias"] = BLLCategoria.ListarPais(0).OrderBy(a => a.Categoria1).ToList();
            }


            



            

            return View();
        }

        
    }
}
