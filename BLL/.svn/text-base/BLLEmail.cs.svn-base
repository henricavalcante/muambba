using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;
using System.Web;

namespace BLL
{
    public class BLLEmail
    {

        private const string LOCAL_TEMPLATES = "Views\\Mail-{0}.ascx";

        public void EnviarEmail(string Email, string Assunto, string Mensagem)
        {


            Util.Email.Enviar(Email, Assunto, Mensagem);

        }

        public void EnviarEmailMaster(string Email, string Assunto, Hashtable Parametros, string Template)
        {
            var strEmail = String.Empty;

            var lnAUX = String.Empty;

            var Path = HttpContext.Current.Server.MapPath("~//");

            var strEmailMaster = System.IO.File.ReadAllLines(Path + String.Format(LOCAL_TEMPLATES, "Master"));

            var strEmailaux = System.IO.File.ReadAllLines(Path + String.Format(LOCAL_TEMPLATES, Template));

            foreach (var ln in strEmailMaster)
            {
                lnAUX = ln;
                if (lnAUX.IndexOf("{CORPO-DO-EMAIL}") > 0)
                {
                    foreach (var ln2 in strEmailaux)
                    {
                        lnAUX = ln2;
                        foreach (DictionaryEntry pa in Parametros)
                        {
                            lnAUX = lnAUX.Replace("{" + pa.Key.ToString() + "}", pa.Value.ToString());
                        }
                        strEmail += lnAUX;
                    }
                }
                else
                {
                    strEmail += lnAUX;
                }
                
            }

            Util.Email.Enviar(Email, Assunto, strEmail);

        }


    }
}
