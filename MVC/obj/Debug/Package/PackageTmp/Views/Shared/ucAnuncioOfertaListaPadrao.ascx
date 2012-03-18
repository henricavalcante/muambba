<%@ Control Language="C#" Inherits="MVC.UserControlBase<IEnumerable<ucAnuncioOfertaListaPadraoParam>>" %>


<ul class="ul-anuncio-oferta-lista">
    <% foreach (var item in Model)
       
       {
           %>
           
          
        <li>
            
            <div class="anuncio-oferta-lista">
                
                    
                    <div class="anuncio-oferta-lista-info2">
                
                    <% if (item.Preco != null)
                       { %>Valor do Anuncio:<span class="anuncio-oferta-lista-valor">R$ <%= ((decimal)item.Preco).ToString("##,##0.00")%></span><% } %>



                       <%   decimal ValorOfertaAnuncios = 0;
                           foreach (var aoa in item.AnuncioOfertaAnuncio)
                           {
                               ValorOfertaAnuncios += aoa.Anuncio.Preco.GetValueOrDefault();
                           } %>
                        
                    <% if (ValorOfertaAnuncios != null && ValorOfertaAnuncios > 0)
                       { %>Oferta em Anuncios:<span class="anuncio-oferta-lista-valor-p">R$ <%= (ValorOfertaAnuncios).ToString("##,##0.00")%></span><% } %>
                    

                       
                    <% if (item.OfertaValor != null)
                       { %>Oferta em Dinheiro:<span class="anuncio-oferta-lista-valor-p">R$ <%= ((decimal)item.OfertaValor).ToString("##,##0.00")%></span><% } %>
                    

                        
                    <% if (item.OfertaValor != null && ValorOfertaAnuncios != null)
                       { %>Total da Oferta:<span class="anuncio-oferta-lista-valor">R$ <%= ((decimal)item.OfertaValor + ValorOfertaAnuncios).ToString("##,##0.00")%></span><% } %>
                    

                     
                    <% 
                        
                        if ((item.OfertaValor != null || ValorOfertaAnuncios != null) && item.Preco != null)
                       { 
                            decimal LucroPrejuizo = item.OfertaValor.GetValueOrDefault() + ValorOfertaAnuncios - (decimal)item.Preco;
                            %>Lucro/Prejuizo:<span class="anuncio-oferta-lista-valor-g <%= (LucroPrejuizo < 0) ? "negativo" : "positivo" %>">
                                R$ <%= (LucroPrejuizo).ToString("##,##0.00")%>
                               </span><% } %>
                    

                    <span><%= item.Categoria %></span>
                    
                </div>



                    <div class="anuncio-oferta-lista-info">
                        <a href="/a/<%= item.ID %>/<%= Html.TituloAnuncio(item.Titulo) %>" alt="<%= item.Titulo %>"><span class="anuncio-lista-titulo"> <%= item.Titulo %></span></a>
                        <div class="content">
                        
                        <a href="/u/<%= item.OfertaUsuario %>"><h3><%= item.OfertaUsuario %> (<%= item.OfertaUsuarioQualificacao %>)</h3></a>
                            
                            <% foreach (var aoa in item.AnuncioOfertaAnuncio)
                               {  %>
                                <a href="/a/<%= aoa.Anuncio.ID %>/<%= Html.TituloAnuncio(aoa.Anuncio.Titulo) %>"><span class="anuncio-lista-titulo-p"> <%= aoa.Anuncio.Titulo %></span></a>
                                <% if (aoa.Anuncio.Preco != null) { %>
                                    <span class="anuncio-oferta-lista-valor">R$ <%= aoa.Anuncio.Preco.GetValueOrDefault().ToString("##,##0.00")%></span>
                                <% } %>
                                
                            <%
                               } %>
                        <p><%= item.OfertaDescricao%></p>

                        </div>
                        

                        
                    </div>
                
                
                
                
            </div>
        </li>
         <%
       } %>
    </ul>