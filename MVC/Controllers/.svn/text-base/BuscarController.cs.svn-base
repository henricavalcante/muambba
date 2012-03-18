using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Models;
using BLL;

namespace MVC.Controllers
{
    public class BuscarController : ControllerBase
    {
        //
        // GET: /Buscar/

        public ActionResult Index(string query)
        {

            var strBusca = query.Split('/')[0].Replace("+", " ");
            

            
            
            ViewData["busca"] = strBusca;

            return View();
        }

    }
}
