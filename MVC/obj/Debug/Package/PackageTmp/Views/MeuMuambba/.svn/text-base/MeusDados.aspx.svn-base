<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="MVC.ViewBase<dynamic>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">

<% if ((bool)ViewData["ModoDebug"])
       {%>
        <link href="/Content/c$a$fileuploader.css" rel="stylesheet" type="text/css" />
        <script src="/Scripts/c$a$fileuploader.js" type="text/javascript"></script>
        <link href="/Content/e$a$jquery.autocomplete.css" rel="stylesheet" type="text/css" />
        <script src="/Scripts/e$a$jquery.autocomplete.js" type="text/javascript"></script>
    <% }
       else
       { %>

        <link href="/css/c/<%= ViewData["SessaoAtual"].ToString() %>.css" rel="stylesheet" type="text/css" />
        <script src="/js/c/<%= ViewData["SessaoAtual"].ToString() %>.js" type="text/javascript"></script>
        <link href="/css/e/<%= ViewData["SessaoAtual"].ToString() %>.css" rel="stylesheet" type="text/css" />
        <script src="/js/e/<%= ViewData["SessaoAtual"].ToString() %>.js" type="text/javascript"></script>

    <% } %> 
     
</asp:Content>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <%
        
        
        Html.RenderPartial("ucAbasSuperiores");

        var u = UsuarioLogado();
        
        var lstContatosTipos = new BLLUsuarioContatoTipo().GetAll();
        var slContatosTipos = new SelectList(lstContatosTipos,"ID","UsuarioContatoTipo1");
        
        
    %>

