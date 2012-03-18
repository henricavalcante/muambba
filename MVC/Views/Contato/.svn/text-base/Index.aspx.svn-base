<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="MVC.ViewBase<dynamic>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


     
      <h1>Contato</h1>


      <div class="content">
        <div>      
            <div class="campo c-0-150">
               <b>Nome:</b> 
            </div>
            <div class="campo c-150-todo">
                <%= Html.MuambbaTextBox("ContatoNome", "Insira seu nome completo aqui, caso seja cliente adicione seu login.",0,0,"",SessaoAtual,"",true)%>
            </div>
        </div>
        <div>      
            <div class="campo c-0-150">
               <b>Email:</b> 
            </div>
            <div class="campo c-150-todo">
                <%= Html.MuambbaTextBox("ContatoEmail", "Informe um Email para contato.",0,0,"",SessaoAtual,"",true)%>
            </div>
        </div> 
        <div>      
            <div class="campo c-0-150">
               <b>Mensagem:</b> 
            </div>
            <div class="campo c-150-todo">
                <%= Html.MuambbaTextArea("ContatoMensagem", "Nos envie uma mensagem, dúvida, crítica ou sugestão. Teremos o prazer de te responder o mais breve possível.",0,0,"",SessaoAtual,"",true)%>
            </div>
        </div> 
      </div>
      <div class="content">
        <a class="button" href="javascript:void(0);" onclick="m.jsn.get('<%= SessaoAtual %>').init(14, {n: $('#txtContatoNome').val(),e:  $('#txtContatoEmail').val(),m: $('#txtContatoMensagem').val()})"><span>Enviar</span></a>
          
      </div>
 



</asp:Content>
