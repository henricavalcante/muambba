<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="MVC.ViewBase<dynamic>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">


 <% if ((bool)ViewData["ModoDebug"])
       {%>
        

    <link href="/Content/f$a$jquery.jqzoom.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/f$a$jquery.jqzoom-core.js" type="text/javascript"></script>


    <% }
       else
       { %>

    <link href="/css/f/<%= ViewData["SessaoAtual"].ToString() %>.css" rel="stylesheet" type="text/css" />
    <script src="/js/f/<%= ViewData["SessaoAtual"].ToString() %>.js" type="text/javascript"></script>


    <% } %> 

    <style type"text/css">

ul#thumblist{display:block;}
ul#thumblist li{display:block;margin:5px;list-style:none;}
ul#thumblist li a{display:block;border:1px solid #CCC;}
ul#thumblist li a.zoomThumbActive{
    border:1px solid red;
}

.jqzoom{

	text-decoration:none;
	float:left;
}

</style>

<script type="text/javascript">
    $(document).ready(function () {
        $('.jqzoom').jqzoom({
            zoomType: 'standard',
            lens: true,
            preloadImages: false,
            alwaysOn: false
        });

    });
</script>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<%
    var ctx = new ContextoBLL();

    
    var BLLAnuncio = new BLLAnuncio(ctx);

    BLLAnuncio.AdicionarVisita((int)ViewData["id"]);
    var a = BLLAnuncio.SelectByKey((int)ViewData["id"]);
    
    //a.Visitas += 1;
    //BLLAnuncio.UpdateAndSave(oAnuncio);
     %>


     
<h1 class="titulo"><%= a.Titulo %></h1>


<div class="clearfix"  style="width:100%;" >

<div class="clearfix" style="float:right;width:424px">

<%
    if (a.AnuncioFoto.Count > 0)
    {
%>
    

        <div class="clearfix" style="float: left; width: 102px;">

   

            <ul id="thumblist" class="clearfix" >
                    <%
        foreach (var item in a.AnuncioFoto)
        {  
                    %>
                    <li><a href='javascript:void(0);' rel="{gallery: 'gal1', smallimage: '/Imagens/Anuncios/<%= item.NomeArquivo.Split('.')[0] + "p." + item.NomeArquivo.Split('.')[1]%>',largeimage: '/Imagens/Anuncios/<%= item.NomeArquivo %>'}"><img src='/Imagens/Anuncios/<%= item.NomeArquivo.Split('.')[0] + "s." + item.NomeArquivo.Split('.')[1]%>' width="90px" height="90px"></a></li>
		     
                    <%  
        }
                    %>
            </ul>  


	    </div> 
    
	    <div class="clearfix" style="float:right;">
            <a href="/Imagens/Anuncios/<%= a.NomeArquivoFotoPrincipal %>" class="jqzoom" rel='gal1'  title="<%= a.Titulo %>" >
                <img src="/Imagens/Anuncios/<%= a.NomeArquivoFotoPrincipal.Split('.')[0] + "p." + a.NomeArquivoFotoPrincipal.Split('.')[1]%>"  title="<%= a.Titulo %>"  style="border: 1px solid #666;">
            </a>
	    </div>
    
 <%
    }
    else { 
    %>
        
    <%
    }
        
%>
<div style="text-align: right;">
    <script type="text/javascript"><!--
        google_ad_client = "ca-pub-1356931097217884";
        /* MuambbaSubstitutoFotos */
        google_ad_slot = "5657398215";
        google_ad_width = 336;
        google_ad_height = 280;
    //-->
    </script>
    <script type="text/javascript"
    src="http://pagead2.googlesyndication.com/pagead/show_ads.js">
    </script>
        
</div>


  </div>
