<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

   
<!-- Ultimos Anuncios -->


    <div class="heading">Últimos Anuncios</div>


<%
    
    var ctx = new ContextoBLL();

    var anunciosrecentes = (from a in ctx.Anuncio
                            where a.NomeArquivoFotoPrincipal != String.Empty && a.UsuarioExc_ID == null
                            join c in ctx.Categoria on a.Categoria_ID equals c.ID
                            orderby a.DataInc descending
                            select new ucAnuncioListaLinhaParam
                            {
                               ID = a.ID,
                               Titulo = a.Titulo,
                               SubTitulo = a.SubTitulo,
                               Preco = a.Preco,
                               NomeArquivoFotoPrincipal = a.NomeArquivoFotoPrincipal,
                               AnuncioConservacao_ID = a.AnuncioConservacao_ID,
                               AnuncioTipo_ID = a.AnuncioTipo_ID,
                               Visitas = a.Visitas,
                               Categoria = c.Categoria1,
                               Categoria_Link = c.Link,
                               QuantidadeAnuncios = c.QuantidadeAnuncios,
                               DataInc = a.DataInc,
                               UsuarioInc_ID = a.UsuarioInc_ID
                            }).Take(5).ToList();


    Html.RenderPartial("ucAnuncioListaLinha", anunciosrecentes);
%>

<!-- Ultimos Anuncios (FIM)-->


<!-- Anuncios em Destaque -->

    <div class="heading">Em Destaque</div>


<%
    
    var lstEmDestaque = (from a in ctx.Anuncio
                         where a.NomeArquivoFotoPrincipal != string.Empty && a.UsuarioInc_ID == 3 && a.UsuarioExc_ID == null
                            join c in ctx.Categoria on a.Categoria_ID equals c.ID
                            orderby a.DataInc descending
                            select new ucAnuncioListaLinhaParam
                            {
                               ID = a.ID,
                               Titulo = a.Titulo,
                               SubTitulo = a.SubTitulo,
                               Preco = a.Preco,
                               NomeArquivoFotoPrincipal = a.NomeArquivoFotoPrincipal,
                               AnuncioConservacao_ID = a.AnuncioConservacao_ID,
                               AnuncioTipo_ID = a.AnuncioTipo_ID,
                               Visitas = a.Visitas,
                               Categoria = c.Categoria1,
                               Categoria_Link = c.Link,
                               QuantidadeAnuncios = c.QuantidadeAnuncios,
                                DataInc = a.DataInc
                            }).Take(5).ToList();


    Html.RenderPartial("ucAnuncioListaLinha", lstEmDestaque);
%>
<!-- Anuncios em Destaque (FIM)-->

<!-- Anuncios Mais Visitados -->

  <div class="heading">Mais Visitados</div>


<%
    
    var lstMaisVisitados = (from a in ctx.Anuncio
                            where a.NomeArquivoFotoPrincipal != string.Empty && a.UsuarioExc_ID == null
                            join c in ctx.Categoria on a.Categoria_ID equals c.ID
                         orderby a.Visitas descending
                            select new ucAnuncioListaLinhaParam
                            {
                               ID = a.ID,
                               Titulo = a.Titulo,
                               SubTitulo = a.SubTitulo,
                               Preco = a.Preco,
                               NomeArquivoFotoPrincipal = a.NomeArquivoFotoPrincipal,
                               AnuncioConservacao_ID = a.AnuncioConservacao_ID,
                               AnuncioTipo_ID = a.AnuncioTipo_ID,
                               Visitas = a.Visitas,
                               Categoria = c.Categoria1,
                               Categoria_Link = c.Link,
                               QuantidadeAnuncios = c.QuantidadeAnuncios,
                                DataInc = a.DataInc
                            }).Take(5).ToList();


    Html.RenderPartial("ucAnuncioListaLinha", lstMaisVisitados);
%>

<!-- Anuncios Mais Visitados (FIM)-->
      
											
<div class="clearfix"></div>

<!-- Tag Cloud -->
<div id="default_tag_cloud" >
    
<ul id="tag_cloud">
<% var bll = new BLLvwTagCloud();
    
    foreach (var i in bll.ToList())
    {
        
        
        %>
        
            <li>
                <a href="/b/<%= HttpUtility.UrlEncode( i.Busca) %>" q="<%=  i.Quantidade %>">
                    <%=  i.Busca %>
                </a>
            </li>

        
        <%
    }
     %>
        
</ul>
           
</div>

<script type="text/javascript">

    $(function () {

        var aLi = $("#tag_cloud li a");
        var iLi = aLi.length;
        var fonte = 20;
        $.each(aLi, function (i, o) {

            $(o).css({ 'font-size': fonte + 'pt' });
            fonte = fonte - 0.5;

        });
        $('#tag_cloud').find("li").tsort({ order: "rand" });

    });
</script>

<!-- Tag Cloud (FIM) -->


 

</asp:Content>
