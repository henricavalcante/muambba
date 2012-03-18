using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;


namespace Util
{
    public class Javascript
    {
        #region "Constantes Públicas"

        public const string START_SCRIPT = "<script language='javascript'>";
        public const string END_SCRIPT = "</script>";
        public const string _BLANK = "_blank";
        public const string _PARENT = "_parent";
        public const string _SELF = "_self";

        public const string _TOP = "_top";
        #endregion

        #region "Métodos"


        //public static void DocLocation(System.Web.UI.Page ObjectPage, string strURL, bool Ajax = false)
        //{
        //    System.Text.StringBuilder strScript = new System.Text.StringBuilder();

        //    var _with1 = strScript;

        //    _with1.Append("<script language=\"javascript\">");
        //    _with1.Append("document.location='" + strURL + "';");
        //    _with1.Append("</script>");



        //    if (Ajax)
        //    {
        //        ScriptManager.RegisterStartupScript(ObjectPage, typeof(string), new Guid().ToString(), strScript.ToString(), false);


        //    }
        //    else
        //    {
        //        ObjectPage.ClientScript.RegisterStartupScript(typeof(string), new Guid().ToString(), strScript.ToString());

        //    }



        //}



        //public static void AddMaskText(ref object TextObject, string MaskText)
        //{
        //    var _with2 = TextObject.Attributes;

            

        //    _with2.Add("onKeyPress", string.Format("javascript:{0}", ScriptMaskText(MaskText)));
        //    _with2.Add("MaxLength", MaskText.Length);


        //}


        //public static void AddNumDec(ref object SourceObject, byte intCasas)
        //{
        //    SourceObject.Attributes.Add("onKeyPress", string.Format("javascript:{0}", ScriptApenasNumDec(intCasas)));

        //}


        //public static void AddDefaultSubmit(ref object SourceObject, ref System.Web.UI.Control ObjectToSubmit, bool boolDropDownList = false)
        //{
        //    SourceObject.Attributes.Add("onKeyPress", string.Format("javascript:{0}", ScriptDefaultSubmit(ref ObjectToSubmit, boolDropDownList)));

        //}



        //public static void AddConfirmSubmit(ref object SourceObject, string Message, string EventName = "onClick")
        //{
        //    SourceObject.Attributes.Add(EventName, string.Format("javascript:{0}", ScriptConfirmSubmit(Message)));

        //}



        //public static void AddAtivarPesquisa(ref object SourceObject, string strTabela, string strDest = "", string strOrdExt = "", string strFiltroExt = "", string strReq = "", string EventName = "onClick")
        //{
        //    SourceObject.Attributes.Add(EventName, string.Format("javascript:{0}", ScriptAtivaPesquisa(strTabela, strDest, strOrdExt, strFiltroExt, strReq)));

        //}


        //public static void AddOpenWindow(ref object SourceObject, string strPagina, string strTarget, int intWidth = 400, int intHeight = 300, string strScroll = "no", string EventName = "onClick")
        //{
        //    SourceObject.Attributes.Add(EventName, string.Format("javascript:{0}", ScriptOpenWindow(strPagina, strTarget, intWidth, intHeight, strScroll)));

        //}



        //public static void SetFocus(ref System.Web.UI.Page ObjectPage, ref System.Web.UI.Control ObjectFocus, bool Ajax = false)
        //{
        //    SetFocus(ObjectPage, ObjectFocus.ClientID);

        //}


        //public static void SetFocus(ref System.Web.UI.Page ObjectPage, string ObjectId, bool Ajax = false)
        //{
        //    System.Text.StringBuilder strScript = new System.Text.StringBuilder();

        //    var _with3 = strScript;

        //    _with3.Append("<script language=\"javascript\">");
        //    _with3.Append("$(\"#" + ObjectId + "\").focus();");
        //    _with3.Append("$(\"#" + ObjectId + "\").toggleClass('txt-focus');");
        //    _with3.Append("</script>");



        //    if (Ajax)
        //    {
        //        ScriptManager.RegisterStartupScript(ObjectPage, typeof(string), new Guid().ToString(), strScript.ToString(), false);


        //    }
        //    else
        //    {
        //        ObjectPage.ClientScript.RegisterStartupScript(typeof(string), new Guid().ToString(), strScript.ToString());

        //    }

        //}