<div class="clearfix" style="padding-right: 426px; display: block;">
	<h2><%= a.SubTitulo%></h2>

        <div>      
            <div class="campo c-0-150">
               <b>Conservação:</b> 
            </div>
            <div class="campo c-150-todo">
                <%= AnuncioConservacao.ToString(a.AnuncioConservacao_ID)%>
            </div>
        </div>
        <div>      
            <div class="campo c-0-150">
               <b>Tipo:</b> 
            </div>
            <div class="campo c-150-todo">
                <%= AnuncioTipo.ToString(a.AnuncioTipo_ID)%>
            </div>
        </div>
        <div>      
            <div class="campo c-0-150">
               <b>Visitas:</b> 
            </div>
            <div class="campo c-150-todo">
                <%= a.Visitas %>
            </div>
        </div>
        <div>      
            <div class="campo c-0-150">
               <b>Ofertas:</b> 
            </div>
            <div class="campo c-150-todo">
                <%= a.Ofertas %>
            </div>
        </div>
        <% if (a.C_Veiculo_Cor_ID != null) { %>
        <div>      
            <div class="campo c-0-150">
               <b>Cor do Veículo:</b> 
            </div>
            <div class="campo c-150-todo">
                <%= Veiculo_Cor.ToString(a.C_Veiculo_Cor_ID.GetValueOrDefault()) %>
            </div>
        </div>
        <%} %>
        <% if (a.C_Veiculo_Ano_Fabricacao != null || a.C_Veiculo_Ano_Modelo != null)
           { %>
        <div>      
            <div class="campo c-0-150">
               <b>Ano:</b> 
            </div>
            <div class="campo c-150-todo">
                <% if (a.C_Veiculo_Ano_Fabricacao == a.C_Veiculo_Ano_Modelo)
                   { %>
                   
                    <%= a.C_Veiculo_Ano_Fabricacao%>

                   <% } else { %>

                    <%= a.C_Veiculo_Ano_Fabricacao%><% if (a.C_Veiculo_Ano_Fabricacao != null && a.C_Veiculo_Ano_Modelo != null) { %>/<% } %><%= a.C_Veiculo_Ano_Modelo%>

                   <% }%>
            </div>
        </div>
        <%} %>
        <% if (a.C_Veiculo_Combustivel_ID != null) { %>
        <div>      
            <div class="campo c-0-150">
               <b>Km:</b> 
            </div>
            <div class="campo c-150-todo">
                <%= a.C_Veiculo_Km.GetValueOrDefault() %>
            </div>
        </div>
        <%} %>
        <% if (a.C_Veiculo_Acessorios != null) { %>
        <div>      
            <div class="campo c-0-150">
               <b>Acessórios:</b> 
            </div>
            <div class="campo c-150-todo">
                <ul>
                <% foreach (var item in a.C_Veiculo_Acessorios.Split('|'))
                   {
                       %>
                       
                       <li><%= item %></li>
                       
                       <%
                   }  %>
                </ul>
            </div>
        </div>
        <%} %>
        <% if (a.C_Imovel_Quartos != null)
           { %>
        <div>      
            <div class="campo c-0-150">
               <b>Quartos:</b> 
            </div>
            <div class="campo c-150-todo">
                <%= a.C_Imovel_Quartos.GetValueOrDefault()%>
            </div>
        </div>
        <%} %>
        <% if (a.C_Imovel_Suites != null)
           { %>
        <div>      
            <div class="campo c-0-150">
               <b>Suítes:</b> 
            </div>
            <div class="campo c-150-todo">
                <%= a.C_Imovel_Suites.GetValueOrDefault()%>
            </div>
        </div>
        <%} %>
        
        <% if (a.C_Imovel_Vagas_Garagem != null)
           { %>
        <div>      
            <div class="campo c-0-150">
               <b>Vagas de Garagem:</b> 
            </div>
            <div class="campo c-150-todo">
                <%= a.C_Imovel_Vagas_Garagem.GetValueOrDefault()%>
            </div>
        </div>
        <%} %>

        
        <% if (a.C_Imovel_Idade != null)
           { %>
        <div>      
            <div class="campo c-0-150">
               <b>Idade do Imóvel:</b> 
            </div>
            <div class="campo c-150-todo">
                <%= a.C_Imovel_Idade.GetValueOrDefault()%> Anos
            </div>
        </div>
        <%} %>

        
        <% if (a.C_Imovel_IPTU != null)
           { %>
        <div>      
            <div class="campo c-0-150">
               <b>Valor do IPTU:</b> 
            </div>
            <div class="campo c-150-todo">
                R$ <%= a.C_Imovel_IPTU.GetValueOrDefault().ToString("##,##0.00")%>
            </div>
        </div>
        <%} %>
        
        <% if (a.C_Imovel_Area_Terreno != null)
           { %>
        <div>      
            <div class="campo c-0-150">
               <b>Área do Terreno:</b> 
            </div>
            <div class="campo c-150-todo">
                <%= a.C_Imovel_Area_Terreno.GetValueOrDefault().ToString("##,##0.00")%> m²
            </div>
        </div>
        <%} %>

        <% if (a.C_Imovel_Area_Util != null)
           { %>
        <div>      
            <div class="campo c-0-150">
               <b>Área Útil:</b> 
            </div>
            <div class="campo c-150-todo">
                <%= a.C_Imovel_Area_Util.GetValueOrDefault().ToString("##,##0.00")%> m²
            </div>
        </div>
        <%} %>

        <% if (a.C_Imovel_Condominio_Nome != null)
           { %>
        <div>      
            <div class="campo c-0-150">
               <b>Nome do Condomínio:</b> 
            </div>
            <div class="campo c-150-todo">
                <%= a.C_Imovel_Condominio_Nome %>
            </div>
        </div>
        <%} %>
        
        <% if (a.C_Imovel_Condominio_Valor != null)
           { %>
        <div>      
            <div class="campo c-0-150">
               <b>Taxa de Condomínio:</b> 
            </div>
            <div class="campo c-150-todo">
                R$ <%= a.C_Imovel_Condominio_Valor.GetValueOrDefault().ToString("##,##0.00")%>
            </div>
        </div>
        <%} %>

        <% if (a.C_Imovel_Condominio_Andar != null)
           { %>
        <div>      
            <div class="campo c-0-150">
               <b>Andar do Imóvel:</b> 
            </div>
            <div class="campo c-150-todo">
                <%= a.C_Imovel_Condominio_Andar.GetValueOrDefault()%>º Andar
            </div>
        </div>
        <%} %>

        
        <% if (a.C_Imovel_Condominio_Andares != null)
           { %>
        <div>      
            <div class="campo c-0-150">
               <b>Andares do Condomínio:</b> 
            </div>
            <div class="campo c-150-todo">
            <%= a.C_Imovel_Condominio_Andares.GetValueOrDefault()%> 
            <%if (a.C_Imovel_Condominio_Andares.GetValueOrDefault() == 1){ %> Andar <% } else {  %> Andares <% }%> 
            </div>
        </div>
        <%} %>

        <% if (a.C_Imovel_Condominio_Unidades_Por_Andar != null)
           { %>
        <div>      
            <div class="campo c-0-150">
               <b>Imóveis por Andar:</b> 
            </div>
            <div class="campo c-150-todo">
                <%= a.C_Imovel_Condominio_Unidades_Por_Andar.GetValueOrDefault()%>
                <%if (a.C_Imovel_Condominio_Unidades_Por_Andar.GetValueOrDefault() == 1)  { %> Unidade <% } else {  %> Unidades <% }%> 
            </div>
        </div>
        <%} %>

        
        <% if (a.C_Imovel_Condominio_Administradora != null)
           { %>
        <div>      
            <div class="campo c-0-150">
               <b>Administradora do Condomínio:</b> 
            </div>
            <div class="campo c-150-todo">
                <%= a.C_Imovel_Condominio_Administradora%>
            </div>
        </div>
        <%} %>
        
        <% if (a.C_Imovel_Condominio_Infraestrutura != null)
           { %>
        <div>      
            <div class="campo c-0-150">
               <b>Infraestrutura do Condomínio:</b> 
            </div>
            <div class="campo c-150-todo">
                <ul>
                <% foreach (var item in a.C_Imovel_Condominio_Infraestrutura.Split('|'))
                   {
                       %>
                       
                       <li><%= item %></li>
                       
                       <%
                   }  %>
                </ul>
            </div>
        </div>
        <%} %>

        
        <% if (a.C_Imovel_Instalacoes != null)
           { %>
        <div>      
            <div class="campo c-0-150">
               <b>Instalações do Imóvel:</b> 
            </div>
            <div class="campo c-150-todo">
                <ul>
                <% foreach (var item in a.C_Imovel_Instalacoes.Split('|'))
                   {
                       %>
                       
                       <li><%= item %></li>
                       
                       <%
                   }  %>
                </ul>
            </div>
        </div>
        <%} %>

        <% if (a.C_Imovel_Lazer != null)
           { %>
        <div>      
            <div class="campo c-0-150">
               <b>Diversão e Lazer:</b> 
            </div>
            <div class="campo c-150-todo">
                <ul>
                <% foreach (var item in a.C_Imovel_Lazer.Split('|'))
                   {
                       %>
                       
                       <li><%= item %></li>
                       
                       <%
                   }  %>
                </ul>
            </div>
        </div>
        <%} %>

    <h2><%= a.Usuario.Nome %> (<%= a.Usuario.QualificacaoPositiva - a.Usuario.QualificacaoNegativa%>)</h2>

        <%
            Regex rg = new Regex(Validar.REGULAR_EXPRESSION_EMAIL);
                foreach (var item in a.Usuario.UsuarioContato.Where(b => b.Publico == true && !rg.IsMatch(b.UsuarioContato1)))
            {
        %>
        
        <div>      
            <div class="campo c-0-100">
               <b><%= item.UsuarioContatoTipo.UsuarioContatoTipo1 %></b> 
            </div>
            <div class="campo c-100-todo">
                <%= item.UsuarioContato1 %>
            </div>
        </div> 

        
        
                
        <%  } %>
        

        
      <div class="content" style="text-align:right;position:relative;">
      <% if (a.Preco != null && a.Preco != 0)
         { %><div class="anuncio-valor">R$ <%= a.Preco.GetValueOrDefault().ToString("##,##0.00")%></div><% } %>
      <div class="anuncio-lista-acoes" style="display:block;width: auto;bottom:-20px;">
                    
                    <abbr class="resposta-data tempo-passado"
                    <% if (a.DataInc != null) { %> data="<%= ((DateTime)a.DataInc).ToString("ddd, d MMM yyyy HH:mm:ss", new CultureInfo("en-US"))  %>"
                    title="<%= ((DateTime)a.DataInc).ToString("ddd, d MMM yyyy HH:mm:ss")%>"<% } %>
                    >
                       
                    </abbr>
                    ·
                    <span class="origem">
                        Via Web
                    </span>
                    ·
                    <a href="javascript:void(0);"   onclick="m.modal('Denunciar', '<%= a.ID %>|1',1);">
                        Denunciar
                    </a>
                    
                </div>
                <% if (UsuarioLogado_ID != null && UsuarioLogado_ID > 0)
                   { 
                   %>
                   
        <a href="javascript:void(0);" class="button" onclick="m.modal('Ofertar',<%= a.ID %>,2);">Ofertar</a>
                   <%
                   }
                   else { 
                   %>
                   <a href="javascript:void(0);" class="button" onclick="m.modal('LoginCadastro', null, 2);">Ofertar</a>
                   <%
                   } %>
      </div>  
        
    
        
	</div> 

