

using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using MVC.Models;

namespace WEB
{
    public partial class Anunciar : FormBaseLogado
    {


        #region "Propriedades"



        public int IdAnuncioTipo
        {
            get { return int.Parse(ddlTipo.SelectedValue); }
            set { ddlTipo.SelectedValue = Convert.ToString(value); }
        }
        public int IdAnuncioConservacao
        {
            get { return int.Parse(ddlConservacao.SelectedValue); }
            set { ddlConservacao.SelectedValue = Convert.ToString(value); }
        }

        public int DataExp
        {
            get { return int.Parse(ddlExpira.SelectedValue); }
            set { ddlExpira.SelectedValue = Convert.ToString(value); }
        }

        public Anuncio Anuncio
        {
            get
            {
                if (ViewState["Anuncio"] == null)
                {
                    ViewState["Anuncio"] = new Anuncio();

                }
                return (Anuncio)ViewState["Anuncio"];
            }
            set { ViewState["Anuncio"] = (Anuncio)value; }
        }

        //public IList<AnuncioFoto> AnuncioFotos
        //{
        //    get
        //    {
        //        if (ViewState["AnuncioFoto"] == null)
        //        {
        //            ViewState["AnuncioFoto"] = new List<AnuncioFoto>();

        //        }
        //        return (IList<AnuncioFoto>)ViewState["AnuncioFoto"];
        //    }
        //    set { ViewState["AnuncioFoto"] = (IList<AnuncioFoto>)value; }
        //}

        public int IdCategoria
        {
            get { return (int)ViewState["IdCategoria"]; }
            set { ViewState["IdCategoria"] = (int)value; }
        }

        private int IdAnuncio
        {
            get
            {
                if (Request["a"] == null)
                {
                    return 0;
                }
                else
                {
                    return int.Parse(Request["a"]);
                }
                
            }
        }


        #endregion

        #region "Métodos Privados"


        private void InicializarForm()
        {
            preencherTipo();
            preencherConservacao();
            CategoriaLimpar();

            if (IdAnuncio > 0)
            {
                Ler();
            }

            AdicionarAtributosCampos();

        }


