using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Util;
using MVC.Models;

namespace WEB
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        #region "Propriedades"

        //public int IdUsuarioLogado
        //{
        //    get { return (int)Session["IdUsuarioLogado"]; }
        //    set { Session["IdUsuarioLogado"] = value; }
        //}
        public Usuario UsuarioLogado
        {
            get { return (Usuario)Session["UsuarioLogado"]; }
            set { Session["UsuarioLogado"] = value; }
        }

        public IList<string> PossiveisSenhas
        {
            get { return (IList<string>)ViewState["PossiveisSenhas"]; }
            set { ViewState["PossiveisSenhas"] = value; }
        }

        #endregion


        
        private void buscar()
        {
            //BLL.Busca.Inserir(txtPesquisa.Text);
            var b = new BLL.BLLBusca();
            b.Inserir(txtPesquisa.Text, UsuarioLogado);
            Response.Redirect(string.Format("busca.aspx?q={0}", txtPesquisa.Text));
            
        }


        private void InicializarForm()
        {
            lblData.Text = Util.Data.DataPorExtenso(DateTime.Now);
            lblVersao.Text = "BETA 0.07 - AGO/11";

            if (UsuarioLogado != null)
            {
                lblUsuario.Text = Util.Data.Saudacao(DateTime.Now) + ", " + UsuarioLogado.Nome;

                lnkAjuda.Text = "Minha Conta";
                lnkAjuda.NavigateUrl = "usuario.aspx";

                lnkEntrar.Text = "Sair";
                lnkEntrar.Attributes.Remove("onclick");
                lnkEntrar.NavigateUrl = "logout.aspx";

                lnkCadastrar.Text = "Anuncie";
                lnkCadastrar.NavigateUrl = "anunciar.aspx";

            }
            else
            {
                lnkAjuda.Text = "Ajuda";
                lnkAjuda.NavigateUrl = "ajuda.aspx";

                lblUsuario.Text = Util.Data.Saudacao(DateTime.Now) + ", Visitante";
                lnkEntrar.Text = "Entrar";
                lnkCadastrar.Text = "Cadastre-se";
                lnkCadastrar.NavigateUrl = "cadastrar.aspx";
            }

            AdicionarAtributosCampos();

        }



        private void AdicionarAtributosCampos()
        {
            MontarBotoes();

            btnSenha1.Attributes.Add("onclick", "javascript: btn01(); return false;");
            btnSenha2.Attributes.Add("onclick", "javascript: btn02(); return false;");
            btnSenha3.Attributes.Add("onclick", "javascript: btn03(); return false;");
            btnSenha4.Attributes.Add("onclick", "javascript: btn04(); return false;");
            btnSenha5.Attributes.Add("onclick", "javascript: btn05(); return false;");
        }


        public void ProximaCasaDecimal(string valor1, string valor2, ref List<string> arr)
        {
            if (arr.Count > 0)
            {
                var arrayAntigo = new List<string>();

                foreach (string i in arr)
                {
                    arrayAntigo.Add(i);
                }

                foreach (var i in arrayAntigo)
                {
                    arr.Add(i + valor1);
                    arr.Add(i + valor2);

                }

                ////mudando para o segundo digito
                //foreach (int j in arrayAntigo)
                //{
                //    array.Add(j + valor1);
                //    array.Add(j + valor2);
                //}

            }
            else
            {
                arr.Add(valor1);
                arr.Add(valor2);

            }
            txtSenha.Text = txtSenha.Text + "*";
            if (txtSenha.Text.Length >= 13)
            {
                ValidarSenha();

                Response.Redirect("default.aspx");
            }

        }

        public void ValidarSenha()
        {
            //bool validou = false;

            //string senha = null;
            //DAL.DsUsuario.UsuarioDataTable dt = new DAL.DsUsuario.UsuarioDataTable();
            //dt = BLL.Usuario.Listar(0, txtUsuario.Text);

            var b = new BLL.BLLUsuario();
            var u = b.ValidarSenha(txtUsuario.Text, PossiveisSenhas);


            Util.Validar.Condicao(u != null, "Usuário e/ou Senha Inválidos.");

            //IdUsuarioLogado = u.IdUsuario;
            UsuarioLogado = u;

        }


        private void RenovarSenha()
        {
            var b = new BLL.BLLUsuario();
            var s = b.RenovarSenha(txtLembrarSenhaEmail.Text);

            if (s)
            {
               Util.Javascript.ShowMsg(this.Page, "Usuário inexistente ou E-Mail Incorreto.");

            }
            else
            {
                Util.Javascript.ShowMsg(this.Page, "Acesse seu e-mail e verifique as instruções.");
            }

            //Random Aleatorio = new Random();
            //int NovaSenha = Aleatorio.Next(100000, 999999);


            //BLL.Usuario.AtualizarSenha(0, txtLembrarSenhaEmail.Text, Cryptografia.GerarHash(NovaSenha, Cryptografia.HashMethod.MD5));

            //Utilitarios.EnviarEmail(txtLembrarSenhaEmail.Text, "Nova Senha", string.Format("Sua nova senha é {0}", NovaSenha));
        }

        public void RealizarLogin()
        {
            ValidarSenha();
            //InicializarForm()
            Response.Redirect(Request.Url.AbsoluteUri);


        }


        private void limpar()
        {
            txtUsuario.Text = "Login:";
            txtSenha.Text = "Senha: ";
            PossiveisSenhas = new List<string>();
        }


        private void MontarBotoes()
        {
            List<int> digito = new List<int>();
            Random Aleatorio = new Random();
            int Numero = 0;

            limpar();
            while (digito.Count < 10)
            {
                Numero = Aleatorio.Next(0, 10);
                if (!digito.Contains(Numero))
                {
                    digito.Add(Numero);
                }
            }


            btnSenha1.Text = digito[0] + "  " + digito[1];
            btnSenha2.Text = digito[2] + "  " + digito[3];
            btnSenha3.Text = digito[4] + "  " + digito[5];
            btnSenha4.Text = digito[6] + "  " + digito[7];
            btnSenha5.Text = digito[8] + "  " + digito[9];


        }


        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!IsPostBack)
            {
                InicializarForm();
            }

        }

        
        protected void txtArr_TextChanged1(object sender, EventArgs e)
        {
            try
            {
                PossiveisSenhas = txtArr.Text.Split(',').ToList();

                RealizarLogin();
            }
            catch (Exception ex)
            {
                Javascript.ShowMsg(this.Page, ex.Message);
            }
        }


        protected void imbPesquisa_Click1(object sender, ImageClickEventArgs e)
        {
            buscar();
        }

        protected void btnLembrarSenha_Click1(object sender, EventArgs e)
        {
            RenovarSenha();
        }

        

    }
}