</div>


    <div class="clear"></div>

    
    <h1>Descrição</h1>       
    
    <div class="tab_page" id="descricao">
      
      <p>
        <%= Html.Nl2Br(a.Descricao) %>
    </p>
      
      
        

    </div>




    <h1> Bate-Papo</h1>
    <div>
    <%
        string nomeChat;

        if (UsuarioLogado_ID != null && UsuarioLogado_ID > 0)
        {
            nomeChat = HttpUtility.UrlEncode(UsuarioLogado.Nome);
        }
        else
        { 
            Random Aleatorio = new Random();
            nomeChat = "Anônimo" +  Aleatorio.Next(1000, 9999).ToString();
        }
         %>

        <iframe src="http://chat.muambba.com.br:8080/?n=<%= nomeChat %>&s=<%= a.ID %>" id="bate-papo"></iframe>
    </div>
       
<!-- Perguntas do anuncio -->
    <h1>Perguntas</h1>       
    
    <div class="tab_page" id="tab_review">
      
        <div id="review">
      
            <div class="content text-right">
                <%= Html.MuambbaTextArea("Pergunta","Faça uma pergunta para o vendedor",0,0,"",SessaoAtual,"",true)%>
                
                   <%= Html.CheckBox("ckbPrivado") %> Privado
                 <% if (UsuarioLogado_ID != null && UsuarioLogado_ID > 0)
                   { 
                   %>
        <a href="javascript:void(0);" class="button" onclick="var a = { a:<%= (int)ViewData["id"] %>, p:$('#txtPergunta'), v:$('#ckbPrivado') };m.jsn.get('<%= SessaoAtual %>').init(11,a);"><span>Enviar</span></a>

                   <%
                   }
                   else { 
                   %>
                   <a href="javascript:void(0);" class="button" onclick="m.modal('LoginCadastro', null, 2);">Enviar</a>
                   <%
                   } %>
                
            </div>

            <% 
                var perguntas = from an in ctx.Anuncio
                                where an.ID == a.ID
                                join ap in ctx.AnuncioPergunta on an.ID equals ap.IdAnuncio
                                where ap.Resposta == null
                                join up in ctx.Usuario on ap.IdUsuarioInc equals up.ID
                                orderby ap.DataInc descending
                                select new ucPerguntasRespostasParam()
                                {
                                    AnuncioUsuarioInc_ID = an.UsuarioInc_ID,
                                    UsuarioNome = up.Nome,
                                    UsuarioQualificacao = up.QualificacaoPositiva - up.QualificacaoNegativa,
                                    Pergunta = ap.Pergunta,
                                    Resposta = ap.Resposta,
                                    DataUpd = ap.DataUpd,
                                    DataInc = ap.DataInc,
                                    IdUsuarioInc = ap.IdUsuarioInc,
                                    Privada = ap.Privada
                                };

                Html.RenderPartial("ucPerguntasRespostas", perguntas); %>
      

        </div>
      
      
    </div>

