using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace API.Controllers
{
    public class UsuarioController : ControllerBase
    {
        //
        // GET: /Usuario/

        public JsonResult Single(int id)
        {
            try
            {
                //VerificaSessao(sch);

                //var bll = new BLL.BLLUsuario();

                //var retorno = bll.

                //return Json(new RetornoJsonPadrao("Categorias listadas com sucesso.", true, retorno));
                return null;

            }
            catch (Exception ex)
            {
                return Json(new RetornoJsonPadrao(ex.Message, false, null));

            }
        }

    }
}
