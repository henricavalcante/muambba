#region Assembly System.Web.Mvc.dll, v2.0.50727
// c:\Program Files\Microsoft ASP.NET\ASP.NET MVC 2\Assemblies\System.Web.Mvc.dll
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web;

namespace Util
{
    public static class HtmlUtil
    {
        

        public static string Informativo(this HtmlHelper htmlHelper, string texto)
        {
            return String.Format("<span class=\"informativo\">{0}</label>", texto);
        }


        public static string MuambbaTextBox(this HtmlHelper htmlHelper, string nome)
        {
            return MuambbaTextBox(htmlHelper,  nome, "", 0,0, "", "", true);
        }

        public static string MuambbaTextBox(this HtmlHelper htmlHelper, string nome, bool habilitado)
        {
            return MuambbaTextBox(htmlHelper,  nome, "", 0,0, "", "", habilitado);
        }

        public static string MuambbaTextBox(this HtmlHelper htmlHelper, string nome, string fixo, int validaJson, string mascara, string schave)
        {
            return MuambbaTextBox(htmlHelper, nome, fixo, validaJson,0, mascara, schave, true);
        }

        public static string MuambbaTextBox(this HtmlHelper htmlHelper, string nome, string fixo, int validaJson, int acJson, string mascara, string schave, bool habilitado)
        {
            return MuambbaTextBox(htmlHelper, nome, fixo, validaJson, acJson, mascara, schave, "", habilitado);
        }

        public static string MuambbaTextBox(this HtmlHelper htmlHelper, string nome, string fixo, int validaJson, int acJson, string mascara, string schave, string valor, bool habilitado)
        {
            string id = "txt" + nome;
            string idAux = id + "Aux";

            if (nome == null || nome.Trim() == String.Empty) return String.Empty;
            if (fixo == null) fixo = String.Empty;
            if (valor == null) valor = String.Empty;
            if (mascara == null) mascara = String.Empty;

            bool temJson = (validaJson > 0);
            bool temAc = (acJson > 0);

            bool temMascara = (mascara != "sem_mascara" && mascara.ToString().Trim() != String.Empty);
            bool temFixo = ( fixo.Trim() != String.Empty);
            bool temValor = (valor.Trim() != String.Empty);
            
            string strRetorno = "<div class=\"txt-borda\"><div class=\"txt-borda-interior\"> ";

            //O primeiro será conterá apenas o texto fixo
            if (temFixo)
            {
            
            
                strRetorno += "<input type=\"text\" ";

                
                    strRetorno += "value=\"" + fixo + "\" ";




                    strRetorno += "onfocus=\"$(this).hide(); $('#" + id + "').show().focus();\" ";

                    if (temValor)
                    {
                        strRetorno +=  "class=\"inputtext escondido\" ";
                    }
                    else
                    {
                        strRetorno += "class=\"inputtext\" ";
                    
                    }


                if (!habilitado)
                {
                    strRetorno += "disabled=\"\"";
                }
                

                strRetorno += "id=\"" + idAux + "\" ";

                strRetorno += "style=\"color:#888888;\" />";

            }


            //Segundo TextBox -----------------------------------------------------------------------------------
            strRetorno += "<input type=\"text\" title=\"" + nome + "\" ";

            strRetorno += "name=\"" + nome + "\" id=\"" + id + "\" ";

            if (temJson)
            {

                strRetorno += "onkeyup=\"m.val.campoUnico($(this)," + validaJson + ",'" + schave + "')\" " +
                                              "onchange=\"m.val.campoUnico($(this)," + validaJson + ",'" + schave + "')\" ";
            }

            if (temValor)
            {
                
                strRetorno += "value=\"" + valor + "\" "; 
            }
            else 
            {
                strRetorno += "value=\"\" ";
            }

            if (temFixo)
            {
                strRetorno += "onblur=\"if(this.value == ''){$(this).hide(); $('#" + idAux + "').show();};\" ";
            }


            if (temMascara)
            {
                strRetorno += "mascara=\"" + mascara + "\" ";
            }

            if (!habilitado)
            {
                strRetorno += "disabled=\"\" ";
            }

            if ((temValor && temFixo) || !temFixo)
            {
                strRetorno += "class=\"inputtext\" ";
            }
            else
            {
                strRetorno += "class=\"inputtext escondido\" ";

            }

            strRetorno +=   "style=\"color:#000000;\" /></div>";

            if (temJson || temAc)
            {
                strRetorno += "<img class=\"icone16\" src=\"/Imagens/px.gif\" alt=\"\"/>";
            }

            strRetorno += "</div>";

            if (temAc)
            {
                strRetorno += "<script language=\"javascript\" type=\"text/javascript\" >m.jsn.get('" + schave + "').init(" + acJson + ", $(\"#" + id + "\"));</script>";
                strRetorno += "<input type=\"hidden\" id=\"hdf" + id + "\" name=\"hdf" + nome + "\" value=\"\" />";
            
            }
            
            return strRetorno;
        }