<!-- Perguntas do anuncio (FIM) -->


<!-- Outros do memso anunciante -->

    

<%
     
    var lstEmDestaque = (from an in ctx.Anuncio
                         where an.NomeArquivoFotoPrincipal != string.Empty && an.UsuarioInc_ID == a.UsuarioInc_ID && an.ID != a.ID && an.UsuarioExc_ID == null
                            join c in ctx.Categoria on an.Categoria_ID equals c.ID
                            orderby an.DataInc descending
                            select new ucAnuncioListaLinhaParam
                            {
                               ID = an.ID,
                               Titulo = an.Titulo,
                               SubTitulo = an.SubTitulo,
                               Preco = an.Preco,
                               NomeArquivoFotoPrincipal = an.NomeArquivoFotoPrincipal,
                               AnuncioConservacao_ID = an.AnuncioConservacao_ID,
                               AnuncioTipo_ID = an.AnuncioTipo_ID,
                               Visitas = an.Visitas,
                               Categoria = c.Categoria1,
                               Categoria_Link = c.Link,
                               QuantidadeAnuncios = c.QuantidadeAnuncios,
                                DataInc = an.DataInc
                            }).Take(5).ToList();


    Html.RenderPartial("ucAnuncioListaLinha", lstEmDestaque);
%>

<!-- Outros do memso anunciante (FIM)-->
 


</asp:Content>
