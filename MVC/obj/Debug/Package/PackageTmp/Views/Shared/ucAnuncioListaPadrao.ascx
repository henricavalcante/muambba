<%@ Control Language="C#" Inherits="MVC.UserControlBase<IEnumerable<ucAnuncioListaPadraoParam>>" %>

<ul class="ul-anuncio-lista">
    <% foreach (var item in Model)
       
       {
           %>
           
          
        <li class="acoes-11-c">
       
          
            <div class="acoes-11">
                <%if (UsuarioLogado_ID != null && item.UsuarioInc_ID == UsuarioLogado_ID || UsuarioLogado_ADMIN)
                  {  %>
                <a href="javascript:void(0);" class="m0 i11 remover" title="Remover" onclick="var r=confirm('Deseja realmente excluir o anuncio \'<%= item.Titulo %>\'?'); if (r) { m.jsn.get('<%= SessaoAtual %>').init(13,{a:<%= item.ID %>,t:$(this)}); }"></a>
                <% } if (UsuarioLogado_ID != null && UsuarioLogado_ID > 0) { %>
                <a href="javascript:void(0);" class="m0 i11 aceitar" title="Ofertar" onclick="m.modal('Ofertar',<%= item.ID %>,2);"></a>
                <% } if (false) { %>
                <a href="javascript:void(0);" class="m0 i11 editar" title="Editar"></a>
                <% } %>
                <a href="javascript:void(0);" class="m0 i11 denunciar" title="Denunciar" onclick="m.modal('Denunciar', '<%= item.ID %>|1',1);"></a>
            </div>
            
            <div class="anuncio-lista">
                <div class="anuncio-lista-direita">

                    <div class="anuncio-lista-foto">
                        <% if (item.NomeArquivoFotoPrincipal == null) { 
                           %>
                        <img alt="Sem Foto" src="/Imagens/px.gif" class="sem-foto"  alt="<%= item.Titulo %>" />
                       
                           <% 
                           } else {%>
                       
                           <img alt="<%= item.Titulo %>" an="<%= item.ID %>" onmouseover="m.jsn.get('<%= SessaoAtual %>').init(9,$(this));" src="/Imagens/Anuncios/<%= item.NomeArquivoFotoPrincipal.Split('.')[0] + "s." + item.NomeArquivoFotoPrincipal.Split('.')[1] %>"  />
                      

                           <%
                           } %>
                            <ul id="anuncio-fotos-<%= item.ID %>"class="jcarousel jcarousel-skin-anuncio-lista" style="display:none;">
                        
                          </ul>
                    
                    </div>
                    <div class="anuncio-lista-info2">
                
                        <% if (item.Preco != null)
                           { %><span class="anuncio-lista-valor">R$ <%= ((decimal)item.Preco).ToString("##,##0.00")%></span><% } %>
                        <span><%= AnuncioConservacao.ToString( item.AnuncioConservacao_ID) %></span>
                        <span><%= AnuncioTipo.ToString( item.AnuncioTipo_ID) %></span>
                        <span><%= item.Categoria %></span>
                        <% if (item.Visitas > 0)
                           { %><span><%= item.Visitas%> Visita<%= (item.Visitas > 1) ? "s" : ""%></span><% } %>
                
                    </div>

                </div>
                <a href="/a/<%= item.ID %>/<%= Html.TituloAnuncio(item.Titulo) %>" alt="<%= item.Titulo %>">
                    
                    <div class="anuncio-lista-info">
                            <span class="anuncio-lista-titulo"> <%= item.Titulo %></span>
                            <span class="anuncio-lista-subtitulo"><%= item.SubTitulo%></span>
                    
                    </div>
                </a>
                
                

                <div class="anuncio-lista-acoes">
                    <% if (false)
                       { %>
                    <div class="anuncio-rank rank-ativo">
                        <ul>
                            <li><img alt="10" src="/Imagens/px.gif" class="m0 i16 estrela_semuso estrela_semrank" /></li>
                            <li><img alt="20" src="/Imagens/px.gif" class="m0 i16 estrela_semuso estrela_semrank" /></li>
                            <li><img alt="30" src="/Imagens/px.gif" class="m0 i16 estrela_semuso estrela_semrank" /></li>
                            <li><img alt="40" src="/Imagens/px.gif" class="m0 i16 estrela_semuso estrela_semrank" /></li>
                            <li><img alt="50" src="/Imagens/px.gif" class="m0 i16 estrela_semuso estrela_semrank" /></li>
                        </ul>
                    </div>
                    &nbsp;
                    ·
                    <% } %>
                    <abbr class="resposta-data tempo-passado"
                    <% if (item.DataInc != null) { %> data="<%= ((DateTime)item.DataInc).ToString("ddd, d MMM yyyy HH:mm:ss", new CultureInfo("en-US"))  %>"
                    title="<%= ((DateTime)item.DataInc).ToString("ddd, d MMM yyyy HH:mm:ss")%>"<% } %>
                    >
                       <% if (item.DataInc != null)
                          { %> <%= ((DateTime)item.DataInc).ToString("ddd, d MMM yyyy HH:mm:ss")%> <% } %>
                    </abbr>
                    ·
                    <span class="origem">
                        via web
                    </span>
                    ·
                    <span class="resposta-privacidade" title="Todos podem ver essa pergunta">
                        Público
                    </span>
                    
                </div>
            </div>
        </li>
         <%
       } %>
    </ul>
     <script type="text/javascript" lang="javascript">

         $('.rank-ativo .estrela_semrank').mouseover(function () {
             var indice = $(this).parent().parent().find('img').index(this);
             $(this).parent().parent().find('li:lt(' + (eval(indice) + 1) + ') > img').addClass('estrela_ativa').removeClass('estrela_inativa');

             $(this).parent().parent().find('li:gt(' + indice + ') > input').addClass('estrela_inativa').removeClass('estrela_ativa');

             $(this).click(function () {
                 $(this).removeClass('estrela_semrank');
             });

         });
         $('.rank-ativo  .estrela_semrank').parent().parent().mouseout(function () {
             $(this).find('li > img').removeClass('estrela_inativa').removeClass('estrela_ativa');
         });
    


    </script>