        public static string MuambbaTextArea(this HtmlHelper htmlHelper, string nome, string fixo, int validaJson, int acJson, string mascara, string schave, string valor, bool habilitado)
        {
            string id = "txt" + nome;
            string idAux = id + "Aux";

            if (nome == null || nome.Trim() == String.Empty) return String.Empty;
            if (fixo == null) fixo = String.Empty;
            if (valor == null) valor = String.Empty;
            if (mascara == null) mascara = String.Empty;

            bool temJson = (validaJson > 0);
            bool temAc = (acJson > 0);

            bool temMascara = (mascara != "sem_mascara" && mascara.ToString().Trim() != String.Empty);
            bool temFixo = (fixo.Trim() != String.Empty);
            bool temValor = (valor.Trim() != String.Empty);

            string strRetorno = "<div class=\"txt-borda\"><div class=\"txt-borda-interior\"> ";

            //O primeiro será conterá apenas o texto fixo
            if (temFixo)
            {


                strRetorno += "<input type=\"text\" ";


                strRetorno += "value=\"" + fixo + "\" ";




                strRetorno += "onfocus=\"$(this).hide(); $('#" + id + "').show().focus();\" ";

                if (temValor)
                {
                    strRetorno += "class=\"inputtext escondido\" ";
                }
                else
                {
                    strRetorno += "class=\"inputtext\" ";

                }


                if (!habilitado)
                {
                    strRetorno += "disabled=\"\"";
                }


                strRetorno += "id=\"" + idAux + "\" ";

                strRetorno += "style=\"color:#888888;\" />";

            }


            //Segundo TextArea -----------------------------------------------------------------------------------
            strRetorno += "<textarea title=\"" + nome + "\" rows=\"1\" cols=\"\" ";

            strRetorno += "name=\"" + nome + "\" id=\"" + id + "\" ";

            if (temJson)
            {

                strRetorno += "onkeyup=\"m.val.campoUnico($(this)," + validaJson + ",'" + schave + "'); m.util.ajustaTextArea(this);\" " +
                                              "onchange=\"m.val.campoUnico($(this)," + validaJson + ",'" + schave + "')\" ";
            }
            else
            {
                strRetorno += "onkeyup=\"m.util.ajustaTextArea(this);\" ";
            }

            strRetorno += "onfocus=\"m.util.ajustaTextArea(this);\" ";

            if (temValor)
            {

                strRetorno += "value=\"" + valor + "\" ";
            }
            else
            {
                strRetorno += "value=\"\" ";
            }

            if (temFixo)
            {
                strRetorno += "onblur=\"if(this.value == ''){$(this).hide(); $('#" + idAux + "').show();};\" ";
            }


            if (temMascara)
            {
                strRetorno += "mascara=\"" + mascara + "\" ";
            }

            if (!habilitado)
            {
                strRetorno += "disabled=\"\" ";
            }

            if ((temValor && temFixo) || !temFixo)
            {
                strRetorno += "class=\"inputtext\" ";
            }
            else
            {
                strRetorno += "class=\"inputtext escondido\" ";

            }

            strRetorno += "style=\"color:#000000;\" />"+valor+"</textarea></div>";

            if (temJson || temAc)
            {
                strRetorno += "<img class=\"icone16\" src=\"/Imagens/px.gif\" alt=\"\"/>";
            }

            strRetorno += "</div>";

            if (temAc)
            {
                strRetorno += "<script language=\"javascript\" type=\"text/javascript\" >m.jsn.get('" + schave + "').init(" + acJson + ", $(\"#" + id + "\"));</script>";
                strRetorno += "<input type=\"hidden\" id=\"hdf" + id + "\" name=\"hdf" + nome + "\" value=\"\" />";

            }

            return strRetorno;
        }

        public static string MuambbaTextBoxSenha(this HtmlHelper htmlHelper, string nome, string fixo, string schave)
        {
            return MuambbaTextBoxSenha(htmlHelper, nome, fixo, schave, 0);
        }

        public static string MuambbaTextBoxSenha(this HtmlHelper htmlHelper, string nome, string fixo, string schave, int numeroJson)
        {
            string id = "txt" + nome;
            string idAux = id+"Aux";
            bool temJson = (numeroJson > 0);
            bool temFixo = (fixo.Trim() != String.Empty);

            var strRetorno = "<div class=\"txt-borda\"><div class=\"txt-borda-interior\"><input type=\"text\" title=\"" + nome + "\" ";


            strRetorno +=   "id=\"" + idAux + "\" value=\"" + fixo + "\" " +
                            "fixo=\"" + fixo + "\" " +
                            "onfocus=\"$(this).hide(); $('#"+id+"').show().focus();\" " +
                            "onkeydown=\"this.style.color = '#000000'\" " +
                            "style=\"color:#888888;\" class=\"inputtext\"/>";
            
                strRetorno +=   "<input type=\"password\" name=\"" + nome + "\" id=\"" + id + "\" " +
                                "onkeypress=\"javascript:return m.util.mascaraCampo(this, '######', event)\" " +
                                "onblur=\"if(this.value == ''){$(this).hide(); $('#" + idAux + "').show();};\" " +
                                "class=\"inputtext escondido\" /></div>";


                strRetorno += "</div>";
                if (temJson)
                {
                    strRetorno += "<img class=\"icone16\" src=\"/Imagens/px.gif\" alt=\"\"/>";

                }
                

            return strRetorno;
        }


