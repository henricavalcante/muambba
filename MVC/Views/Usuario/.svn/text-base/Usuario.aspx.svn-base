<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="MVC.ViewBase<Usuario>" %>

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


    var u = Model;
     %>


     
<h1 class="titulo"><%= u.Nome  %> <%= u.Sobrenome  %></h1>


<div class="clearfix"  style="width:100%;" >

<div class="clearfix" style="float:right;width:424px">

<%
    if (u.UsuarioFoto.Count > 0)
    {
%>
    

        <div class="clearfix" style="float: left; width: 102px;">

   

            <ul id="thumblist" class="clearfix" >
                    <%
        foreach (var item in u.UsuarioFoto)
        {  
                    %>
                    <li><a href='javascript:void(0);' rel="{gallery: 'gal1', smallimage: '/Imagens/Usuarios/<%= item.NomeArquivo.Split('.')[0] + "p." + item.NomeArquivo.Split('.')[1]%>',largeimage: '/Imagens/Usuarios/<%= item.NomeArquivo %>'}"><img src='/Imagens/Usuarios/<%= item.NomeArquivo.Split('.')[0] + "s." + item.NomeArquivo.Split('.')[1]%>' width="90px" height="90px"></a></li>
		     
                    <%  
        }
                    %>
            </ul>  


	    </div> 
    
	    <div class="clearfix" style="float:right;">
            <a href="/Imagens/Usuarios/<%= u.NomeArquivoFotoPrincipal %>" class="jqzoom" rel='gal1'  title="<%= u.Nome %>" >
                <img src="/Imagens/Usuarios/<%= u.NomeArquivoFotoPrincipal.Split('.')[0] + "p." + u.NomeArquivoFotoPrincipal.Split('.')[1]%>"  title="<%= u.Nome %>"  style="border: 1px solid #666;">
            </a>
	    </div>
    
 <%
    }
        
%>


  </div>
<div class="clearfix" style="padding-right: 426px; display: block;">
	

    <h2>Contatos</h2>

        <%
            Regex rg = new Regex(Validar.REGULAR_EXPRESSION_EMAIL);
            foreach (var item in u.UsuarioContato.Where(b=>b.Publico == true && !rg.IsMatch(b.UsuarioContato1)))
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
      
      <h2>Qualificações</h2>
        <div>      
            <div class="campo c-0-100">
                <b>Positivas</b> 
            </div>
            <div class="campo c-100-todo">
                <%= u.QualificacaoPositiva %>
            </div>
        </div>  
        <div>      
            <div class="campo c-0-100">
                <b>Neutras</b> 
            </div>
            <div class="campo c-100-todo">
                <%= u.QualificacaoNeutra %>
            </div>
        </div>  
        <div>      
            <div class="campo c-0-100">
                <b>Negativas</b> 
            </div>
            <div class="campo c-100-todo">
                <%= u.QualificacaoNegativa %>
            </div>
        </div>  
        
	</div> 

</div>


    <div class="clear"></div>

    
  
<!-- Outros do memso anunciante -->

    

<%
     
    var lstEmDestaque = (from an in ctx.Anuncio
                         where an.NomeArquivoFotoPrincipal != string.Empty && an.UsuarioInc_ID == u.ID && an.UsuarioExc_ID == null
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
                            }).Take(25).ToList();


    Html.RenderPartial("ucAnuncioListaLinha", lstEmDestaque);
%>

<!-- Outros do memso anunciante (FIM)-->
 


</asp:Content>