        //public static void FadeIn(ref System.Web.UI.Page ObjectPage, ref System.Web.UI.Control ObjectFocus, bool PageTo = false, bool Ajax = false)
        //{
        //    FadeIn(ref ObjectPage, ObjectFocus.ClientID, PageTo, Ajax);

        //}


        //public static void FadeIn(ref System.Web.UI.Page ObjectPage, string ObjectId, bool PageTo = false, bool Ajax = false)
        //{
        //    System.Text.StringBuilder strScript = new System.Text.StringBuilder();

        //    var _with4 = strScript;

        //    _with4.Append("<script language=\"javascript\">");
        //    if (PageTo)
        //    {
        //        _with4.Append("$( 'html, body' ).animate( { scrollTop: ($(document).height() / 2) - $('#" + ObjectId + "').height() }, 1000 );");

        //    }

        //    _with4.Append("$('#" + ObjectId + "').fadeIn();");
        //    _with4.Append("</script>");



        //    if (Ajax)
        //    {
        //        ScriptManager.RegisterStartupScript(ObjectPage, typeof(string), new Guid().ToString(), strScript.ToString(), false);


        //    }
        //    else
        //    {
        //        ObjectPage.ClientScript.RegisterStartupScript(typeof(string), new Guid().ToString(), strScript.ToString());

        //    }

        //}

        //public static void FadeOut(ref System.Web.UI.Page ObjectPage, ref System.Web.UI.Control ObjectFocus, bool PageTop = false, bool Ajax = false)
        //{
        //    FadeOut(ref ObjectPage, ObjectFocus.ClientID, PageTop, Ajax);

        //}


        //public static void FadeOut(ref System.Web.UI.Page ObjectPage, string ObjectId, bool PageTop = false, bool Ajax = false)
        //{
        //    System.Text.StringBuilder strScript = new System.Text.StringBuilder();

        //    var _with5 = strScript;

        //    _with5.Append("<script language=\"javascript\">");
        //    if (PageTop)
        //    {
        //        _with5.Append("$( 'html, body' ).animate( { scrollTop: 0 }, 1000 );");
        //    }
        //    _with5.Append("$(\"#" + ObjectId + "\").fadeOut();");
        //    _with5.Append("</script>");



        //    if (Ajax)
        //    {
        //        ScriptManager.RegisterStartupScript(ObjectPage, typeof(string), new Guid().ToString(), strScript.ToString(), false);


        //    }
        //    else
        //    {
        //        ObjectPage.ClientScript.RegisterStartupScript(typeof(string), new Guid().ToString(), strScript.ToString());

        //    }

        //}


        //public static void TrocarClasse(ref System.Web.UI.Page ObjectPage, ref System.Web.UI.Control ObjectClass, ref string ClasseAntiga, ref string ClasseNova, bool Ajax = false)
        //{
        //    TrocarClasse(ref ObjectPage, ObjectClass.ClientID, ref ClasseAntiga, ref ClasseNova, Ajax);

        //}


        //public static void TrocarClasse(ref System.Web.UI.Page ObjectPage, string ObjectId, ref string ClasseAntiga, ref string ClasseNova, bool Ajax = false)
        //{
        //    System.Text.StringBuilder strScript = new System.Text.StringBuilder();

        //    var _with6 = strScript;

        //    _with6.Append("<script language=\"javascript\">");

        //    _with6.Append("$('#" + ObjectId + "').removeClass('" + ClasseAntiga + "').addClass('" + ClasseNova + "');");

        //    _with6.Append("</script>");



        //    if (Ajax)
        //    {
        //        ScriptManager.RegisterStartupScript(ObjectPage, typeof(string), new Guid().ToString(), strScript.ToString(), false);


        //    }
        //    else
        //    {
        //        ObjectPage.ClientScript.RegisterStartupScript(typeof(string), new Guid().ToString(), strScript.ToString());

        //    }

        //}


        //public static void PageTop(ref System.Web.UI.Page ObjectPage, bool Ajax = false)
        //{
        //    System.Text.StringBuilder strScript = new System.Text.StringBuilder();

        //    var _with7 = strScript;

        //    _with7.Append("<script language=\"javascript\">");
        //    _with7.Append("$( 'html, body' ).animate( { scrollTop: 0 }, 1000 );");
        //    _with7.Append("</script>");



        //    if (Ajax)
        //    {
        //        ScriptManager.RegisterStartupScript(ObjectPage, typeof(string), new Guid().ToString(), strScript.ToString(), false);


