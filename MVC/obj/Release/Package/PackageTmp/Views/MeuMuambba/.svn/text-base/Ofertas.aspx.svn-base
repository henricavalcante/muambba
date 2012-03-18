<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="MVC.ViewBase<dynamic>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <%
        
        
        Html.RenderPartial("ucAbasSuperiores");
        var ctx = new ContextoBLL();
        
       var ofertas = (from ao in ctx.AnuncioOferta
                      where ao.UsuarioInc_ID == UsuarioLogado_ID 
                       join a in ctx.Anuncio on ao.Anuncio_ID equals a.ID
                      where a.UsuarioExc_ID == null
                      join c in ctx.Categoria on a.Categoria_ID equals c.ID
                      join u in ctx.Usuario on ao.UsuarioInc_ID equals u.ID
                       
                       select new ucAnuncioOfertaListaPadraoParam
                       {
                            ID = a.ID,
                            Titulo = a.Titulo,
                            Preco = a.Preco,
                            AnuncioTipo_ID = a.AnuncioTipo_ID,
                            Categoria = c.Categoria1,
                            Categoria_Link = c.Link,
                            DataInc = a.DataInc,
                            AnuncioOfertaAnuncio = ao.AnuncioOfertaAnuncio,
                            OfertaValor = ao.OfertaValor,
                            OfertaDescricao = ao.OfertaDescricao,
                            OfertaStatus_ID = ao.AnuncioOfertaStatus_ID,
                            OfertaUsuario = u.Usuario1,
                            OfertaUsuarioQualificacao = u.QualificacaoPositiva - u.QualificacaoNegativa
                       });
       IEnumerable<ucAnuncioOfertaListaPadraoParam> ofertasOrdenadas;

        if (P_em_ordem())
       {
           ofertasOrdenadas = ofertas.OrderBy(P_AnuncioOferta_ordenado_por()).ToList();
       }
           else
       {
           ofertasOrdenadas = ofertas.OrderByDescending(P_AnuncioOferta_ordenado_por()).ToList();
       }

        var ofertasPaginadas = ofertasOrdenadas.Skip(P_a_partir_de()).Take(ItensPorPagina);

                     
                      
        %>
        

    <div class="switcher">
		<div class="selected"><a>Situação</a>
        </div>
		<div class="option">
        <% foreach (var item in AnuncioOfertaStatus.GetAll())
           {
           %>
		    <a href="/MeuMuambba/Ofertas/<%= "_na_situacao_" + item.Status %>"><%= item.Status %></a>
       <%} %>

           
	    </div>
	</div>

    <div class="switcher">
		<div class="selected"><a>Ofertas</a>
        </div>
		<div class="option">
		    <a href="/MeuMuambba/Ofertas/_ofertas_feitas_por_mim">Feitas por mim</a>
            <a href="/MeuMuambba/Ofertas/_ofertas_feitas_em_meus_anuncios">Em meus anuncios</a>
	    </div>
	</div>

    <div class="clearfix"></div>
    <%  Html.RenderPartial("ucAnuncioOfertaListaPadrao", ofertasPaginadas); %>
</asp:Content>