        private void preencherTipo()
        {
            try
            {
                var b = new BLLAnuncio();
                ddlTipo.DataSource = b.ListarTipo();
                ddlTipo.DataTextField = "anuncioTipo1";
                ddlTipo.DataValueField = "idAnuncioTipo";
                ddlTipo.DataBind();

            }
            catch (Exception)
            {

                throw;
            }
        }
        private void preencherConservacao()
        {
            try
            {
                var b = new BLLAnuncioConservacao();
                ddlConservacao.DataSource = b.tol();
                ddlConservacao.DataTextField = "AnuncioConservacao1";
                ddlConservacao.DataValueField = "IdAnuncioConservacao";
                ddlConservacao.DataBind();

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void preencherCategoria()
        {
            try
            {
                var b = new BLL.BLLCategoria();

                ddlCategoria.DataSource = b.ListarPais(IdCategoria);
                ddlCategoria.DataTextField = "Categoria1";
                ddlCategoria.DataValueField = "IdCategoria";
                ddlCategoria.DataBind();


                ddlCategoria.Items.Insert(0, "Selecione");

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void AdicionarAtributosCampos()
        {

        }

        private void CategoriaLimpar()
        {

            IdCategoria = 0;
            lblCategoria.Text = string.Empty;
            preencherCategoria();
        }

        private void ListarFotos()
        {
            repFotos.DataSource = Anuncio.AnuncioFoto;
            repFotos.DataBind();
        }

        private void Ler()
        {
            //DAL.DsAnuncio.AnuncioDataTable dt = null;
            //dt = BLL.Anuncio.Listar(IdAnuncio, 0, UsuarioLogado.IdUsuario);
            var b = new BLLAnuncio();
            Anuncio = b.SelecionarPorId(IdAnuncio);

            //var _with2 = dt(0);
            txtTitulo.Text = Anuncio.Titulo;
            txtSubtitulo.Text = Anuncio.SubTitulo;

            txtDescricao.Text = Anuncio.Descricao.Replace("<br/>", "\n");
            IdCategoria = Anuncio.IdCategoria;
            lblCategoria.Text = Anuncio.Categoria.Categoria1;

            IdAnuncioTipo = Anuncio.IdAnuncioTipo;

            txtValor.Text = Anuncio.Preco.ToString("##,##0.00");


            ddlExpira.Enabled = false;
            ddlExpira.Items.Clear();

            ddlExpira.ToolTip = "A data de expiração não pode ser alterada.";

            System.Web.UI.WebControls.ListItem DataExp = new System.Web.UI.WebControls.ListItem();
            DataExp.Text = Anuncio.DataExp.ToString("dd/MM/yyyy");
            DataExp.Value = "0";

            ddlExpira.Items.Insert(0, DataExp);
            ddlExpira.SelectedValue = "0";

            btnAnunciar.Text = "Alterar";

            //Anuncio.AnuncioFoto = Anuncio.AnuncioFoto.ToList();


            //DsAnuncioFoto = BLL.Anuncio.Foto.Listar(IdAnuncio);
            ListarFotos();
        }

        private void SalvarAnuncio()
        {
            //BLL.Anuncio.Salvar(txtTitulo.Text, txtSubtitulo.Text, txtDescricao.Text.Replace("\n", "<br/>"), Convert.ToDecimal(txtValor.Text), IdAnuncioTipo, IdCategoria, DataExp, UsuarioLogado.IdUsuario, DsAnuncioFoto, IdAnuncio);
            
            var b = new BLLAnuncio();
            if (Anuncio.IdAnuncio != 0)
            {
                Anuncio.Titulo = txtTitulo.Text;
                Anuncio.SubTitulo = txtSubtitulo.Text;
                Anuncio.Descricao = txtDescricao.Text.Replace("\n", "<br/>");
                Anuncio.Preco = Convert.ToDecimal(txtValor.Text);
                Anuncio.IdAnuncioTipo = IdAnuncioTipo;
                Anuncio.IdCategoria = IdCategoria;
                Anuncio.DataExp = DateTime.Now.AddDays(DataExp);
                Anuncio.IdUsuarioInc = UsuarioLogado.IdUsuario;
                Anuncio.DataInc = DateTime.Now;
                Anuncio.IdAnuncioConservacao = IdAnuncioConservacao;

                b.Add(Anuncio);

            }
            else
            {
                Anuncio = b.Find(a => a.IdAnuncio == Anuncio.IdAnuncio).Single();

                Anuncio.Titulo = txtTitulo.Text;
                Anuncio.SubTitulo = txtSubtitulo.Text;
                Anuncio.Descricao = txtDescricao.Text.Replace("\n", "<br/>");
                Anuncio.Preco = Convert.ToDecimal(txtValor.Text);
                Anuncio.IdAnuncioTipo = IdAnuncioTipo;
                Anuncio.IdCategoria = IdCategoria;
                Anuncio.IdUsuarioInc = UsuarioLogado.IdUsuario;
                Anuncio.DataUpd = DateTime.Now;
                Anuncio.IdAnuncioConservacao = IdAnuncioConservacao;
                 
            }
            b.SaveChanges();
        }

        #endregion


        #region "Eventos"
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!IsPostBack)
            {
                InicializarForm();
            }
        }


        #endregion

        protected void ddlCategoria_SelectedIndexChanged1(object sender, EventArgs e)
        {
            try
            {
                if (ddlCategoria.SelectedItem.ToString() == "Limpar")
                {
                    CategoriaLimpar();
                }
                else
                {
                    IdCategoria = int.Parse(ddlCategoria.SelectedValue);
                    lblCategoria.Text = lblCategoria.Text + " >> " + ddlCategoria.SelectedItem.ToString();
                    preencherCategoria();
                    ddlCategoria.Items.Insert(ddlCategoria.Items.Count, "Limpar");
                }

            }
            catch (Exception ex)
            {
                Util.Javascript.ShowMsg(this.Page, ex.Message);
            }
        }
        

        private void UploadFoto()
        {
            //Verificamos se tem alguma coisa postada 
            if ((FileUpload1.PostedFile != null))
            {
                //Pegamos as informacoes do arquivo postado 
                System.IO.FileInfo infoarquivo = new System.IO.FileInfo(FileUpload1.PostedFile.FileName);
                //Definimos onde ele será salvo 

                string Caminho = string.Format("{0}\\", Server.MapPath("img_anuncios"));

                string NomeArquivo = string.Format("{0:yyyyMMddhhmmss}{1}_big.jpg", DateTime.Now, UsuarioLogado.IdUsuario);

                string NomeArquivoMedio = NomeArquivo.Replace("big", "mid");
                string NomeArquivoMini = NomeArquivo.Replace("big", "min");

                //Dim NomeArquivoMini As String = String.Format("{0:yyyyMMddhhmmss}{1}_min.jpg", Now, Val(IdUsuarioLogado))
                //Dim NomeArquivoMedio As String = String.Format("{0:yyyyMMddhhmmss}{1}_mid.jpg", Now, Val(IdUsuarioLogado))
                FileUpload1.PostedFile.SaveAs(Caminho + "orig" + NomeArquivo);

                System.Drawing.Image objImage = null;

                objImage = System.Drawing.Image.FromFile(Caminho + "orig" + NomeArquivo);
                //máximo 890px
                if (objImage.Width > 890)
                {
                    objImage = objImage.GetThumbnailImage(890, 890 * (objImage.Height / objImage.Width), null, System.IntPtr.Zero);
                }

                objImage.Save(Caminho + NomeArquivo);

                if (objImage.Width > objImage.Height)
                {
                    //paisagem
                    objImage.GetThumbnailImage(90 * objImage.Width / objImage.Height, 90, null, System.IntPtr.Zero).Save(Caminho + NomeArquivoMini);
                    objImage.GetThumbnailImage(240 * objImage.Width / objImage.Height, 240, null, System.IntPtr.Zero).Save(Caminho + NomeArquivoMedio);

                }
                else if (objImage.Width < objImage.Height)
                {
                    //retrato
                    objImage.GetThumbnailImage(90, 90 * objImage.Height / objImage.Width, null, System.IntPtr.Zero).Save(Caminho + NomeArquivoMini);
                    objImage.GetThumbnailImage(240, 240 * objImage.Height / objImage.Width, null, System.IntPtr.Zero).Save(Caminho + NomeArquivoMedio);

                }
                else
                {
                    //quadrado
                    objImage.GetThumbnailImage(90, 90, null, System.IntPtr.Zero).Save(Caminho + NomeArquivoMini);
                    objImage.GetThumbnailImage(240, 240, null, System.IntPtr.Zero).Save(Caminho + NomeArquivoMini);

                }

                Anuncio.AnuncioFoto.Add(new AnuncioFoto { NomeArquivo = NomeArquivo, NomeArquivoMiniatura = NomeArquivoMini, DataInc = DateTime.Now });

                //DsAnuncioFoto.AddAnuncioFotoRow(null, null, NomeArquivo, NomeArquivoMini, null);
                //DsAnuncioFoto.PrimaryKey = null;
            }
            else
            {
                Util.Javascript.ShowMsg(this.Page, "Selecione um arquivo!");
            }



        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                UploadFoto();
                ListarFotos();

            }
            catch (Exception ex)
            {
                Util.Javascript.ShowMsg(this.Page, ex.Message);
            }
        }
        

        

        protected void btnAnunciar_Click1(object sender, EventArgs e)
        {
            try
            {
                SalvarAnuncio();
                Util.Javascript.ShowMsg(this.Page, "Anunciado com sucesso");
                Response.Redirect(PAGINA_PADRAO);
            }
            catch (Exception ex)
            {
                
                    Util.Javascript.ShowMsg(this.Page, ex.Message);
                
               
            }
        }


       

       



    }
}
