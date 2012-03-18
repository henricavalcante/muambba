using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;
using System.IO;
using Yahoo.Yui.Compressor;

namespace MVC.Controllers
{
    public class CSSController : Controller
    {
        public static Hashtable Styles;

        public ActionResult GetStyle(string arquivo, string token)
        {
            arquivo = arquivo.Split('/')[0];

            if (Styles == null)
            {
                Styles = new Hashtable();
            }

            if (Styles[arquivo] == null)
            {
                var c = new GoogleClosure();
                //string JSOriginal = System.IO.File.ReadAllText(Server.MapPath("/Scripts/")+id);


                string CSSComprimido = string.Empty;
                var diretorio = new DirectoryInfo(Server.MapPath("/Content/"));

                foreach (var i in diretorio.GetFiles().Where(a => a.Extension == ".css" && a.Name.Split('$')[0] == arquivo).OrderBy(a => a.Name.Split('$')[1]))
                {
                    string CSSOriginal = System.IO.File.ReadAllText(i.FullName);
                    
                    CSSComprimido += CssCompressor.Compress(CSSOriginal);
                }

                Styles.Add(arquivo, CSSComprimido);

            }

            //Response.ContentType = "text/css";
            //Response.CacheControl = "public";
            //Response.Write();

            return new CSSResult { Style = Styles[arquivo].ToString() };
        }

    }

    public class CSSResult : ActionResult
    {
        public string Style { get; set; }

        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.Clear();
            context.HttpContext.Response.ContentType = "text/css";
            context.HttpContext.Response.CacheControl = "public";
            context.HttpContext.Response.Cache.SetMaxAge(new TimeSpan(360,0, 0, 0));
            context.HttpContext.Response.Write(Style);
        }
    }
}
