using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using MVC.Models;

namespace MVC.Controllers
{
    public class UsuarioController : ControllerBase
    {
        //
        // GET: /Usuario/

        public ActionResult Usuario(string nome)
        {
            var bll = new BLLUsuario();

            var u = bll.SelectByName(nome);

            Titulo = u.Nome;

            return View(u);
        }

    }
}
