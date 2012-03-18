using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class AnunciarController : ControllerBase
    {
        //
        // GET: /Anunciar/

        public ActionResult Anunciar(int? id)
        {
            Titulo = "Insira um novo anuncio, é rápido e grátis.";

            try
            {
                if (!EstaLogado()) return View("NaoLogado");


                if (id != null)
                {
                    var bll = new BLL.BLLAnuncio();
                    var a = bll.SelectByKey(id.GetValueOrDefault());

                    if (a != null && (a.UsuarioInc_ID == UsuarioLogado_ID || UsuarioLogado_ADMIN))
                    {
                        ViewData["id"] = id;
                    }
                    else
                    {
                        return RedirectToRoute("Default");
                    }

                    
                }

            }
            catch (Exception ex)
            {
                Erro = ex.Message;

            }
            return View();
        }

    }
}
