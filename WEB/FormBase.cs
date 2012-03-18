using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;
using MVC.Models;

namespace WEB
{
    public class FormBase : System.Web.UI.Page
    {
        protected const string PAGINA_PADRAO = "default.aspx";
        protected const string MSG_PRECISA_LOGAR = "Você precisa estar logado em uma conta de usuário para usar esse recurso.";

        protected const string MSG_USUARIO_DIFERENTE = "OOps!! Esta funcionalidade não foi feita para o proprietário do Anuncio.";
        protected const string DESEJA_EXCLUIR = "Deseja realmente excluir este registro?";
        protected const string REGISTRO_INC = "O Registro foi salvo com sucesso.";
        protected const string REGISTRO_DEL = "O Registro foi excluído com sucesso.";

        public Usuario UsuarioLogado
        {
            get { return (Usuario)Session["UsuarioLogado"]; }
            set { Session["UsuarioLogado"] = value; }
        }


    }
}