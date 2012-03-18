<%@ Control Language="C#" Inherits="MVC.UserControlBase<IEnumerable<ucPerguntasRespostasParam>>" %>


        <ul = id="pergunta">
          <% 
              var perguntas = Model;
              var ExibeResposta = false;
              
              if (perguntas.Count() > 0)
              {
                  ExibeResposta = (perguntas.FirstOrDefault().AnuncioUsuarioInc_ID == UsuarioLogado_ID);
              }
          
          
            foreach (var item in perguntas.Where(a => !a.Privada || a.IdUsuarioInc == UsuarioLogado_ID || a.AnuncioUsuarioInc_ID == UsuarioLogado_ID))
            {
                var pid = item.ID;
              
            %>
          <li>
                <div class="pergunta-conteudo">
            
            
                <% if (item.AnuncioTitulo != null && item.AnuncioTitulo != string.Empty) { %> 
                <a href="/a/<%= item.IdAnuncio %>/<%= Html.TituloAnuncio(item.AnuncioTitulo) %>"><span class="pergunta-anuncio-titulo"><%= item.AnuncioTitulo %></span></a>
                <%} %>
                <span class="pergunta-nome"><%= item.UsuarioNome + " (" + (item.UsuarioQualificacao).ToString() + ")"%></span>
                <p>
                    <%= Html.Nl2Br(item.Pergunta)%>
                </p>
                

        
            <div id="dvResposta_<%= pid %>" class="resposta" <% if (item.DataUpd == null) { %>style="display:none;\"<%} %>>
            
                <span class="resposta-resposta"><%= Html.Nl2Br(item.Resposta)%></span>
                
                <div class="resposta-acoes">
                    
                    <abbr class="resposta-data tempo-passado"
                    <% if (item.DataUpd != null) { %> data="<%= ((DateTime)item.DataUpd).ToString("ddd, d MMM yyyy HH:mm:ss", new CultureInfo("en-US"))  %>"
                    title="<%= ((DateTime)item.DataUpd).ToString("ddd, d MMM yyyy HH:mm:ss")%>"<% } %>
                    >
                       <% if (item.DataUpd != null) { %> <%= ((DateTime)item.DataUpd).ToString("ddd, d MMM yyyy HH:mm:ss")%> <% } %>
                    </abbr>
                    ·
                    <span class="resposta-origem">
                        via web
                    </span>
                    ·
                    <a href="javascript:void(0);"  onclick="m.modal('Denunciar', '<%= item.ID %>|3',1);">
                        Denunciar
                    </a>
                </div>

            </div>
            <% 
                
                if ((item.DataUpd == null) && ExibeResposta)  
               { %>

            <div id="dvResponder_<%= pid %>"  class="resposta">
                
                <%= Html.MuambbaTextArea("Resposta_" + pid,"Insira uma resposta para a pergunta acima",0,0,"",SessaoAtual,"",true)%>

                <a class="button" onclick="var obr = {pid: <%= item.ID %> ,re: $('#<%= "txtResposta_" + pid %>').val()}; m.jsn.get('<%= SessaoAtual %>').init(8, obr)"><span>Responder</span></a>
                
                
                
            </div>



 <% } %>           

            <div class="pergunta-acoes">
                    
                    <abbr class="pergunta-data tempo-passado" data="<%= item.DataInc.ToString("ddd, d MMM yyyy HH:mm:ss", new CultureInfo("en-US"))%>" title="<%= item.DataInc.ToString("ddd, d MMM yyyy HH:mm:ss")%>">
                        <%= item.DataInc.ToString("ddd, d MMM yyyy HH:mm:ss")%>
                    </abbr>
                    ·
                    <span class="pergunta-origem">
                        via web
                    </span>
                    ·
                    <span class="resposta-privacidade" title="Todos podem ver essa pergunta">
                        <%= (item.Privada)?"Privado":"Público" %>
                    </span>
                    ·
                    <a href="javascript:void(0);"  onclick="m.modal('Denunciar', '<%= item.ID %>|2',1);">
                        Denunciar
                    </a>
                </div>

        </div>
      </li>
          
<% } %>
      
      </ul>

