<%@ Control Language="C#" Inherits="MVC.UserControlBase<Object>" %>



<% var ctx = new ContextoBLL();

   var anuncios = (from a in ctx.Anuncio
                   where a.UsuarioInc_ID == UsuarioLogado_ID && a.UsuarioExc_ID == null
                   join c in ctx.Categoria on a.Categoria_ID equals c.ID
                   select new 
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
                       DataInc = a.DataInc

                   });
    %>

    <% if (anuncios.Count() > 0)
       { 
       %>
       
       
    <div style="width:275px;display:inline-block;float:left;" class="clearfix">
        <div class="scroll-pane dvAnuncio">
    
            <ul class="anuncios-lista-mini">
                <% foreach (var item in anuncios)
                   {
                       %>
                            <li class="txt-borda anuncio" style="margin: 5px; width: 250px;" anuncio="<%= item.ID %>">
                            
                                <div>
                                    <%= item.Titulo%>
                                    <% if (item.Preco != null && item.Preco > 0)
                                       { %>- <span class="anuncio-lista-mini-valor">R$ <%= item.Preco.GetValueOrDefault().ToString("##,##0.00")%></span><%} %>
                                </div>
                            
                            </li>     
                   
                       <%
                   } %>
            
            </ul>
        </div>
    </div>
    <div style="width:275px;display:inline-block;float:right;" class="clearfix">
        <% } else { %>
       <div style="width:100%;display:inline-block;">
       <% } %>
        <%= Html.MuambbaTextArea("Oferta-Descricao", "Descrição da oferta", 0, 0, "", SessaoAtual, "", true) %>
        <%= Html.MuambbaTextBox("Oferta-Valor", "0,00", 0, 0, "decimal", SessaoAtual, "0.00", true)%>
        <div class="content">
            <a href="javascript:void(0);" class="button" onclick="cadastrar();">Ofertar</a>

        </div>
        
    </div>

<script type="text/javascript">

    m.reset();

    $(".anuncios-lista-mini li").click(function () { $(this).toggleClass('selecionado'); });

    $(function () {
        setTimeout( 'load()',0);
    });

    function load() {
        jQuery('.dvAnuncio').jScrollPane();
    }
  
    function cadastrar() {

        var arrAnuncios = new Array();
        
        $('.anuncio.selecionado').each(function (i, element) {

            arrAnuncios.push($(element).attr('anuncio'));

        });
        
        $.ajax({
            type: "POST",
            url: "/j/json12",
            data: {
                        sch: '<%= SessaoAtual %>',
                        anuncio_id: <%= Model %>,
                        ofertas: arrAnuncios,
                        descricao: $('#txtOferta-Descricao').val(),
                        valor: $('#txtOferta-Valor').val()

                    },
            success: function (data) {
                    
                alert(data.m);
                if (data.s)
                {
                    $('#mask').click();
                }
                    
            },
            dataType: "json",
            traditional: true
        });
    }

</script>