        //    }
        //    else
        //    {
        //        ObjectPage.ClientScript.RegisterStartupScript(typeof(string), new Guid().ToString(), strScript.ToString());

        //    }

        //}


        public static void ShowMsg(System.Web.UI.Page ObjectPage, string Message, string strObjectID = "", bool Ajax = false)
        {

            //if (Strings.InStr(Message.ToUpper(), "DELETE statement conflicted".ToUpper()))
            //{
            //    Message = "O registro não pode ser excluído. Existem informações relacionadas a ele.";

            //}


            //if (Strings.InStr(Message.ToUpper(), "Violation of UNIQUE KEY constraint 'IX_Usuario'".ToUpper()))
            //{
            //    Message = "Este nome de Usuário já existe.";

            //}


            System.Text.StringBuilder strScript = new System.Text.StringBuilder();

            var _with8 = strScript;

            _with8.Append("<script language=\"javascript\">");


            if (!string.IsNullOrEmpty(strObjectID.Trim()))
            {
                _with8.Append("$(\"#" + strObjectID + "\").focus();");
                _with8.Append("$(\"#" + strObjectID + "\").toggleClass('txt-focus');");

            }

            _with8.Append("alert('" + StringJava(Message) + "');");
            _with8.Append("</script>");



            if (Ajax)
            {
                ScriptManager.RegisterStartupScript(ObjectPage, typeof(string), new Guid().ToString(), strScript.ToString(), false);


            }
            else
            {
                ObjectPage.ClientScript.RegisterStartupScript(typeof(string), new Guid().ToString(), strScript.ToString());

            }

        }


        public static void ShowRPT(System.Web.UI.Page ObjectPage, string strRpt, string strParam, bool Ajax = false)
        {


            if (Ajax)
            {
                ScriptManager.RegisterStartupScript(ObjectPage, typeof(string), new Guid().ToString(), "showCrystalRPT('" + strRpt + "', '" + strParam + "');", true);


            }
            else
            {
                ObjectPage.ClientScript.RegisterStartupScript(typeof(string), new Guid().ToString(), "showCrystalRPT('" + strRpt + "', '" + strParam + "');", true);

            }


        }

        #endregion

        #region "Funções"

        public static string StringJava(string Texto)
        {

            Texto = Texto.Replace( "\\", "\\\\");
            Texto = Texto.Replace("\n", "\\n");
            Texto = Texto.Replace("'", "\\'");
            Texto = Texto.Replace("\"", "\\\"");

            return Texto;

        }

        public static string ScriptMaskText(string MaskText)
        {

            return string.Format("return mascaraCampo(this, '{0}', event);", MaskText);

        }

        public static string ScriptApenasNumDec(string Casas)
        {

            return string.Format("apenasNumDec(this, {0}, 15, event);", Casas);

        }

        public static string ScriptDefaultSubmit(ref System.Web.UI.Control ObjectToSubmit, bool boolDropDownlist)
        {


            if (boolDropDownlist)
            {
                return "if (event.keyCode == 13){document.getElementById('" + ObjectToSubmit.ClientID + "').click();return(false);};";


            }
            else
            {
                return "if (event.keyCode == 13 && Trim(this.value) != ''){document.getElementById('" + ObjectToSubmit.ClientID + "').click();return(false);};";

            }

        }

        public static string ScriptConfirmSubmit(string Message)
        {

            return "if (!confirm('" + StringJava(Message) + "')){return(false);};";

        }

        public static string ScriptAtivaPesquisa(string strTabela, string strDest, string strOrdExt, string strFiltroExt, string strReq)
        {

            return string.Format("AtivarPesquisa('{0}', '{1}', '{2}', '{3}','{4}');", strTabela, strDest, strFiltroExt, strOrdExt, strReq);

        }

        public static string ScriptOpenWindow(string strPagina, string strTarget, int intWidth, int intHeight, string strScroll)
        {

            return string.Format("abrirJanelaScroll('{0}','{1}','{2}','{3}', '{4}')", strPagina, strTarget, intWidth, intHeight, strScroll);

        }

        public static string ScriptOnFocus(string strPagina, string strTarget, int intWidth, int intHeight, string strScroll)
        {

            return string.Format("abrirJanelaScroll('{0}','{1}','{2}','{3}', '{4}')", strPagina, strTarget, intWidth, intHeight, strScroll);

        }

        #endregion

    }
}
