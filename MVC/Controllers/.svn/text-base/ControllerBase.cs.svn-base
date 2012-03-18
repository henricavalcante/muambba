using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using MVC.Models;
using System.Collections;
using Twitterizer;


namespace MVC.Controllers
{
    public class ControllerBase : Controller
    {

        public string Titulo { get { return (string)ViewData["titulo"]; } set { ViewData["titulo"] = value; } }

        public List<string> Categorias { get { return (List<string>)ViewData["mapcategorias"]; } set { ViewData["mapcategorias"] = value; } }

        public string Erro { get { return (string)ViewData["mensagemerro"]; } set { ViewData["mensagemerro"] = value; } }
        public string Alerta { get { return (string)ViewData["alerta"]; } set { ViewData["alerta"] = value; } }

        #if DEBUG
            public int? UsuarioLogado_ID { get { if (Session["UsuarioLogado_ID"] == null) { Session["UsuarioLogado_ID"] = 3; } return (int?)Session["UsuarioLogado_ID"]; } set { Session["UsuarioLogado_ID"] = value; } }
        #else
            public int? UsuarioLogado_ID { get {  return (int?)Session["UsuarioLogado_ID"]; } set { Session["UsuarioLogado_ID"] = value; } }
        #endif

        public bool UsuarioLogado_ADMIN
        {
            get
            {
                if (Session["UsuarioLogado_ADMIN"] == null)
                {
                    Session["UsuarioLogado_ADMIN"] = false;
                }
                return (bool)Session["UsuarioLogado_ADMIN"];
            }
            set
            {
                Session["UsuarioLogado_ADMIN"] = value;
            }
        }

        public int ItensPorPagina
        {
            get
            {

                if (Session["ItensPorPagina"] == null)
                {
                    Session["ItensPorPagina"] = 15;
                }

                return (int)Session["ItensPorPagina"];
            }
            set
            {
                Session["ItensPorPagina"] = value;
            }
        }
        
        public string RetornoAjax { get { return (string)ViewData["RetornoAjax"]; } set { ViewData["RetornoAjax"] = value; } }
        
        public string RetornoJson { get { return (string)ViewData["RetornoJson"]; } set { ViewData["RetornoJson"] = value; } }

        public Guid Sessao
        {
            get
            {
                if (Session["SessaoAtual"] == null)
                {
                    var g = Guid.NewGuid();
                    var n = DateTime.Now;
                    Session["SessaoAtual"] = g;
#if !DEBUG
                    new BLLSessao().InsertAndSave(new Sessao { Guid = g, DataHoraInicio = n, DataHoraFim = n, Checkpoints = 0 });
#endif

                }

                return (Guid)Session["SessaoAtual"];
            }
            set 
            {

                Session["SessaoAtual"] = value;
            
            }
        }

        public Usuario UsuarioLogado
        {
            get
            {
                if (UsuarioLogado_ID != null && UsuarioLogado_ID > 0 && Session["UsuarioLogado"] == null)
                {
                    var bll = new BLLUsuario();
                    Session["UsuarioLogado"] = bll.SelectByKey((int)UsuarioLogado_ID);
                }
                return (Usuario)Session["UsuarioLogado"];
            }
            set
            {
                Session["UsuarioLogado"] = value;

            }

        }


        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
        

            // Optional: Do not work with AjaxRequests
            if (filterContext.RequestContext.HttpContext.Request.IsAjaxRequest())
                return;

            ViewData["SessaoAtual"] = Sessao.ToString().Replace("-", "");

#if DEBUG
            ViewData["ModoDebug"] = true; 
#else
            ViewData["ModoDebug"] = false; 
#endif
            // Optional: Work only for GET request
            if (filterContext.RequestContext.HttpContext.Request.RequestType != "GET")
                return;
        }

        protected void EnviarEmail(string Email, string Assunto, string Template , Hashtable Parametros)
        {


            var strEmailaux = System.IO.File.ReadAllLines(Server.MapPath("\\Views\\Mail-"+Template+".template"));

            var strEmail = String.Empty;

            var lnAUX = String.Empty;

            foreach (var ln in strEmailaux)
            {
                lnAUX = ln;
                foreach (DictionaryEntry  pa in Parametros)
                {
                    lnAUX = lnAUX.Replace("{"+pa.Key.ToString()+"}", pa.Value.ToString());
                }
                strEmail += lnAUX;
            }

            Util.Email.Enviar(Email, Assunto, strEmail);
        
        }

        protected bool EstaLogado()
        {

            if (UsuarioLogado_ID != null && UsuarioLogado_ID > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Tuitar(string msg)
        {
            OAuthTokens tokens = new OAuthTokens();
            tokens.AccessToken = "191314630-hHyqIXQeXDsvaf046xnRcceetOJNPv49TtK9Gwf5";
            tokens.AccessTokenSecret = "jMrZCHzrHnbfH9OotcaBdmR9XG25rgAm0TR4mWLs2O4";
            tokens.ConsumerKey = "JBjsd4kGiufdTObMmMAZw";
            tokens.ConsumerSecret = "Tflj5MquGlizbxNJny90IWNOU4pRZqY8BnvF4ZklE";

            TwitterResponse<TwitterStatus> tweetResponse = TwitterStatus.Update(tokens, msg);
            if (tweetResponse.Result == RequestResult.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }

    
}