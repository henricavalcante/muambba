<%@ Control Language="C#" Inherits="MVC.UserControlBase<IEnumerable<ucAnuncioListaLinhaParam>>" %>
<ul class="lista-capa" >
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
                <% } if (UsuarioLogado_ID != null && item.UsuarioInc_ID == UsuarioLogado_ID || UsuarioLogado_ADMIN)
                  { %>
                <a href="/Anunciar/<%= item.ID %>" class="m0 i11 editar" title="Editar" ></a>
                <% } %>
                <a href="javascript:void(0);" class="m0 i11 denunciar" title="Denunciar" onclick="m.modal('Denunciar', '<%= item.ID %>|1',1);"></a>
            </div>
            <a href="/a/<%= item.ID %>/<%=Html.TituloAnuncio(item.Titulo) %>"><img src="/Imagens/Anuncios/<%= item.NomeArquivoFotoPrincipal.Split('.')[0] + "s." + item.NomeArquivoFotoPrincipal.Split('.')[1] %>" title="<%= item.Titulo %>" alt="<%= item.Titulo %>" class="img-border" /></a><br />
            <a href="/a/<%= item.ID %>/<%=Html.TituloAnuncio(item.Titulo) %>" class="pname"><%= item.Titulo%></a><br />
            <a href="<%= item.Categoria_Link %>"><span style="color: #999; font-size: 9px;"><%= item.Categoria %> (<%= item.QuantidadeAnuncios %>)</span></a>
            <% if (item.Preco != null && item.Preco > 0)
               { 
               %>
            <br /><span class="lista-capa-preco">R$<%= item.Preco.GetValueOrDefault().ToString("##,##0.00")%></span>   
               <%
               } %>
        </li>
        
        
        <%
    }%>
    </ul>