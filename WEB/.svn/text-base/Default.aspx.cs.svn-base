using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Util;
using BLL;

namespace WEB
{
    public partial class _Default : System.Web.UI.Page
    {

        

        private void InicializarForm()
        {

            ListarCategorias();
            ListarAnuncios();
            ListarTagCloud();

            try
            {
                
            }
            catch (Exception ex)
            {

                Javascript.ShowMsg(this.Page, ex.Message);
            }

        }

        private void SugestaoEnviar()
        {
            //BLL.Sugestao.Inserir(txtNome.Text, txtEmail.Text, txtSugestao.Text, Conversion.Val(IdUsuarioLogado));

            //Util.Email.Enviar("hnri_mxel@hotmail.com", "Sugestão Muambba", txtSugestao.Text);
        }


        private void SugestaoLimpar()
        {
            txtNome.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtSugestao.Text = string.Empty;

        }


        private void ListarAnuncios()
        {
            var b = new BLLAnuncio();
            repAnuncios.DataSource = b.ListarCapa();
            
            repAnuncios.DataBind();

        }

        private void ListarCategorias()
        {

            var b = new BLLCategoria();
            repCategoria.DataSource = b.ListarPais(0);
            repCategoria.DataBind();

        }

        private void ListarTagCloud()
        {
            var b = new BLLBusca();

            repTagCloud.DataSource = b.ListarTagCloud();
            repTagCloud.DataBind();


        }

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!IsPostBack)
            {
                InicializarForm();

            }
        }


        protected void btnEnviarSugestao_Click(object sender, EventArgs e)
        {

            try
            {
                SugestaoEnviar();
                SugestaoLimpar();

                Javascript.ShowMsg(this.Page, "Sugestão Processada com Sucesso. Obrigado pela ajuda.");


            }
            catch (Exception ex)
            {
                Javascript.ShowMsg(this.Page, ex.Message);

            }

        }
    }
}
