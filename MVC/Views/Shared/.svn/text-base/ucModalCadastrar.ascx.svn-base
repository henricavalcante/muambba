<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>


<% string SessaoAtual = ViewData["SessaoAtual"].ToString(); %>

<div>
            
                <%= Html.MuambbaTextBox("Nome", "Nome de usuário", 3, "usuario", SessaoAtual)%>
                
                <%= Html.MuambbaTextBox("Email", "Insira um e-mail válido", 4, "", SessaoAtual)%>
                
                <a href="javascript:void(0);" onclick="var objCadastro = {nome: $('#txtNome') ,email: $('#txtEmail')}; m.jsn.get('<%= SessaoAtual %>').init(5,objCadastro);m.c.setaClasseParent(this,'jsn','carregando')" class="button">Cadastre-se</a>
                

                <p class="termos">
                    Ao clicar em Cadastre-se, você está afirmando que leu e concorda com os Termos de uso e com a Política de privacidade.
               </p>

        </div>