        public static string TextBox(this HtmlHelper htmlHelper, string id, string nome, string fixo)
        {
            return "<div class=\"txt-borda\"><div class=\"txt-borda-interior\"><input type=\"text\" title=\"" + fixo + "\" value=\"" + fixo + "\" " +
                                 "fixo=\"" + fixo + "\" " +
                                 "onfocus=\"javascript: if(this.value == '" + fixo + "'){this.value = ''};\" " +
                                  "onblur=\"javascript: if(this.value == ''){this.value = '" + fixo + "', this.style.color = '#888888'};\" " +
                                  "onkeydown=\"this.style.color = '#000000'\"" +
                                 "name=\"" + nome + "\" id=\"" + id + "\" " +
                                 "style=\"color:#888888;\"" +
                                 "class=\"inputtext\"></div></div>";
        }

        public static string TextArea(this HtmlHelper htmlHelper, string id, string nome, string fixo)
        {
            return "<div class=\"txt-borda\"><div class=\"txt-borda-interior\"><textarea  rows=\"\" cols=\"\" title=\"" + fixo + "\" value=\"" + fixo + "\" " +
                                 "fixo=\"" + fixo + "\" " +
                                 "onfocus=\"javascript: if(this.value == '" + fixo + "'){this.value = ''};\" " +
                                  "onblur=\"javascript: if(this.value == ''){this.value = '" + fixo + "', this.style.color = '#888888'};\" " +
                                  "onkeydown=\"this.style.color = '#000000'\"" +
                                 "name=\"" + nome + "\" id=\"" + id + "\" " +
                                 "style=\"color:#888888;\"" +
                                 "class=\"inputtextarea\">" + fixo + "</textarea></div></div>";
        }


        public static string MuambbaDropDownList(this HtmlHelper htmlHelper, string nome, int valorSelecionado, SelectList fonteDeDados)
        {
            string strRetorno = "<div class=\"txt-borda\"><div class=\"txt-borda-interior\"> ";

            strRetorno += "<select id=\"ddl" + nome + "\" name=\"" + nome + "\" class=\"inputselect\">";

            foreach (var item in fonteDeDados)
            {
                strRetorno += "<option value=\""+item.Value+"\" "+ ((item.Value == valorSelecionado.ToString()) ? "selected=\"true\"": "") +">"+item.Text+"</option>";
            }

            strRetorno += "</select></div></div>";


            return strRetorno;
        }

        public static string MuambbaCheckBox(this HtmlHelper htmlHelper, string nome, bool selecionado)
        {
            
            string strRetorno = "<input type=\"checkbox\" value=\"true\" ";
            
            if (selecionado)
            {
                strRetorno += "checked=\"checked\" ";
            }
            
            strRetorno += "name=\"" + nome + "\" id=\"ckb" + nome + "\" >";

            return strRetorno;
        }


        public static string SubmitAjax(this HtmlHelper htmlHelper, int numeroJson, string objeto, string value, string classes, string schave)
        {
            return "<a href=\"javascript:void(0);\" onclick=\"m.jsn('" + schave + "').init('" + numeroJson + "','" + objeto + "')\" class=\"button " + classes + "\">" + value + "</a>";
        }

        public static string Submit(this HtmlHelper htmlHelper, string value, string classes)
        {
            return "<input type=\"submit\" value=\""+value+"\" class=\"button "+classes+"\"/>";
        }

        public static string Submit(this HtmlHelper htmlHelper, string value)
        {
            return Submit(htmlHelper, value, "");
        }

        public static string TituloAnuncio(this HtmlHelper htmlHelper, string titulo)
        {
            return Util.TituloAnuncio(titulo);
        }

        public static MvcHtmlString Nl2Br(this HtmlHelper htmlHelper, string text)
        {
            if (text != null && text.Trim() != String.Empty)
            {
                StringBuilder builder = new StringBuilder();
                string[] lines = text.Split('\n');
                for (int i = 0; i < lines.Length; i++)
                {
                    if (i > 0)
                        builder.Append("<br/>");
                    builder.Append(HttpUtility.HtmlEncode(lines[i]));
                }
                return MvcHtmlString.Create(builder.ToString());
            }
            else
            {
                return MvcHtmlString.Create(String.Empty);
            }
            
        }

    }
}