<h1><%= u.Nome + " " + u.Sobrenome +" (" + u.Usuario1 +")"%></h1>
<h3>Mantenha seus dados pessoais sempre atualizados, é através deles que outros usuários te encontrarão. </h3>
     <div>
    <form action="/MeuMuambba/MeusDados" method="post" enctype="multipart/form-data">
      <div class="content">
        <h2>Dados Pessoais</h2>
          
        <div>      
            <div class="campo c-0-150">
               <b>Nome:</b> 
            </div>
            <div class="campo c-150-todo">
                <%= Html.MuambbaTextBox("CadNome", "Insira seu Sobrenome", 0,0, "", SessaoAtual,u.Nome,true)%>
            </div>
        </div> 
        <div>      
            <div class="campo c-0-150">
               <b>Sobrenome:</b>
            </div>
            <div class="campo c-150-todo">
                <%= Html.MuambbaTextBox("CadSobrenome", "Insira seu Sobrenome", 0,0, "", SessaoAtual,u.Sobrenome,true)%>
            </div>
        </div> 
        <div>      
            <div class="campo c-0-150">
               <b>CPF:</b>
            </div>
            <div class="campo c-150-todo">
                <%= Html.MuambbaTextBox("CadCPF", "Insira seu CPF sem pontos nem traços", 6,0, "cpf", SessaoAtual, u.CPF, true)%>
            </div>
        </div> 
        <div>      
            <div class="campo c-0-150">
               <b>Senha:</b>
            </div>
            <div class="campo c-150-todo">
                <%= Html.MuambbaTextBoxSenha("CadSenha", "Caso queira alterar a senha insira uma nova senha aqui.",  SessaoAtual)%>
            </div>
        </div> 
        <div>      
            <div class="campo c-0-150">
               <b>Confirmar:</b>
            </div>
            <div class="campo c-150-todo">
                <%= Html.MuambbaTextBoxSenha("CadConfirmaSenha", "Repita a senha caso queira realmente alterar", SessaoAtual)%>
            </div>
        </div> 
          

      </div>
      <div class="content">
        <h2>Endereço</h2>

        <div>
            <div class="campo c-0-150">
                <b>Endereço: </b>
            </div>
            <div class="campo c-150-todo">
                <%= Html.MuambbaTextBox("Endereco", "Informe o cep ou o nome de sua rua.", 0, 7, "", SessaoAtual, (u.Endereco != null) ? BLLProcedures.stpEnderecoList("id"+u.Endereco.EnderecoCep_ID.ToString()).First().Endereco : "", true)%>
            </div>
        </div>
        <div>
            <div class="campo c-0-150">
                <b>Complemento:  </b>
            </div>
            <div class="campo c-150-todo">
                <%= Html.MuambbaTextBox("CadComplemento", "Informe o número e todos os outros complementos aqui.",0,0,"",SessaoAtual, (u.Endereco != null) ?u.Endereco.Complemento:"" ,true)%>
            </div>
        </div>

          
      </div>


      <div class="content">
        <h2>Fotos</h2>
        <div id="upload-fotos">		
	        <noscript>			
		        <p>Habilite o Javascript para fazer upload das fotos.</p>
	        </noscript>
            <div class="qq-uploader">
                <div class="qq-upload-drop-area"><span>Arraste arquivos para esta área para fazer upload.</span></div>
                <div class="qq-uploader-div"><a href="javascript:void(0);"class="qq-upload-button button">Insira as Imagens</a></div>
                <ul class="qq-upload-list">
                <% int cont = 0; foreach (var foto in u.UsuarioFoto)
                   { %>
                    <li class=" qq-upload-success">
                        <img alt="Imagem <%= cont %>" src="/Imagens/Usuarios/<%= foto.NomeArquivo.Split('.')[0] + "s." + foto.NomeArquivo.Split('.')[1]%>" original="<%= foto.NomeArquivo %>" class="imgAnuncio">
                        <input type="hidden" value="320111211170517203.png" name="Fotos_antiga<%= cont %>"><div>
                        <a href="javascript:void(0);" class="qq-upload-excluir button" >Excluir</a><br>
                        <span class="qq-upload-failed-text">Falhou</span></div>
                    </li>
                <% cont += 1;
                   } %>
                </ul>
             </div>
        </div>
        <script type="text/javascript" language="javascript">
            function CriarUploader() {
                var uploader = new qq.FileUploader({ action: '/Ajax/UploadFotoUsuario', pathFotos: '/Imagens/Usuarios/', actionExcluir: '/Ajax/ExcluirFotoUsuario' });
            }

            var isiPad = navigator.userAgent.match(/iPad/i) != null;

            if (isiPad) {
                $('.upload-fotos-content').hide();
            }
            window.onload = CriarUploader;
        </script> 
      </div>


      <div class="content">
        <h2>Contato</h2>
                <ul id="lstContatos">

                <%
                    var contador = 0;
                    foreach (var item in u.UsuarioContato)
                    {
                        %>
                 <li indice="<%= contador %>" class="clearfix">
                    <div class="campo c-0-150">
                        <div style="width:120px;display:inline-block;">
                            <%= Html.MuambbaDropDownList("CadUC_" + contador.ToString()+"_UCTipo",item.UsuarioContatoTipo_ID, slContatosTipos)%>
                        </div>
                        <div style="display:inline-block;margin-left:5px;">
                            <%= Html.MuambbaCheckBox("CadUC_" + contador.ToString() + "_UCPub", item.Publico)%>
                        </div>
                        
                    </div>
                    
                    <div class="campo c-150-todo">
                        <%= Html.MuambbaTextBox("CadUC_" + contador.ToString() + "_UCContato", "<-- Marque para tornar este contato visível a todos e informe o contato aqui.", 0,0, "", SessaoAtual, item.UsuarioContato1, true)%>
                    </div>


                </li>
                        
                        <%
                        contador += 1;
                    }
                    
                 %>

                 <li indice="<%= contador %>"  class="clearfix">
                 <div class="campo c-0-150">
                    <div style="width:120px;display:inline-block;">
                        <%= Html.MuambbaDropDownList("CadUC_" + contador.ToString()+"_UCTipo", 0, slContatosTipos)%>
                    </div>
                    <div style="display:inline-block;margin-left:5px;">
                        <%= Html.MuambbaCheckBox("CadUC_" + contador.ToString() + "_UCPub", false)%>
                    </div>
                 </div>
                <div class="campo c-150-todo"><%= Html.MuambbaTextBox("CadUC_" + contador.ToString() + "_UCContato", "<-- Marque para tornar este contato visível a todos e informe o contato aqui.", 0, 0, "", SessaoAtual, "", true)%></div>
                </li>
        </ul>
                <a href="javascript:void(0);" onclick="var l = '#lstContatos>li:last'; var a = $(l).clone(); var b = eval(a.attr('indice')) + 1; if (b < 10) { a = $('<a></a>').append(a.attr('indice', b)); c = m.util.substituir(a.html(), '_' + (b - 1) + '_', '_' + b + '_');$('#lstContatos').append(c);$(l).focus(); } else { alert('Máximo de contatos excedido.')}" class="button">Adicionar</a>
                
      </div>
      <div class="content">
        <h2>Preferências</h2>
        <div class="anuncio-conteudo-lista">
            <div>
                <div class="campo c-0-150">
                    <b>Linguagem: </b>
                </div>
                <div class="campo c-150-todo">
                    <%= u.Linguagem %>
                </div>
            </div>
            <div>
                <div class="campo c-0-150">
                    <b>Anuncios por Página:</b>
                </div>
                <div class="campo c-150-todo">
                    <%= Html.MuambbaTextBox("CadAnunciospagina", "Informe a quantidade de anuncios por página que será exibido." , 0, 0,"99", SessaoAtual,u.AnunciosPorPagina.ToString(),true)%>
                </div>
            </div>
            <div>
                <div class="campo c-0-150">
                    <b>Manter Conectado: </b>
                </div>
                <div class="campo c-150-todo">
                    <%= Html.MuambbaCheckBox("CadManterConectado", u.ManterConectado)%>
                </div>
            </div>
            <div>
                <div class="campo c-0-150">
                    <b>Receber Emails: </b>
                </div>
                <div class="campo c-150-todo">
                    <%= Html.MuambbaCheckBox("CadReceberEmails", u.ReceberEmails)%>
                </div>
            </div>

                
            </div>
      </div>
      <div class="content">
        <%= Html.Submit("Salvar") %>
      </div>
    </form>
    </div>




</asp:Content>
