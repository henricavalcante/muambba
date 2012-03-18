using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;
using System.IO;

namespace MVC.Controllers
{
    

    public class JavaScriptController : Controller
    {
        
        public static Hashtable Scripts;

        public ActionResult GetScript(string arquivo, string token)
        {
            arquivo = arquivo.Split('/')[0];

            if (Scripts == null)
            {
                Scripts = new Hashtable();
            }

            if (Scripts[arquivo] == null)
            {
                var c = new GoogleClosure();
                //string JSOriginal = System.IO.File.ReadAllText(Server.MapPath("/Scripts/")+id);


                string JsComprimido = string.Empty;
                var diretorio = new DirectoryInfo(Server.MapPath("/Scripts/"));

                foreach (var i in diretorio.GetFiles().Where(a => a.Extension == ".js" && a.Name.Split('$')[0] == arquivo).OrderBy(a => a.Name.Split('$')[1]))
                {
                    string JSOriginal = System.IO.File.ReadAllText(i.FullName);
                    /// WHITESPACE_ONLY
                    /// ADVANCED_OPTIMIZATIONS
                    /// SIMPLE_OPTIMIZATIONS
                    string JSComprimidoAux = c.Compress(JSOriginal, "SIMPLE_OPTIMIZATIONS");

                    //if (JSComprimidoAux.Length == 0)
                    //{
                    //    JSComprimidoAux = c.Compress(JSOriginal, "SIMPLE_OPTIMIZATIONS");
                    //}
                    if (JSComprimidoAux.Length == 0)
                    {
                        JSComprimidoAux = c.Compress(JSOriginal, "WHITESPACE_ONLY");
                    }
                    if (JSComprimidoAux.Length == 0)
                    {
                        JSComprimidoAux = JSOriginal;
                    }

                    JsComprimido += JSComprimidoAux;
                    
                }

                Scripts.Add(arquivo, JsComprimido);

            }


            return new JSResult { Script = Scripts[arquivo].ToString() };
        }

    }


    public class JSResult : ActionResult
    {
        public string Script { get; set; }

        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.Clear();
            context.HttpContext.Response.ContentType = "application/x-javascript";
            context.HttpContext.Response.CacheControl = "public";
            context.HttpContext.Response.Cache.SetMaxAge(new TimeSpan(360, 0, 0, 0));
            context.HttpContext.Response.Write(Script);
        }
    }
}
