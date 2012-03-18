<%@ Control Language="C#" Inherits="MVC.UserControlBase<ucPaginacaoOrdenacaoFiltrosParam>" %>


<%
    int totalPaginas = Model.QuantidadeRegistros / ItensPorPagina;
    if (Model.QuantidadeRegistros % ItensPorPagina > 0)
    {
        totalPaginas++;
    }
     %>
<div class="anuncio-lista-comando">

<% if (Model.QuantidadeRegistros > 1)
       {
   %>
   

    <div class="switcher">
		<div class="selected"><a><%= (Parametro("em_ordem") != string.Empty) ? Parametro("em_ordem") : "Em Ordem" %></a>
        </div>
                    
		<div class="option">
		    <a href="<%= Model.UrlRetorno + UrlParametro("a_partir_de") + UrlParametro("ordenado_por") + "_em_ordem_crescente"%>">Crescente</a>
	        <a href="<%= Model.UrlRetorno + UrlParametro("a_partir_de") + UrlParametro("ordenado_por") + "_em_ordem_decrescente"%>">Decrescente</a>
	    </div>
	</div>

	<div class="switcher">
		<div class="selected"><a><%= (Parametro("ordenado_por") != string.Empty)? Parametro("ordenado_por") :"Ordenar Por" %></a>
        </div>
                    
		<div class="option">
        <% foreach (var item in Model.Ordenacao) { %>
           <a href="<%= Model.UrlRetorno + "_ordenado_por_"+ HttpUtility.UrlEncode(item, Encoding.GetEncoding(28597)).Replace("+", " ") + UrlParametro("em_ordem")%>"><%= item %></a>
        <% } %>
		    
	    </div>
	</div>
<%
   }
        if (P_a_partir_de() >= ItensPorPagina)
        { %>
    <a href="<%= Model.UrlRetorno +  "_a_partir_de_"+ (P_a_partir_de()-ItensPorPagina) + UrlParametro("ordenado_por") + UrlParametro("em_ordem")%>">« Anterior</a>
    <% } %>

    <% if (Model.QuantidadeRegistros > ItensPorPagina)
       {
           for (int i = 0; i < (totalPaginas); i++)
           {%>
            <a <%= ((P_a_partir_de()/ ItensPorPagina) == i )?"class=\"pagina-atual\"":"" %>  href="<%= Model.UrlRetorno + "_a_partir_de_"+ (i*ItensPorPagina) + UrlParametro("ordenado_por") + UrlParametro("em_ordem")%>"><%= i + 1%></a>
        <%
           }
       }
            %>
         
    <% if (P_a_partir_de() + ItensPorPagina < Model.QuantidadeRegistros)
        { %>
    <a href="<%= Model.UrlRetorno + "_a_partir_de_"+ (P_a_partir_de()+ItensPorPagina) + UrlParametro("ordenado_por") + UrlParametro("em_ordem")%>">Próxima »</a>
	    <% } %>
</div>
<div class="clearfix"></div>