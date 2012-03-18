﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC.Models;
using BLL;
using System.Collections;

namespace MVC
{
    public class UserControlBase : UserControlBase<Object>
    { 
    
    }

    public class UserControlBase<T> : System.Web.Mvc.ViewUserControl<T>
    {

        public int? UsuarioLogado_ID { get { return (int?)Session["UsuarioLogado_ID"]; } set { Session["UsuarioLogado_ID"] = value; } }

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

        public string SessaoAtual { get { return ViewData["SessaoAtual"].ToString(); } set { ViewData["SessaoAtual"] = value; } }

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

        //List<UsuarioContatoTipo> _ContatosTipos;


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

        public int P_a_partir_de()
        {
            var p = Parametro("a_partir_de");

            if (p != string.Empty)

                return int.Parse(p);
            else
                return 0;

        }

        public bool P_em_ordem()
        {
            if (Parametro("em_ordem") == "decrescente")
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public Func<Anuncio, IComparable> P_ordenado_por()
        {

            var b = Parametro("ordenado_por").ToLower();

            if (b == "visitas")
                return (Anuncio a) => a.DataInc;
            else if (b == "preco")
                return (Anuncio a) => a.Preco;
            else
                return (Anuncio a) => a.DataInc;

        }

        public string Parametro(string param)
        {

            //var lstParametros = Request.RawUrl.Split('/').LastOrDefault().Split('-');
            //for (int i = 0; i < lstParametros.Count(); i++)
            //{
            //    if (lstParametros[i].StartsWith("_" + param))
            //        return lstParametros[i].Split('_').LastOrDefault();
            //}

            //return string.Empty;


            var Parametros = Request.RawUrl.Split('/').LastOrDefault();
            if (Parametros.IndexOf(param) > -1)
            {
                return Parametros.Substring(Parametros.IndexOf(param) + param.Length + 1).Split('_')[0];

            }

            return string.Empty;


        }

        public string UrlParametro(string param)
        {
            return (Parametro(param) != String.Empty) ? "_" + param + "_" + Parametro(param) : String.Empty;

        }

    }
}