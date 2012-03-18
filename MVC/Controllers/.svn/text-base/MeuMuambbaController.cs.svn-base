using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using MVC.Models;


namespace MVC.Controllers
{
    public class MeuMuambbaController : ControllerBase
    {
        //
        // GET: /MeuMuambba/

        public ActionResult Anuncios()
        {
            Titulo = "Meu Muambba";

            try
            {
                if (!EstaLogado()) return View("NaoLogado");

            }
            catch (Exception ex)
            {
                Erro = ex.Message;

            }
            return View();
        }

        public ActionResult PerguntasRespostas()
        {
            Titulo = "Perguntas e Respostas";

            try
            {
                if (!EstaLogado()) return View("NaoLogado");

            }
            catch (Exception ex)
            {
                Erro = ex.Message;

            }
            return View();
        }

        public ActionResult Qualificacoes()
        {
            Titulo = "Qualificações";

            try
            {
                if (!EstaLogado()) return View("NaoLogado");

            }
            catch (Exception ex)
            {
                Erro = ex.Message;

            }
            return View();
        }

        public ActionResult Ofertas()
        {

            Titulo = "Ofertas";

            try
            {
                if (!EstaLogado()) return View("NaoLogado");

            }
            catch (Exception ex)
            {
                Erro = ex.Message;

            }
            return View();
        
        }

        public ActionResult MeusDados()
        {
            Titulo = "Meus Dados";

                
            try
            {
                if (!EstaLogado()) return View("NaoLogado");

                if (Request.RequestType == "POST")
                {
                    var bll = new BLLUsuario();
                    var u = new Usuario();
                    u.ID = (int)UsuarioLogado_ID;
                    u.Nome = Request.Params["CadNome"];
                    u.Sobrenome = Request.Params["CadSobrenome"];
                    u.CPF = Request.Params["CadCPF"].Replace(".","").Replace("-","");
                    if (Request.Params["CadSenha"].Trim() != String.Empty)
                    {
                        Util.Validar.Condicao(Request.Params["CadSenha"].Length == 6, "A senha precisa conter 6 digitos");
                        Util.Validar.Condicao(Request.Params["CadConfirmaSenha"] == Request.Params["CadSenha"], "Senha diverge da confirmação");
                        u.Senha = Request.Params["CadSenha"];
                    }
                    if (Request.Params["hdfEndereco"] != null && Request.Params["hdfEndereco"].Trim() != String.Empty)
                    {
                        var end = new Endereco();
                        end.EnderecoCep_ID = int.Parse(Request.Params["hdfEndereco"]);
                        end.Complemento = Request.Params["CadComplemento"];
                        u.Endereco = end;
                    }

                    foreach (var item in Request.Params)
                    {
                        var itens = item.ToString().Split('_');
                        if (itens[0] == "Fotos")
                        {
                            var uf = new UsuarioFoto();
                            uf.NomeArquivo = Request.Params[item.ToString()];
                            u.UsuarioFoto.Add(uf);

                        } else if (itens[0] == "CadUC")
                        {
                            var indice = int.Parse(itens[1]);
                        
                            var UC = u.UsuarioContato.SingleOrDefault(a=>a.ID == indice);

                            if (UC == null)
                            {
                                UC = new Models.UsuarioContato();
                                UC.ID = indice;
                                u.UsuarioContato.Add(UC);
                            }

                            if (itens[2] == "UCTipo")
                            {
                                UC.UsuarioContatoTipo_ID = byte.Parse(Request.Params[item.ToString()]);
                            }
                            if (itens[2] == "UCPub")
                            {
                                UC.Publico = bool.Parse(Request.Params[item.ToString()]);
                            }
                            if (itens[2] == "UCContato")
                            {
                                UC.UsuarioContato1 = Request.Params[item.ToString()];
                            }


                        }
                    }

                    bll.UpdateAndSave(u);

                    Alerta = "Dados Atualizados com sucesso.";
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
